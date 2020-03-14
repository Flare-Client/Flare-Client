using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Phase : Module
    {
        public Phase() : base("Phase", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.Y2 = Minecraft.clientInstance.localPlayer.Y1 + 1.8f;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.Y2 = Minecraft.clientInstance.localPlayer.Y1;
        }
    }
}
