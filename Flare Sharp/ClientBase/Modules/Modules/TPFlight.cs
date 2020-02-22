using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TPFlight : Module
    {
        int delayCount = 0;
        public TPFlight():base("TPFlight", CategoryHandler.registry.categories[1], 0x07, false)
        {
            RegisterSliderSetting("Speed", 0, 10, 500);
            RegisterSliderSetting("Delay", 0, 100, 500);
        }
        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.velX = 0;
            SDK.instance.player.velY = 0;
            SDK.instance.player.velZ = 0;
            if (delayCount >= sliderSettings[1].value)
            {
                List<float> directionalVec = SDK.instance.player.lookingVec;
                SDK.instance.player.teleport(SDK.instance.player.X1 + sliderSettings[0].value / 10 * directionalVec[0], SDK.instance.player.Y1 + sliderSettings[0].value / 10 * -directionalVec[1], SDK.instance.player.Z1 + sliderSettings[0].value / 10 * directionalVec[2]);
                delayCount = 0;
            }
            delayCount++;
        }
    }
}
