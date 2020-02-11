using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Pointers
    {
        public static UInt64 mousePitch()
        {
            UInt64[] offs = { 0x30, 0xE0, 0x28, 0x38, 0x168, 0x0, 0x14 };
            return MCM.baseEvaluatePointer(0x03022AE0, offs);
        }
        public static UInt64 mouseYaw()
        {
            UInt64[] offs = { 0x30, 0xE0, 0x28, 0x38, 0x168, 0x0, 0x10 };
            return MCM.baseEvaluatePointer(0x03022AE0, offs);
        }
        public static UInt64 playerSpeed()
        {
            UInt64[] offs = { 0x30, 0xF8, 0x410, 0x18, 0x1F8, 0x9C };
            return MCM.baseEvaluatePointer(0x03022AE0, offs);
        }
        public static int blockSide
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x854 };
                return MCM.readInt(MCM.baseEvaluatePointer(0x02FFAF50, offs));
            }
            set
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x854 };
                MCM.writeInt(MCM.baseEvaluatePointer(0x02FFAF50, offs), value);
            }
        }
        public static int blockPosX
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x858 };
                return MCM.readInt(MCM.baseEvaluatePointer(0x02FFAF50, offs));
            }
            set
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x858 };
                MCM.writeInt(MCM.baseEvaluatePointer(0x02FFAF50, offs), value);
            }
        }
        public static int blockPosY
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x85C };
                return MCM.readInt(MCM.baseEvaluatePointer(0x02FFAF50, offs));
            }
            set
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x85C };
                MCM.writeInt(MCM.baseEvaluatePointer(0x02FFAF50, offs), value);
            }
        }
        public static int blockPosZ
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x860 };
                return MCM.readInt(MCM.baseEvaluatePointer(0x02FFAF50, offs));
            }
            set
            {
                UInt64[] offs = { 0xA8, 0x18, 0x130, 0x6F0, 0x0, 0x860 };
                MCM.writeInt(MCM.baseEvaluatePointer(0x02FFAF50, offs), value);
            }
        }
        public static int attackSwing = 0x102E23E; //v1.14.3
        public static int handSwingPacket = 0x8AADBF; //v1.14.3
        public static int rapidPlace = 0x102E1C0; //v1.14.3
        public static int autoSprint = 0x1A652C0; //v1.14.3
        public static int criticalsPacket = 0xFDBC66; //v1.14.3
        public static int showCoordinates = 0x6029FD; //v1.14.3
        public static int blockFace = 0x5D53C2; //v1.14.3
        public static int noPacket = 0xFA21DD; //v1.14.3
        public static int movementPacket = 0x8AD747; //V1.14.3
        public static int NoSlowDown1 = 0x1A653C9; //v1.14.3
        public static int NoSlowDown2 = 0xF7C376; //v1.14.3
        public static int NoKnockBackX = 0x121A8D2; //v1.14.3
        public static int NoKnockBackY = 0x121A8DB; //v1.14.3
        public static int NoKnockBackZ = 0x121A8E4; //v1.14.3
        public static int webTick = 0x1211905; //v1.14.3
        public static int ladderUp = 0x13D7430; //V1.14.3
        public static int ladderDown = 0x13CD065; //V1.14.3
        public static int inWaterTick = 0x1222DAD; //V1.14.3
        public static int survivalReachCmp = 0x5D58B1; //V1.14.3
        public static int blockBreak = 0x14A6125; //V1.14.3
    }
}
