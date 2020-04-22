using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class PlayerSpeed : Module
    {
        float savedSpeed;
        public PlayerSpeed() : base("Speed", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterFloatSliderSetting("Speed", 0.2F, 1F, 5F);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedSpeed = Minecraft.clientInstance.localPlayer.playerAttributes.playerSpeed;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.playerAttributes.playerSpeed = savedSpeed;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.playerAttributes.playerSpeed = sliderFloatSettings[0].value;
        }
    }
}
