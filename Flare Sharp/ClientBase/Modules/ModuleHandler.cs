using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.ClientBase.Modules.Modules;
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
            new AirJump();
            Console.WriteLine("Modules registered!");
            startModuleThread();
        }

        public void startModuleThread()
        {
            Console.WriteLine("Starting module thread..");
            Thread moduleThread = new Thread(() =>
            {
                while (true)
                {
                    foreach(Category category in CategoryHandler.registry.categories)
                    {
                        foreach (Module module in category.modules)
                        {
                            if (module.enabled)
                            {
                                module.onTick();
                            }
                        }
                    }
                }
            });
            moduleThread.Start();
            Console.WriteLine("Module thread started!");
        }
    }
}
