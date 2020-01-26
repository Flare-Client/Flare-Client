using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    class LocalPlayer
    {
        public static Int64 player()
        {
            int[] offs = { 0xA8, 0x10, 0x40, 0x0 };
            return MCM.evaluatePointer(0x02FEE4B0, offs);
        }

        public static Int64 onGround()
        {
            int[] offs = { 0xA8, 0x10, 0x40, 0x0, 0x178 };
            return MCM.evaluatePointer(0x02FEE4B0, offs);
        }
    }
}
