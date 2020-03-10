using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Triggerbot : Module
    {
        public Triggerbot() : base("Triggerbot", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Mob facing = Minecraft.clientInstance.localPlayer.level.lookingEntity;
            if (facing.movedTick > 1)
            {
                if (VTargetsWindow.targetable.Contains(facing.type))
                {
                    if (facing.addr > 0)
                    {
                        MCM.writeBaseByte(Statics.attackSwing, 0);
                    }
                    else
                    {
                        MCM.writeBaseByte(Statics.attackSwing, 1);
                    }
                }
            }
            if (facing.addr <= 0)
            {
                MCM.writeBaseByte(Statics.attackSwing, 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.attackSwing, 1);
        }
    }
}
