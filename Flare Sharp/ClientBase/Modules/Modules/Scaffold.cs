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
            byte[] write1 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            byte[] write2 = { 0x41, 0x80, 0x38, 0x01, 0x74, 0x76 };
            MCM.writeBaseBytes(Pointers.blockFace, write1);
            MCM.writeBaseBytes(Pointers.rapidPlace, write2);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write1 = { 0x41, 0x88, 0x86, 0x54, 0x08, 0x00, 0x00 };
            byte[] write2 = { 0x41, 0x80, 0x38, 0x00, 0x74, 0x76 };
            MCM.writeBaseBytes(Pointers.blockFace, write1);
            MCM.writeBaseBytes(Pointers.rapidPlace, write2);
        }
    }
}
