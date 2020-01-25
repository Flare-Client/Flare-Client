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
        public List<Module> modules = new List<Module>();
        public ModuleHandler()
        {
            registry = this;
            Console.WriteLine("Starting module register...");
            /* Register modules here */
            modules.Add(new AirJump());
            Console.WriteLine("Modules registered!");
            startModuleThread();
        }

        public void enableModule(string name)
        {
            foreach(Module module in modules)
            {
                if (module.name==name)
                {
                    module.onEnable();
                }
            }
        }
        public void enableModule(int id)
        {
            modules[id].onEnable();
        }

        public void startModuleThread()
        {
            Console.WriteLine("Starting module thread..");
            Thread moduleThread = new Thread(() =>
            {
                while (true)
                {
                    foreach (Module module in modules)
                    {
                        if (module.enabled)
                        {
                            module.onTick();
                        }
                    }
                }
            });
            moduleThread.Start();
            Console.WriteLine("Module thread started!");
        }
    }
}
