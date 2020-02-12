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
    public class HighJump : Module
    {
        public HighJump() : base("HighJump", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += KeyHeldEvent;
            RegisterSliderSetting("Jump Height", 0, 06, 30);
        }

        public void KeyHeldEvent(object sender, clientKeyEvent e)
        {
            if (e.key == (char)0x20)
            {
                if (enabled)
                {
                    if (SDK.instance.player.isInAir > 1 | SDK.instance.player.onGround > 0) SDK.instance.player.velY = (float)sliderSettings[0].value / 10F;
                }
            }
        }
    }
}
