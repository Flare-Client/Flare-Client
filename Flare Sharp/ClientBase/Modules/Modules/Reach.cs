using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Reach : Module
    {
        public Reach() : base("Reach", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.survivalReachCmp, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x74, 0x13 };
            MCM.writeBaseBytes(Pointers.survivalReachCmp, write);
        }
    }
}
