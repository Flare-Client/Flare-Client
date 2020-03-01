using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.CraftSDK;
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
                if(SDK.instance.player.pitch >= 85F && SDK.instance.player.heldItemCount > 0 && Pointers.blockPosY > 0 && Pointers.blockPosY <= 256)
                {
                    Pointers.blockSide = 1;
                    SDK.instance.player.velY = 0.5F;
                }
            }
        }
    }
}
