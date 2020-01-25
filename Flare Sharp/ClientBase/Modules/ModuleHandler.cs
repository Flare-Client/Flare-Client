using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules
{
    public class ModuleHandler
    {
        public static ModuleHandler registry;
        public List<IModule> modules;
        public ModuleHandler()
        {
            registry = this;
            Console.WriteLine("Starting module register...");
            /* Register modules here */
            Console.WriteLine("Modules registered!");
        }
    }
}
