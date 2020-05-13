using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System;
using System.Collections.Generic;

namespace Flare_Remastered.Client.Modules.Modules
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
