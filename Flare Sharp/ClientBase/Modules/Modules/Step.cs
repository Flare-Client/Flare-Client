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
    public class Step : Module
    {
        public Step() : base("Step", CategoryHandler.registry.categories[1], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
            SDK.instance.player.blockCollisionStep = 0.5625F;
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.blockCollisionStep = 2;
        }
    }
}
