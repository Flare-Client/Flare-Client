using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Velocity : Module
    {
        public Velocity() : base("Velocity", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Speed", 01, 05, 50);
        }

        public override void onTick()
        {
            base.onTick();
            float playerYaw = SDK.instance.player.yaw;

            if (KeybindHandler.isKeyDown('W'))
            {
                if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    playerYaw += 90F;
                }
                if (KeybindHandler.isKeyDown('A'))
                {
                    playerYaw += 45F;
                }
                else if (KeybindHandler.isKeyDown('D'))
                {
                    playerYaw += 135F;
                }
            }
            else if (KeybindHandler.isKeyDown('S'))
            {
                if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    playerYaw -= 90F;
                }
                if (KeybindHandler.isKeyDown('A'))
                {
                    playerYaw -= 45F;
                }
                else if (KeybindHandler.isKeyDown('D'))
                {
                    playerYaw -= 135F;
                }
            }
            else if (!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S'))
            {
                if (!KeybindHandler.isKeyDown('A') && KeybindHandler.isKeyDown('D')) playerYaw += 180F;
            }

            if (KeybindHandler.isKeyDown('W') | KeybindHandler.isKeyDown('A') | KeybindHandler.isKeyDown('D') | KeybindHandler.isKeyDown('S'))
            {
                float calcYaw = (playerYaw) * ((float)Math.PI / 180F);
                float calcPitch = (SDK.instance.player.pitch) * -((float)Math.PI / 180F);
                SDK.instance.player.velX = (float)Math.Cos(calcYaw) * sliderSettings[0].value / 10F;
                SDK.instance.player.velZ = (float)Math.Sin(calcYaw) * sliderSettings[0].value / 10F;
            }
        }
    }
}
