using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class PlayerInventoryProxy : SDKObj
    {
        public PlayerInventoryProxy(ulong addr) : base(addr)
        {
        }

        public ulong selectedHotbarSlot
        {
            get
            {
                return MCM.readInt64(addr + 0x10);
            }
            set
            {
                MCM.writeInt64(addr + 0x10, value);
            }
        }
    }
}
