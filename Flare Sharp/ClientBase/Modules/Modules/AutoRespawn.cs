using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Modules.Modules
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
