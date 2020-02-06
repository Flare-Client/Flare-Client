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
    public class Jesus : Module
    {
        public Jesus() : base("Jesus", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
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
            if(SDK.instance.player.isInWater > 0)
            {
                SDK.instance.player.velY = 0.2F;
            }
        }
    }
}
