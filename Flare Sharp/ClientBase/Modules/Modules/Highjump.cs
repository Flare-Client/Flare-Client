using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
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
