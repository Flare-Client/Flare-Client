using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Entity
    {
        public UInt64 addr;
        public Entity(UInt64 addr)
        {
            this.addr = addr;
        }

        public string type
        {
            get
            {
                UInt64[] offs = { 0x388 };
                return MCM.readString(MCM.evaluatePointer(addr, offs), 20);
            }
        }
    }
}
