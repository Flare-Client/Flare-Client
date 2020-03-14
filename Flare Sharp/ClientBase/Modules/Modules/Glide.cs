using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Glide : Module
    {
        public Glide() : base("Glide", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Value", -30, 0, 30);
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.velY = sliderSettings[0].value;
        }
    }
}
