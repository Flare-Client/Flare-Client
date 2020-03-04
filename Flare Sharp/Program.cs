using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.IO;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules;
using Flare_Sharp.ClientBase.UI;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using Flare_Sharp.Memory.VHooks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows;
using System.Windows.Threading;
using Timer = System.Timers.Timer;

namespace Flare_Sharp
{
    class Program
    {
        public static string version = "0.0.6.3";
        public static int threadSleep = 1;
        public static EventHandler<EventArgs> mainLoop;
        public static float cpuLimit = 70f;
        public static double cpuUsage = 0f;
        public static bool isCpuLimited
        {
            get
            {
                return CategoryHandler.registry.categories[3].modules[5].enabled;
            }
        }
        static PerformanceCounter cpuCounter;
        [STAThread]
        static void Main(string[] args)
        {
            //Dont.Be.A.Scumbag.And.Remove.This.Warn.warn();
            Console.WriteLine("Flare# Client");
            Console.WriteLine("Flare port to C#");
            Console.WriteLine("Discord: https://discord.gg/Hz3Dxg8");

            System.Diagnostics.Process.Start("minecraft://");

            try
            {
                MCM.openGame();
                MCM.openWindowHost();

                /*Console.WriteLine("Starting performance tracker...");
                cpuCounter = new PerformanceCounter("Process", "% Processor Time", System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper(), true);

                Timer cpuTimer = new Timer(1000);
                cpuTimer.Elapsed+=(object obk, ElapsedEventArgs asd)=>
                {
                    cpuUsage = cpuCounter.NextValue()/10;
                };
                cpuTimer.Start();
                Console.WriteLine("Performance tracker loaded!");*/
                Console.WriteLine("Starting overlay host...");
                CommandHook cmh = new CommandHook();
                SDK sdk = new SDK();
                FileMan fm = new FileMan();
                CategoryHandler ch = new CategoryHandler();
                ModuleHandler mh = new ModuleHandler();
                KeybindHandler kh = new KeybindHandler();
                if (fm.readConfig())
                {
                    Console.WriteLine("Loaded config!");
                }
                else
                {
                    Console.WriteLine("Could not load config!");
                }
                Thread mainThread = new Thread(() => {
                    while (true)
                    {
                        try
                        {
                            if (cpuUsage <= cpuLimit)
                            {
                                mainLoop.Invoke(null, new EventArgs());
                            }
                            if (isCpuLimited)
                                Thread.Sleep(threadSleep);
                        }
                        catch (Exception)
                        {

                        }
                    }
                });
                mainThread.Start();
                Console.WriteLine("Loading overlay...");
                new Application().Run(new OverlayHost());
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
            System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
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
