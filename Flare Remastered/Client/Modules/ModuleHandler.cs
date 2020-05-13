using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using Flare_Remastered.Client.Modules.Modules;
using Flare_Remastered.SparkSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Flare_Remastered.Client.Modules
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
            new Killaura();
            new Aimbot();
            new Hitbox();
            new Triggerbot();
            new BoostHit();
            new Criticals();
            new Misplace();
            new Reach();
            new RapidClick();
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
            new FastLadder();
            new AirAcceleration();
            new Velocity();
            new Jetpack();
            new YBoost();
            new Coordinates();
            new InventoryMove();
            new AutoWalk();
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
            new FOV();
            new AutoCrouch();
            new LagSpoof();
            new NoPacket();
            new Freecam();
            new NoShadow();
            new ClickUI();
            new TabGUI();
            new ModuleList();
            new TPFlight();
            new CoordinatesDisplay();
            Console.WriteLine("Modules registered!");
            startModuleTicker();

            OverlayHost.onRender += onRender;
        }

        private void onRender(object sender, PaintEventArgs e)
        {
            foreach (Category cat in CategoryHandler.registry.categories)
            {
                foreach (Module mod in cat.modules)
                {
                    if (mod.enabled)
                    {
                        if (mod is VisualModule)
                        {
                            VisualModule vmod = (VisualModule)mod;
                            vmod.onDraw(e.Graphics);
                        }
                    }
                }
            }
        }

        public void tickModules()
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
        public void startModuleTicker()
        {
            Console.WriteLine("Starting module ticker..");
            Program.mainLoop += (object sen, EventArgs e) =>
            {
                tickModules();
            };
            Console.WriteLine("Module ticker started!");
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
