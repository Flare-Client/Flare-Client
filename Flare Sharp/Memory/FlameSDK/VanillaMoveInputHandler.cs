using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class VanillaMoveInputHandler : SDKObj
    {
        public VanillaMoveInputHandler(ulong addr) : base(addr)
        {
        }

        public byte isCrouching
        {
            get
            {
                return MCM.readByte(addr + 0x48);
            }
            set
            {
                MCM.writeByte(addr + 0x48, value);
            }
        }
    }
}
