using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class FOV : Module
    {
        float savedFOV;
        public FOV() : base("FOV", CategoryHandler.registry.categories[2], 'C', false)
        {
            RegisterSliderSetting("FOV Value", 10, 10, 3000);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedFOV = Minecraft.clientInstance.floatOption.playerFOV;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.floatOption.playerFOV = (float)sliderSettings[0].value / 10F;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.floatOption.playerFOV = savedFOV;
        }
    }
}
