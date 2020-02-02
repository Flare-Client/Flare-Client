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
    public class NoPacket : Module
    {
        public NoPacket() : base("NoPacket", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.noPacket, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x80, 0xB8, 0x31, 0x03, 0x00, 0x00, 0x00 };
            MCM.writeBaseBytes(Pointers.noPacket, write);
        }
    }
}
