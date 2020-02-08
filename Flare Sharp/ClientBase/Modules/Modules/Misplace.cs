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
        public Misplace() : base("Misplace", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterSliderSetting("Range", 0, 120, 640);
            RegisterSliderSetting("Entity Expansion", 0, 20, 60);
        }

        bool doubleMp = false;
        public override void onTick()
        {
            base.onTick();
            foreach (Entity e in EntityList.getEntityList())
            {
                if (e.distanceTo(SDK.instance.player) < 2)
                {
                    continue;
                }

                float lpX = SDK.instance.player.X1;
                float lpY = SDK.instance.player.Y1;
                float lpZ = SDK.instance.player.Z1;

                float eX = e.currentX3;
                float eY = e.currentY3;
                float eZ = e.currentZ3;

                float mpX = (lpX + eX) / sliderSettings[1].value / 10;
                float mpY = ((lpY + eY) / sliderSettings[1].value / 10) - 1;
                float mpZ = (lpZ + eZ) / sliderSettings[1].value / 10;

                if (doubleMp)
                {
                    mpX = (mpX + lpX) / sliderSettings[1].value / 10;
                    mpY = ((mpY + lpY) / sliderSettings[1].value / 10);
                    mpZ = (mpZ + lpZ) / sliderSettings[1].value / 10;
                }
                if (e.distanceTo(SDK.instance.player) <= sliderSettings[0].value/10) {
                    e.teleportE(mpX, mpY, mpZ);
                }
            }
        }
    }
}
