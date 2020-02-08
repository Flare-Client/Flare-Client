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

        public HoverFlight() : base("HoverFlight", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.velY = 0F;

            Counter += 1;

            if (Counter == 1)
            {

                if (KeybindHandler.isKeyDown('W'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 89.9f) * (float)Math.PI / 178F, SDK.instance.player.pitch * (float)Math.PI / 178F);
                    SDK.instance.player.velX = 0.4F * directionalVec[0];
                    SDK.instance.player.velZ = 0.4F * directionalVec[2];
                }

                SDK.instance.player.velY = 0.3F;
            }

            if (Counter == 2)
            {
                SDK.instance.player.velY = -0.3F;
            }

            if (Counter == 3)
            {
                SDK.instance.player.velY = 0.7F;
            }

            if (Counter == 4)
            {
                SDK.instance.player.velY = -0.7F;
                Counter = 0;
            }

        }
    }
}
