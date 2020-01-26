using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Aimbot : Module
    {
        public Aimbot() : base("Aimbot", CategoryHandler.registry.categories[0], 'U', false)
        {
        }

        public static List<float> getCalculationsToPos(float[] localPos, float[] targetPos)
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

        public override void onTick()
        {
            base.onTick();
            List<Entity> Entity = EntityList.getEntityList();
            List<float> distances = new List<float>();
            float playerX, playerY, playerZ;
            float[] localPosition = { SDK.instance.player.X1, SDK.instance.player.Y1, SDK.instance.player.Z1 };
            foreach(Entity e in Entity)
            {
                float[] targetPosition = { e.currentX1, e.currentY1, e.currentZ1 };
                float dX = localPosition[0] - targetPosition[0];
                float dZ = localPosition[2] - targetPosition[2];
                double distance = Math.Sqrt(dX * dX + dZ * dZ);
                if (distance <= 12)
                {
                    distances.Add((float)distance);
                }
            }
            if(distances.Count() > 0)
            {
                distances.Sort();
                foreach (Entity e in Entity)
                {
                    float[] targetPosition = { e.currentX1, e.currentY1, e.currentZ1};
                    float dX = localPosition[0] - targetPosition[0];
                    float dZ = localPosition[0] - targetPosition[2];
                    double distance = Math.Sqrt(dX * dX + dZ * dZ);
                    if (distances[0] == (float)distance) Console.WriteLine("!");
                    List<float> staringPos = getCalculationsToPos(localPosition, targetPosition);
                    MCM.writeFloat(Pointers.mousePitch(), staringPos[0]);
                    MCM.writeFloat(Pointers.mouseYaw(), staringPos[1]);
                }
            }
        }
    }
}
