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

        public List<float> directionalVector(float yaw, float pitch)
        {
            List<float> calculations = new List<float>();
            calculations.Add((float)Math.Cos(yaw) * (float)Math.Cos(pitch));
            calculations.Add((float)Math.Sin(pitch));
            calculations.Add((float)Math.Sin(yaw) * (float)Math.Cos(pitch));
            return calculations;
        }

        public List<float> getCalculationsToPos(float[] localPos, float[] targetPos)
        {
            List<float> calculations = new List<float>();

            float dX = localPos[0] - targetPos[0];
            float dY = localPos[1] - targetPos[1];
            float dZ = localPos[2] - targetPos[2];
            double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
            float pitch = ((float)Math.Atan2(dY, (float)distance) * (float)3.13810205 / (float)3.141592653589793);
            float yaw = ((float)Math.Atan2(dZ, dX) * (float)3.1381025 / (float)3.141592653589793) + (float)-1.569051027;
            calculations.Add(-pitch);
            calculations.Add(-yaw);
            return calculations;
        }
    }
}
