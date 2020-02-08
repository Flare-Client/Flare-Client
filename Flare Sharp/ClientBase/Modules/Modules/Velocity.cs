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
        public int velocityCounter;
        public Velocity() : base("Velocity", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Speed", 10, 10, 50);
        }

        public async Task multiplyVelocity()
        {
            await Task.Delay(20);
            if (enabled)
            {
                if (KeybindHandler.isKeyDown('W') | KeybindHandler.isKeyDown('S') | KeybindHandler.isKeyDown('A') | KeybindHandler.isKeyDown('D'))
                {
                    try {
                        if (SDK.instance.player.onGround > 0)
                        {
                            SDK.instance.player.velX *= sliderSettings[0].value / 10;
                            SDK.instance.player.velZ *= sliderSettings[0].value / 10;
                        }
                    } catch (Exception)
                    {
                    }
                }
                await multiplyVelocity();
            }
        }

        public override void onEnable()
        {
            base.onEnable();
            multiplyVelocity();
        }
    }
}
