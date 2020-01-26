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
    public class PlayerSpeed : Module
    {
        public PlayerSpeed() : base("Speed", CategoryHandler.registry.categories[1], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeFloat(Pointers.playerSpeed(), (float)0.1);
        }

        public override void onTick()
        {
            base.onTick();
            MCM.writeFloat(Pointers.playerSpeed(), (float)0.5);
        }
    }
}
