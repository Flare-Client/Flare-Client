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
            RegisterSliderSetting("Range", 0, 120, 500);
        }


        public override void onTick()
        {
            base.onTick();
            List<Entity> Entity = EntityList.getEntityList(true);
            List<double> distancesArr = new List<double>();

            foreach(Entity e in Entity)
            {
                Double distance = e.distanceTo(SDK.instance.player);
                if (distance <= sliderSettings[0].value / 10F) distancesArr.Add(distance);
            }

            if(distancesArr.Count() > 0)
            {
                distancesArr.Sort();

                foreach(Entity e in Entity)
                {
                    if(e.distanceTo(SDK.instance.player) == distancesArr[0])
                    {
                        float[] localPosition = { SDK.instance.player.currentX2, SDK.instance.player.currentY2, SDK.instance.player.currentZ2 };
                        float[] targetPosition = { e.currentX3, e.currentY3, e.currentZ3 };
                        List<float> calculationsArr = SDK.instance.getCalculationsToPos(localPosition, targetPosition);
                        Pointers.mousePitch = calculationsArr[0];
                        Pointers.mouseYaw = calculationsArr[1];
                    }
                }
            }
        }
    }
}
