using Flare_Sharp.ClientBase;
using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using Flare_Sharp.Memory.VHooks;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Flare_Sharp
{
    class Program
    {
        public static string version = "0.0.6.4";
        public static int threadSleep = 1;
        public static EventHandler<EventArgs> mainLoop;
        public static bool limitCpu = false;
        public static WebClient webClient = new WebClient();

        static void Main(string[] args)
        {
            //Dont.Be.A.Scumbag.And.Remove.This.Warn.warn();
            Console.WriteLine("Flare# Client");
            Console.WriteLine("Flare port to C#");
            Console.WriteLine("Discord: https://discord.gg/Hz3Dxg8");

            Process.Start("minecraft://");

            try
            {
                MCM.openGame();
                MCM.openWindowHost();

                CommandHook cmh = new CommandHook();
                FileMan fm = new FileMan();
                CategoryHandler ch = new CategoryHandler();
                ModuleHandler mh = new ModuleHandler();
                KeybindHandler kh = new KeybindHandler();
                Thread uiApp = new Thread(() => { OverlayHost ui = new OverlayHost(); Application.Run(ui); });
                if (fm.readConfig()) 
                {
                    Console.WriteLine("Loaded config!");
                }
                else
                {
                    Console.WriteLine("Could not load config!");
                }

                // Readd when working
                //webClient.DownloadFile("https://raw.githubusercontent.com/Flare-Client/Flare-Client/dom/Dependencies/DiscordRPC.dll", $"{Environment.CurrentDirectory}/FlareData/DiscordRPC.dll");
                //Assembly assembly = Assembly.LoadFrom($"{Environment.CurrentDirectory}/FlareData/DiscordRPC.dll");
                //Console.WriteLine($"DiscordRPC assembly: {assembly}");

                uiApp.Start();
                if(args != null)
                {
                    if (args.Length > 0)
                    {
                        if (args[0] == "dualThread")
                        {
                            Thread moduleThread = new Thread(() => { while (true) { try { ModuleHandler.registry.tickModuleThread(); Thread.Sleep(1); } catch (Exception) { } } });
                            moduleThread.Start();
                        }
                    }
                }
                while (true)
                {
                    try
                    {
                        mainLoop.Invoke(null, new EventArgs());
                        if(limitCpu)
                            Thread.Sleep(1);
                    }
                    catch (Exception)
                    {

                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Stacktrace: " + ex.StackTrace);
                MessageBox.Show("Flare crashed! Check the console for error details. Click 'Ok' to quit.");
            }
        }
    }
}
