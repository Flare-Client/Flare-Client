using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Scaffold : Module
    {
        public Scaffold() : base("Scaffold", CategoryHandler.registry.categories[2], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.blockFace, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x41, 0x88, 0x86, 0x54, 0x08, 0x00, 0x00 };
            MCM.writeBaseBytes(Pointers.blockFace, write);
        }
    }
}
