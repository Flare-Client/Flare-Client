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
            vec2.x = -((float)Math.Atan2(dY, (float)distance) * (float)3.13810205 / (float)3.141592653589793);
            vec2.y = -((float)Math.Atan2(dZ, dX) * (float)3.13810205 / (float)3.141592653589793) + (float)1.569051027;
            return vec2;
        }
        
        public static double distanceBetween(Vec3f localPos, Vec3f targetPos)
        {
            float dX = localPos.x - targetPos.x;
            float dY = localPos.y - targetPos.y;
            float dZ = localPos.z - targetPos.z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }

        public static Vec3f posBetween(Vec3f localPos, Vec3f targetPos)
        {
            float dX = localPos.x + targetPos.x;
            float dY = localPos.y + targetPos.y;
            float dZ = localPos.z + targetPos.z;
            Vec3f newPos = new Vec3f()
            {
                x = dX / 2,
                y = dY / 2,
                z = dZ / 2
            };
            return newPos;
        }

        public static float generateRandomFloat(float minimumFloat, float maxFloat)
        {
            Random random = new Random();
            return (float)random.Next((int)minimumFloat, (int)maxFloat);
        }

        public static Mob getClosestEntity(List<Mob> EntitiesArr)
        {
            List<double> distances = new List<double>();

            foreach(Mob currEnt in EntitiesArr)
            {
                distances.Add(currEnt.distanceTo(Minecraft.clientInstance.localPlayer));
            }

            if(distances.Count() > 0)
            {
                distances.Sort();

                foreach (Mob ent in EntitiesArr)
                {
                    if (ent.distanceTo(Minecraft.clientInstance.localPlayer) == distances[0]) return ent;
                }
            }

            return (Mob)null;
        }
    }
}
