using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class SDK
    {
        public static SDK instance;
        public LocalPlayer player;
        public SDK()
        {
            instance = this;
            UInt64[] offs = { 0xA8, 0x10, 0x40, 0x0 };
            player = new LocalPlayer(MCM.baseEvaluatePointer(0x02FEE4B0, offs));
        }

        public UInt64 entityFacing
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 };
                return MCM.readInt64(MCM.baseEvaluatePointer(0x02FEE4B0, offs));
            }
        }
    }
}
