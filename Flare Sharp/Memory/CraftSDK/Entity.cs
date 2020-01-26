using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Entity
    {
        UInt64 addr;
        public Entity(UInt64 addr)
        {
            this.addr = addr;
        }

        public int movedTick
        {
            get
            {
                UInt64[] movedTic = { 0x32C };
                return MCM.readInt(MCM.evaluatePointer(addr, movedTic));
            }
            set
            {
                UInt64[] movedTic = { 0x32C };
                MCM.writeInt(MCM.evaluatePointer(addr, movedTic), value);
            }
        }
    }
}
