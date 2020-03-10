using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AirAcceleration : Module
    {
        public AirAcceleration() : base("AirAcceleration", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Acceleration", 0, 5, 20);
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.airAcceleration = (float)sliderSettings[0].value / 100;
        }
    }
}
