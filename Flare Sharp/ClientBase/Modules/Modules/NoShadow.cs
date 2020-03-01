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
    public class NoShadow : Module
    {
        public NoShadow() : base("NoShadow", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.shadowRenderer, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xEB, 0x1B };
            MCM.writeBaseBytes(Pointers.shadowRenderer, write);
        }

    }
}
