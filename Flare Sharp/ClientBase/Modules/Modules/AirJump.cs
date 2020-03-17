using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AirJump : Module
    {
        public AirJump() : base("AirJump", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.onGround = 1;
        }
    }
}
