using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Pointers
    {
        public static UInt64 entityFacing()
        {
            UInt64[] offs = { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 };
            return MCM.baseEvaluatePointer(0x02FEE4B0, offs);
        }
        public static Int64 attackSwing()
        {
            return 0x102460E;
        }
        public static UInt64 mousePitch()
        {
            UInt64[] offs = { 0x30, 0xE0, 0x28, 0x30, 0x168, 0x0, 0x14 };
            return MCM.baseEvaluatePointer(0x03016010, offs);
        }
        public static UInt64 mouseYaw()
        {
            UInt64[] offs = { 0x30, 0xE0, 0x28, 0x30, 0x168, 0x0, 0x10 };
            return MCM.baseEvaluatePointer(0x03016010, offs);
        }
        public static UInt64 playerSpeed()
        {
            UInt64[] offs = { 0x30, 0xF0, 0x410, 0x18, 0xE0, 0x8, 0x9C };
            return MCM.baseEvaluatePointer(0x03016010, offs);
        }
        public static UInt64 UI()
        {
            UInt64[] offs = { 0x200, 0x128, 0x40, 0x8, 0x248 };
            return MCM.baseEvaluatePointer(0x02FA94F0, offs);
        }
    }
}
