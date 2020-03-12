using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class ItemStack : SDKObj
    {
        public ItemStack(ulong addr) : base(addr){}
        public List<Item> items
        {
            get
            {

            }
        }
        public byte stackSize
        {
            get
            {
                return MCM.readByte(addr + 0x22);
            }
            set
            {
                MCM.writeByte(addr + 0x22, value);
            }
        }
    }
}
