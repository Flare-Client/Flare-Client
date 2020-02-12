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
            RegisterSliderSetting("Speed", 00, 010, 100);
        }

        public override void onTick()
        {
            base.onTick();
            if(!KeybindHandler.isKeyDown((char)0x20) && SDK.instance.player.isInAir != 0 | !KeybindHandler.isKeyDown((char)0x20) && SDK.instance.player.onGround != 0)
            {
                if (KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S') && !KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 90) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (!KeybindHandler.isKeyDown('W') && KeybindHandler.isKeyDown('S') && !KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -90) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S') && KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (!KeybindHandler.isKeyDown('S') && !KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('A') && KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 180) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (KeybindHandler.isKeyDown('W') && KeybindHandler.isKeyDown('A'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 70) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (KeybindHandler.isKeyDown('W') && KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 110) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (KeybindHandler.isKeyDown('S') && KeybindHandler.isKeyDown('D'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -110) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
                else if (KeybindHandler.isKeyDown('S') && KeybindHandler.isKeyDown('A'))
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -70) * (float)Math.PI / 178F, (float)Math.PI / 178F);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 100F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 100F * directionalVec[2];
                }
            }
        }
    }
}
