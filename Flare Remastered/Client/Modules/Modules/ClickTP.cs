using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
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
