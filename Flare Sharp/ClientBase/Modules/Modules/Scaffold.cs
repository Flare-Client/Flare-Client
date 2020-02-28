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
    public class Scaffold : Module
    {
        public Scaffold() : base("Scaffold", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            MCM.writeBaseByte(Pointers.blockFace, 135);
        }

        public override void onTick()
        {
            base.onTick();
            UInt64 facing = SDK.instance.entityFacing;
            if (facing > 0)
            {
                MCM.writeBaseByte(Pointers.rapidPlace, 0);
            }
            else
            {
                MCM.writeBaseByte(Pointers.rapidPlace, 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Pointers.blockFace, 134);
            MCM.writeBaseByte(Pointers.rapidPlace, 0);
        }
    }
}
