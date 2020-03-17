using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class SDK
    {
        public static SDK instance;
        public static ClientInstance client;
        public SDK()
        {
            instance = this;
            ulong[] offs = { 0x30, 0x0 };
            client = new ClientInstance(MCM.baseEvaluatePointer(0x03022AE0, offs));
        }

        public bool IsOnMainMenu()
        {
            return MCM.readBaseByte(0x2FFBDD8) > 0;
        }
        public bool IsOnAMenu()
        {
            bool ret = MCM.readInt(MCM.baseEvaluatePointer(0x02FF5FD0, MCM.ceByte2uLong("1E8 CB0"))) > 0;
            //Console.WriteLine(ret);
            return ret;
        }

        //public bool IsAMenuOpen()
        //{
        //    UInt64[] offs = { 0x1E8, 0xCB0 };
        //    int value = MCM.readInt(MCM.baseEvaluatePointer(0x02FF5FD0, offs));
        //    //Console.WriteLine(value.ToString("X"));
        //    return value > 0;
        //}
        
        public bool GetKeyState(char key)
        {
            UInt64[] offs = { 0x174+(UInt64)key };
            return MCM.readByte(MCM.baseEvaluatePointer(0x029D9AA0, offs))>0;
        }
        

        public bool GetMouseState(int mb)
        {
            UInt64[] offs = { 0x998, 0x8, 0x4F + (UInt64)mb };
            return MCM.readByte(MCM.baseEvaluatePointer(0x03022480, offs)) > 0;
        }
        public Entity entityFacing
        {
            get
            {
                UInt64[] offs = { 0xA8, 0x10, 0x870 };
                return new Entity(MCM.readInt64(MCM.baseEvaluatePointer(0x02FFAF50, offs)));
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
