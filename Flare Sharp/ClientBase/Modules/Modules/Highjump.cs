using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class HighJump : Module
    {
        public HighJump() : base("HighJump", CategoryHandler.registry.categories[1], (char)0x20, false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }

        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind)
            {
                enabled = false;
            }
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
        }

        public override void onTick()
        {
            base.onTick();
            if (SDK.instance.player.isInAir > 1 | SDK.instance.player.onGround > 0) SDK.instance.player.velY = 0.5F;
        }
    }
}
