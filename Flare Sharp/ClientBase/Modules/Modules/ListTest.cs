using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ListTest : Module
    {
        public ListTest():base("ListTest", CategoryHandler.registry.categories[0], 0x07, false)
        {
            RegisterToggleSetting("Test", false);
        }

        public override void onEnable()
        {
            List<Mob> EntitiesMoving = Minecraft.clientInstance.localPlayer.level.getMovingEntities;
            List<Mob> EntitiesAll = Minecraft.clientInstance.localPlayer.level.getAllEntities;
            Console.WriteLine("Moving Entities: " + EntitiesMoving.Count);
            Console.WriteLine("Entities (ALL): " + EntitiesAll.Count);
            this.enabled = false;
        }
    }
}
