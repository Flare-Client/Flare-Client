using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System;
using System.Collections.Generic;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class AutoRespawn : Module
    {

        public static bool savedImmediateSpawnGameRule;
        public AutoRespawn() : base("AutoRespawn", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.level.gamerules[23].toggle = true;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.level.gamerules[23].toggle = savedImmediateSpawnGameRule;
        }
    }
}
