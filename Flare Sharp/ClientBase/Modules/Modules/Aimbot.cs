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
        public Aimbot() : base("Aimbot", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            float[] localPosition = { SDK.instance.player.currentX1, SDK.instance.player.currentY1, SDK.instance.player.currentZ1 };
            List<Entity> Entity = EntityList.getEntityList();
            List<double> distances = new List<double>();
            foreach (Entity e in Entity)
            {
                float[] targetPosition = { e.currentX1, e.currentY1, e.currentZ1 };
                float dX = localPosition[0] - targetPosition[0];
                float dY = localPosition[1] - targetPosition[1];
                float dZ = localPosition[2] - targetPosition[2];
                double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
                if (distance <= 12)
                {
                    distances.Add(distance);
                }
            }
            if(distances.Count() > 0)
            {
                distances.Sort();
                foreach(Entity e in Entity)
                {
                    float[] targetPosition = { e.currentX1, e.currentY1, e.currentZ1 };
                    float dX = localPosition[0] - targetPosition[0];
                    float dY = localPosition[1] - targetPosition[1];
                    float dZ = localPosition[2] - targetPosition[2];
                    double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
                    if(distance == distances[0])
                    {
                        List<float> staringPos = SDK.instance.getCalculationsToPos(localPosition, targetPosition);
                        MCM.writeFloat(Pointers.mousePitch(), staringPos[0]);
                        MCM.writeFloat(Pointers.mouseYaw(), staringPos[1]);
                    }
                }
            }
        }
    }
}
