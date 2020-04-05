using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoFall : Module
    {
        public static bool savedNoFallRule;
        public NoFall() : base("NoFall", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }
        public override void onEnable()
        {
            base.onEnable();
            savedNoFallRule = Minecraft.clientInstance.localPlayer.level.gamerules[9].toggle;
            Console.WriteLine(Minecraft.clientInstance.localPlayer.level.gamerules[9].toggle);
        }
        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.level.gamerules[9].toggle = false;
            Console.WriteLine(Minecraft.clientInstance.localPlayer.level.gamerules[9].toggle);
        }
        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.level.gamerules[9].toggle = savedNoFallRule;
        }
    }
}
