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
    public class BoostHit : Module
    {
        public BoostHit() : base("Boost Hit", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += keyHeldEvent;
            RegisterSliderSetting("Boost", 0, 20, 50);
        }

        public void keyHeldEvent(object sender, clientKeyEvent e)
        {
            if (enabled)
            {
                UInt64 facingEnt = SDK.instance.entityFacing.addr;
                if(facingEnt > 0 && e.key == (char)0x01)
                {
                    List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                    SDK.instance.player.velX = (float)sliderSettings[0].value / 10F * directionalVec[0];
                    SDK.instance.player.velZ = (float)sliderSettings[0].value / 10F * directionalVec[2];
                }
            }
        }
    }
}
