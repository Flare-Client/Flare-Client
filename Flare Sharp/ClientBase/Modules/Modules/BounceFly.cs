using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class BounceFly : Module
    {
        public BounceFly() : base("BounceFly", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            if (Minecraft.clientInstance.localPlayer.velY <= -0.5F) Minecraft.clientInstance.localPlayer.velY = 0.5F;
        }
    }
}
