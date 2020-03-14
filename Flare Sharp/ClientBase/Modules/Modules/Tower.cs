using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Tower : Module
    {
        public Tower() : base("Tower", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += keyHeldEvent;
        }

        public void keyHeldEvent(object sender, clientKeyEvent e)
        {
            if (enabled && e.key == (char)0x02)
            {
                if(Minecraft.clientInstance.localPlayer.pitch >= 85F && Minecraft.clientInstance.localPlayer.heldItemCount > 0 && Minecraft.clientInstance.localPlayer.level.lookingBlockY > 0 && Minecraft.clientInstance.localPlayer.level.lookingBlockY <= 256)
                {
                    Minecraft.clientInstance.localPlayer.level.lookingBlockSide = 1;
                    Minecraft.clientInstance.localPlayer.velY = 0.5F;
                }
            }
        }
    }
}
