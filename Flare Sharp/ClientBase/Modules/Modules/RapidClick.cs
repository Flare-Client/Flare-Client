using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class RapidClick: Module
    {
        public RapidClick() : base("Rapid-Click", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            UInt64 facing = Minecraft.clientInstance.localPlayer.level.lookingEntity.addr;
            if(facing > 0)
            {
                MCM.writeBaseByte(Statics.rapidPlace, 0);
            } else
            {
                MCM.writeBaseByte(Statics.rapidPlace, 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.rapidPlace, 0);
        }
    }
}
