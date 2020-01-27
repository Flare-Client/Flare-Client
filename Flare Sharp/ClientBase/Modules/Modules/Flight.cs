using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Flight : Module
    {
        public Flight() : base("Flight", CategoryHandler.registry.categories[2], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
            SDK.instance.player.isFlying = 0;
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.isFlying = 1;
        }
    }
}
