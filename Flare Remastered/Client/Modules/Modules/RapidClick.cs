using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;
using System;

namespace Flare_Remastered.Client.Modules.Modules
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
