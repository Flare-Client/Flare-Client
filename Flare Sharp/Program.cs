using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using Flare_Sharp.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flare_Sharp
{
    class Program
    {
        public static int threadSleep = 1;
        public static EventHandler<EventArgs> mainLoop;
        static void Main(string[] args)
        {
            Console.WriteLine("Flare# Client");
            Console.WriteLine("Flare port to C#");
            Console.WriteLine("Discord: https://discord.gg/Hz3Dxg8");

            Process.Start("minecraft://");

            try
            {
                MCM.openGame();
                MCM.openWindowHost();

                SDK sdk = new SDK();
                CategoryHandler ch = new CategoryHandler();
                ModuleHandler mh = new ModuleHandler();
                Thread uiApp = new Thread(() => { TabUI ui = new TabUI(); Application.Run(ui); });
                uiApp.Start();
                KeybindHandler kh = new KeybindHandler();
                while (true)
                {
                    try
                    {
                        mainLoop.Invoke(null, new EventArgs());
                        Thread.Sleep(threadSleep);
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
