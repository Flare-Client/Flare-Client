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
    public class Triggerbot : Module
    {
        public Triggerbot() : base("Triggerbot", CategoryHandler.registry.categories[0], 'R', false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            UInt64 facing = SDK.instance.entityFacing;
            if (facing > 0)
            {
                MCM.writeBaseByte(Pointers.attackSwing, 0);
            }
            else
            {
                MCM.writeBaseByte(Pointers.attackSwing, 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Pointers.attackSwing, 1);
        }
    }
}
