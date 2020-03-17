using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class YBoost : Module
    {
        public YBoost() : base("YBoost", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Boost", 0, 10, 100);
        }

        public override void onEnable()
        {
            base.onEnable();
            Minecraft.clientInstance.localPlayer.velY += (float)sliderSettings[0].value / 10;
            this.enabled = false;
        }
    }
}
