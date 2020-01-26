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
            Int64 facing = MCM.readInt64((UInt64)Pointers.entityFacing());
            if (facing > 0)
            {
                MCM.writeBaseByte((int)Pointers.attackSwing(), 0);
            }
            else
            {
                MCM.writeBaseByte((int)Pointers.attackSwing(), 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte((int)Pointers.attackSwing(), 1);
        }
    }
}
