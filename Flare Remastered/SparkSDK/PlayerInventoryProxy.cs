using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class PlayerInventoryProxy : SDKObj
    {
        public PlayerInventoryProxy(ulong addr) : base(addr)
        {
        }

        public Inventory inventory
        {
            get
            {
                return new Inventory(MCM.readInt64(addr + 0xA8));
            }
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
