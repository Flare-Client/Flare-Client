using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules.Modules;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules
{
    public class ModuleHandler
    {
        public static ModuleHandler registry;
        public ModuleHandler()
        {
            registry = this;
            Console.WriteLine("Starting module register...");
            /* Register modules here */
            new Hitbox();
            new Aimbot();
            new Triggerbot();
            new Criticals();
            new AirJump();
            new AutoSprint();
            new PlayerSpeed();
            new NoSlowDown();
            new NoKnockBack();
            new NoWeb();
            new Step();
            new Coordinates();
            new Flight();
            new Scaffold();
            new Gamemode();
            new NoFall();
            new Phase();
            new NoSwing();
            new NoPacket();
            new Freecam();
            new ServerCrasher();
            new ClickUI();
            Console.WriteLine("Modules registered!");
            startModuleThread();
        }

        public void startModuleThread()
        {
            Console.WriteLine("Starting module thread..");
            Program.mainLoop += (object sen, EventArgs e) =>
            {
                foreach (Category category in CategoryHandler.registry.categories)
                {
                    foreach (Module module in category.modules)
                    {
                        module.onLoop();
                    }
                }
                new SDK();
            };
            Console.WriteLine("Module thread started!");
        }
    }
}
