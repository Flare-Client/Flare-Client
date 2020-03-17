using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules.Modules;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Flare_Sharp.ClientBase.Modules
{
    public class ModuleHandler
    {
        public static ModuleHandler registry;
        public ModuleHandler()
        {
            registry = this;
            /*
            Console.WriteLine("Module ticking statistics starting...");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (object send, ElapsedEventArgs arg) => {
                tps = currentTick;
                currentTick = 0;
                Console.WriteLine("Module ticks per second: " + tps);
            };
            timer.Interval = 1000;
            timer.Start();
            */
            Console.WriteLine("Starting module register...");
            /* Register modules here */
            new Aimbot();
            new Hitbox();
            new Triggerbot();
            new BoostHit();
            new Criticals();
            new Misplace();
            new Reach();
            new RapidAttack();
            new AutoSword();
            new AirJump();
            new Glide();
            new HighJump();
            new AutoSprint();
            new PlayerSpeed();
            new Jesus();
            new NoWater();
            new BHOP();
            new NoSlowDown();
            new NoKnockBack();
            new NoWeb();
            new Step();
            new FastLadder();
            new AirAcceleration();
            new Velocity();
            new Jetpack();
            new YBoost();
            new Coordinates();
            new InventoryMove();
            new Flight();
            new BounceFly();
            new JitterFlight();
            new TickedGlide();
            new Scaffold();
            new Tower();
            new Gamemode();
            new NoFall();
            new Phase();
            new NoSwing();
            new ClickTP();
            new Instabreak();
            new AutoRespawn();
            new Recall();
            new NoPacket(); //42
            new Freecam();
            new NoShadow();
            //new ServerCrasher(); <- Removed. 1. didnt work 2. UC doesnt allow it (luv u guys @ UC <3)
            new ClickUI();
            new TabGUI();
            new ModuleList();
            new TPFlight();
            //new ListTest();
            //new AntiSentinel();
            new AntiHive();
            new CpuLimiter();
            new RainbowUI();
            Console.WriteLine("Modules registered!");
            startModuleThread();
        }

        //uint tps = 0;
        //uint currentTick = 0;
        public void tickModuleThread()
        {
            foreach (Category category in CategoryHandler.registry.categories)
            {
                foreach (Module module in category.modules)
                {
                    try
                    {
                        module.onLoop().ConfigureAwait(false);
                        //currentTick++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }
        public void startModuleThread()
        {
            Console.WriteLine("Starting module thread..");
            Program.mainLoop += (object sen, EventArgs e) =>
            {
                tickModuleThread();
            };
            Console.WriteLine("Module thread started!");
        }

        private void RunAsync(Task task)
        {
            task.ContinueWith(t =>
            {
                Console.WriteLine("Unexpected Error, {0}", t.Exception);

            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
