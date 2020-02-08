using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class HoverFlight : Module
    {
        public int Counter;
        public int Counter2;

        public HoverFlight() : base("HoverFlight", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            RegisterSliderSetting("YBoost", 0, 4, 10);
            RegisterSliderSetting("YCollapse", -10, -2, 0);
            RegisterSliderSetting("Speed", 0, 4, 10);
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.velY = 0F;

            Counter++;
            Counter2++;

            if (Counter == 1)
            {

                if (KeybindHandler.isKeyDown('W'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 89.9f) * (float)Math.PI / 178F, SDK.instance.player.pitch * (float)Math.PI / 178F);
                    SDK.instance.player.velX = sliderSettings[2].value / 10F * directionalVec[0];
                    SDK.instance.player.velZ = sliderSettings[2].value / 10F * directionalVec[2];
                }
                if (Counter2 > 50)
                {
                    SDK.instance.player.teleport(SDK.instance.player.X1, SDK.instance.player.Y1 + sliderSettings[0].value, SDK.instance.player.Z1);
                    Counter2 = 0;
                }
            }

            if (Counter >= 2)
            {
                SDK.instance.player.velY = sliderSettings[1].value;
                Counter = 0;
            }
        }
    }
}
