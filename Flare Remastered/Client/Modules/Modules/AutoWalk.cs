using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flare_Remastered.Client.Modules.Modules
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
