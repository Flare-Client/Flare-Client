using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

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
