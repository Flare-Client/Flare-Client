using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ClickTP : Module
    {
        public ClickTP() : base("ClickTP", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            KeybindHandler.clientKeyDownEvent += DownKeyHeld;
        }

        public void DownKeyHeld(object sender, clientKeyEvent e)
        {
            if (enabled)
            {
                if(e.key == (char)0x02)
                {
                    if(Minecraft.clientInstance.localPlayer.level.lookingBlockY > 0)
                    {
                        Minecraft.clientInstance.localPlayer.teleport((float)Minecraft.clientInstance.localPlayer.level.lookingBlockX, (float)Minecraft.clientInstance.localPlayer.level.lookingBlockY + 1, (float)Minecraft.clientInstance.localPlayer.level.lookingBlockZ);
                    }
                }
            }
        }
    }
}
