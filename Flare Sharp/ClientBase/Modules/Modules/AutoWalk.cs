using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using static Flare_Sharp.Memory.FlameSDK.Utils;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AutoWalk : Module
    {
        public AutoWalk() : base("Autowalk", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterFloatSliderSetting("Speed", 0F, 1F, 50F);
        }

        public override void onTick()
        {
            base.onTick();
            float calcYaw = (Minecraft.clientInstance.localPlayer.yaw + 90F) * ((float)Math.PI / 180F);
            Minecraft.clientInstance.localPlayer.velX = (float)Math.Cos(calcYaw) * sliderFloatSettings[0].value;
            Minecraft.clientInstance.localPlayer.velZ = (float)Math.Sin(calcYaw) * sliderFloatSettings[0].value;
        }
    }
}
