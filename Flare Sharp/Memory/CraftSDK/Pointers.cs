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
        public static int autoSprint = 0x1A5B8F0;
        public static int criticalsPacket = 0xFD1E56;
        public static int showCoordinates = 0x5FF84D;
        public static int blockFace = 0x5D2412;
        public static int noPacket = 0xF984ED;
        public static int movementPacket = 0xF9508B;
        public static int invalidMovementPacket = 0xFD1E2B;
        public static int NoSlowDown1 = 0x1A5B9F9;
        public static int NoSlowDown2 = 0xF72506;
        public static int NoKnockBackX = 0x1210362;
        public static int NoKnockBackY = 0x121036B;
        public static int NoKnockBackZ = 0x1210374;
        public static int webTick = 0x12073A5;
    }
}
