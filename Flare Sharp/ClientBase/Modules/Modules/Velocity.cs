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
            RegisterSliderSetting("Sideways Speed", 00, 010, 100);
        }

        public override void onTick()
        {
            base.onTick();
            if (!KeybindHandler.isKeyDown((char)0x20) && SDK.instance.player.isInAir != 0 | !KeybindHandler.isKeyDown((char)0x20) && SDK.instance.player.onGround != 0)
            {
                List<float> directionalVec;
                float directionalVelocity = sliderSettings[0].value / 10F;
                float sidewayVelocity = sliderSettings[1].value / 10F;

                if (KeybindHandler.isKeyDown('W'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D')) //Only W input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)directionalVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)directionalVelocity * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('A')) //W & A input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('D')) //W & D input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                }
                else if (KeybindHandler.isKeyDown('S'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D')) //Only S input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('A')) //S & A input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('D')) //S & D input
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                } else if(!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S'))
                {
                    if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    } else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 180) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = (float)sidewayVelocity * directionalVec[0];
                        SDK.instance.player.velZ = (float)sidewayVelocity * directionalVec[2];
                    }
                }
            }
        }
    }
}
