using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class LocalPlayer
    {
        public UInt64 addr;
        public LocalPlayer(UInt64 addr)
        {
            this.addr = addr;
        }

        public int onGround
        {
            get {
                UInt64[] offs = { 0x178 };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x178 };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
    }
}
