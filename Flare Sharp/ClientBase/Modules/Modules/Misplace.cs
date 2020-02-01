using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Misplace : Module
    {
        public Misplace() : base("Misplace", CategoryHandler.registry.categories[0], '-', false)
        {

        }

        public override void onTick()
        {
            base.onTick();
            foreach (Entity e in EntityList.getEntityList())
            {
                if (e.distanceTo(SDK.instance.player) < 2)
                {
                    continue;
                }
                if (e.distanceTo(SDK.instance.player) <= 12) {
                    float lpX = SDK.instance.player.X1;
                    float lpY = SDK.instance.player.Y1;
                    float lpZ = SDK.instance.player.Z1;

                    Console.WriteLine("Player:    " + lpX + ", " + lpY + ", " + lpZ);

                    float eX = e.currentX3;
                    float eY = e.currentY3;
                    float eZ = e.currentZ3;

                    Console.WriteLine("Target:    " + eX + ", " + eY + ", " + eZ);

                    float mpX = (lpX + eX) / 2;
                    float mpZ = (lpZ + eZ) / 2;

                    Console.WriteLine("ToPos:    " + mpX + ", " + eY + ", " + mpZ);

                    Console.WriteLine("TargetAddress: " + e.addr.ToString("X"));
                    e.teleportE(mpX, lpY, mpZ);
                }
            }
        }
    }
}
