using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
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
