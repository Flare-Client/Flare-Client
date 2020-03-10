using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                /*
                if(Minecraft.clientInstance.localPlayer.pitch >= 85F && Minecraft.clientInstance.localPlayer.heldItemCount > 0 && Statics.blockPosY > 0 && Statics.blockPosY <= 256)
                {
                    Statics.blockSide = 1;
                    Minecraft.clientInstance.localPlayer.velY = 0.5F;
                }
                */
            }
        }
    }
}
