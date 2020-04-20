using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class ClientInstance : SDKObj
    {
        public ClientInstance(ulong addr) : base(addr)
        {
        }

        public Game gameInstance
        {
            get
            {
                return new Game(MCM.readInt64(addr + 0x60));
            }
        }
        public LocalPlayer localPlayer
        {
            get
            {
                return new LocalPlayer(MCM.readInt64(addr + 0xF0));
            }
        }
        public LoopbackPacketSender loopbackPacketSender
        {
            get
            {
                return new LoopbackPacketSender(MCM.readInt64(addr + 0x88));
            }
        }
        public FirstPersonLookBehavior firstPersonLookBehavior
        {
            get
            {
                return new FirstPersonLookBehavior(MCM.evaluatePointer(addr + 0xE0, MCM.ceByte2uLong("28 38 168 0 0")));
            }
        }
        public FloatOption floatOption
        {
            get
            {
                return new FloatOption(MCM.evaluatePointer(addr + 0xC8, MCM.ceByte2uLong("B8 120 0")));
            }
        }
        public VanillaMoveInputHandler vanillaMoveInputHandler
        {
            get
            {
                return new VanillaMoveInputHandler(MCM.readInt64(addr + 0xA0));
            }
        }
    }
}
