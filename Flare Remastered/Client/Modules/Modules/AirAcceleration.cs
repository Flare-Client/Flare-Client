using Flare_Remastered.SparkSDK;
using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
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
