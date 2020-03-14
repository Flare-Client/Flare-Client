using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Step : Module
    {
        public Step() : base("Step", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.blockCollisionStep = 0.5625F;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.blockCollisionStep = 2;
        }
    }
}
