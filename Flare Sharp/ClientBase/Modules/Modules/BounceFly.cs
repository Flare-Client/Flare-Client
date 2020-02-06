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
    public class BounceFly : Module
    {
        public BounceFly() : base("BounceFly", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            if (SDK.instance.player.velY <= -0.5F) SDK.instance.player.velY = 0.5F;
        }
    }
}
