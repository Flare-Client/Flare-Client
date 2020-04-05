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
            Console.WriteLine("The toggle is: " + toggleSettings[0].value.ToString());
            List<Mob> entities = Minecraft.clientInstance.localPlayer.entityRegistry.Entities;
            Console.WriteLine("Entity List ({0})", entities.Count);
            ulong index = 0;
            foreach(Mob e in entities)
            {
                Console.WriteLine("Entity{0}: {1}", index, e.addr.ToString("X"));
                index++;
            }
            this.enabled = false;
        }
    }
}
