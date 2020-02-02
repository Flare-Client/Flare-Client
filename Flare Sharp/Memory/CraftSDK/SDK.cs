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
            UInt64[] offs = { 0x30, 0xF0, 0x428, 0x88 };
            player = new LocalPlayer(MCM.baseEvaluatePointer(0x03020990, offs));
        }

        public UInt64 entityFacingMP
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x540, 0x0, 0x870 };
                return MCM.readInt64(MCM.baseEvaluatePointer(0x02FF8E38, offs));
            }
        }
        public UInt64 entityFacingSP
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x10, 0x870 };
                return MCM.readInt64(MCM.baseEvaluatePointer(0x02FF8E38, offs));
            }
        }
    }
}
