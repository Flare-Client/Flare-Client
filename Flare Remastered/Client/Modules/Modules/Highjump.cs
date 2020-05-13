using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class HighJump : Module
    {
        public HighJump() : base("HighJump", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += KeyHeldEvent;
            RegisterSliderSetting("Jump Height", 0, 06, 30);
        }

        public void KeyHeldEvent(object sender, clientKeyEvent e)
        {
            if (e.key == (char)0x20)
            {
                if (enabled)
                {
                    if (Minecraft.clientInstance.localPlayer.isInAir > 1 | Minecraft.clientInstance.localPlayer.onGround > 0) Minecraft.clientInstance.localPlayer.velY = (float)sliderSettings[0].value / 10F;
                }
            }
        }
    }
}
