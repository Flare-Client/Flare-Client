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

        public override void onTick()
        {
            base.onTick();
            List<Entity> Entity = EntityList.getEntityList();
            List<float> distances = new List<float>();
            float playerX, playerY, playerZ;
            playerX = SDK.instance.player.currentX1;
            playerY = SDK.instance.player.currentY1;
            playerZ = SDK.instance.player.currentZ1;
            foreach(Entity e in Entity)
            {
                float entityX = e.currentX1;
                float entityY = e.currentY1;
                float entityZ = e.currentZ1;
                float dX = playerX - entityX;
                float dY = playerY - entityY;
                float dZ = playerZ - entityZ;
                double distance = Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
                if (distance <= 12)
                {
                    distances.Add((float)distance);
                    Console.WriteLine("Added");
                }
            }
            distances.Sort();
            if(distances.Count() > 0)
            {
                foreach (Entity e in Entity)
                {
                    float entityX = e.currentX1;
                    float entityY = e.currentY1;
                    float entityZ = e.currentZ1;
                    float dX = playerX - entityX;
                    float dZ = playerZ - entityZ;
                    double distance = Math.Sqrt(dX * dX + dZ * dZ);
                    if ((float)distance == distances[0])
                    {
                        Console.WriteLine("!!!");
                    }
                }
            }
        }

        public override void onDisable()
        {
            base.onDisable();
        }
    }
}
