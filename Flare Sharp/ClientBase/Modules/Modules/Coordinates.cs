using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Coordinates : Module
    {
        public static bool savedCoordinatsDisplayRule;
        public Coordinates() : base("Coords", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            savedCoordinatsDisplayRule = Minecraft.clientInstance.localPlayer.level.gamerules[14].toggle;
        }
        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.level.gamerules[14].toggle = true;
        }
        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.level.gamerules[14].toggle = savedCoordinatsDisplayRule;
        }
    }
}
