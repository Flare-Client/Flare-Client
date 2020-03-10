using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AutoRespawn : Module
    {

        public static bool savedImmediateSpawnGameRule;
        public AutoRespawn() : base("AutoRespawn", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            List<Gamerule> gamerules = Minecraft.clientInstance.localPlayer.level.gamerules;
            int i = 0;
            foreach(Gamerule rule in gamerules)
            {
                Console.WriteLine(rule.name + "," + i.ToString());
                i++;
            }
            savedImmediateSpawnGameRule = Minecraft.clientInstance.localPlayer.level.gamerules[23].toggle;
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
