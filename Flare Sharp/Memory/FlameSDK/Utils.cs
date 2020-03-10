using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class Utils
    {
        public struct Vec3f
        {
            public float x;
            public float y;
            public float z;
        }
        public struct Vec2f
        {
            public float x;
            public float y;
        }

        public static Vec3f directionalVector(float yaw, float pitch)
        {
            Vec3f vec3 = new Vec3f();
            vec3.x = (float)Math.Cos(yaw) * (float)Math.Cos(pitch);
            vec3.y = (float)Math.Sin(pitch);
            vec3.z = (float)Math.Sin(yaw) * (float)Math.Cos(pitch);
            return vec3;
        }

        public static Vec2f getCalculationsToPos(Vec3f localPos, Vec3f targetPos)
        {
            Vec2f vec2 = new Vec2f();
            float dX = localPos.x - targetPos.x;
            float dY = localPos.y - targetPos.y;
            float dZ = localPos.z - targetPos.z;
            double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
            float pitch = ((float)Math.Atan2(dY, (float)distance) * (float)3.13810205 / (float)3.141592653589793);
            float yaw = ((float)Math.Atan2(dZ, dX) * (float)3.1381025 / (float)3.141592653589793) + (float)-1.569051027;
            vec2.x = -pitch;
            vec2.y = -yaw;
            return vec2;
        }
    }
}
