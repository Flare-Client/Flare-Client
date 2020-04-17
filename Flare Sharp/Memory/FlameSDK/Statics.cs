using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class Statics
    {
        public static int attackSwing = 0x10809BE; //v1.14.6
        public static int handSwingPacket = 0x0; //Update soon
        public static int rapidPlace = 0x1080940; //v1.14.6
        public static int autoSprint = 0x1ABC1E0; //v1.14.6
        public static int criticalsPacket = 0x102D926; //v1.14.6
        public static int showCoordinates = 0x6532CF; //v1.14.6 (Idk why I updated this as we are using game rules now)
        public static int blockFace = 0x0; //Update soon
        public static int noPacket = 0xFF3E6D; //v1.14.6
        public static int movementPacket = 0x900617; //v1.14.6
        public static int NoSlowDown1 = 0x0; //Update soon
        public static int NoSlowDown2 = 0x0; //Update soon
        public static int NoKnockBack = 0x126D0C2;
        public static int webTick = 0x1211905;
        public static int ladderUp = 0x13D7430;
        public static int ladderDown = 0x13CD065;
        public static int inWaterTick = 0x1222DAD;
        public static int survivalReachCmp = 0x626171; //v1.14.6
        public static int blockBreak = 0x14A6125;
        public static int shadowRenderer = 0xA17A85;
    }
}
