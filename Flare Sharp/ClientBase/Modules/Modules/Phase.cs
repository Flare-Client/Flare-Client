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
    public class Phase : Module
    {
        public Phase() : base("Phase", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
            SDK.instance.player.Y2 = SDK.instance.player.Y1 + 1.8f;
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.Y2 = SDK.instance.player.Y1;
        }
    }
}
