using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Jesus : Module
    {
        public Jesus() : base("Jesus", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Boost", 0, 02, 20);
        }

        public override void onTick()
        {
            base.onTick();
            if(Minecraft.clientInstance.localPlayer.isInWater > 0)
            {
                Minecraft.clientInstance.localPlayer.velY = (float)sliderSettings[0].value / 10;
            }
        }
    }
}
