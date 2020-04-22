using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class FOV : Module
    {
        float savedFOV;
        public FOV() : base("FOV", CategoryHandler.registry.categories[2], 'C', false)
        {
            RegisterFloatSliderSetting("FOV", 0F, 3F, 300F);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedFOV = Minecraft.clientInstance.floatOption.playerFOV;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.floatOption.playerFOV = sliderFloatSettings[0].value;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.floatOption.playerFOV = savedFOV;
        }
    }
}
