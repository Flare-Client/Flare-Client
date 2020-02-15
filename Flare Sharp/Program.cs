using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.UI;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using Flare_Sharp.Memory.VHooks;
using Flare_Sharp.UI;
using Flare_Sharp.UI.TabUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public static string version = "0.0.6.3";
        public static int threadSleep = 1;
        public static EventHandler<EventArgs> mainLoop;
        public static float cpuLimit = 70f;
        public static float cpuUsage = 0f;
        static PerformanceCounter cpuCounter;
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

                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                Timer cpuTimer = new Timer(1000);
                cpuTimer.Elapsed+=(object obk, ElapsedEventArgs asd)=>
                {
                    //Console.WriteLine("CPU logged");
                    cpuUsage = cpuCounter.NextValue();
                };
                cpuTimer.Start();

                CommandHook cmh = new CommandHook();
                SDK sdk = new SDK();
                FileMan fm = new FileMan();
                CategoryHandler ch = new CategoryHandler();
                TabUiHandler tuih = new TabUiHandler();
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
                uiApp.SetApartmentState(ApartmentState.STA);
                uiApp.Start();
                while (true)
                {
                    try
                    {
                        if (cpuUsage <= cpuLimit)
                        {
                            mainLoop.Invoke(null, new EventArgs());
                        }
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

        public static void printCPUInfo()
        {
            // Refresh the current process property values.
            Process myProcess = Process.GetCurrentProcess();
            myProcess.Refresh();

            Console.WriteLine();

            // Display current process statistics.

            Console.WriteLine($"{myProcess} -");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}");
            Console.WriteLine($"  Base priority             : {myProcess.BasePriority}");
            Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}");
            Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
            Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}");
            Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
            Console.WriteLine($"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}");
            Console.WriteLine($"  Paged memory size         : {myProcess.PagedMemorySize64}");
        }
    }
}
