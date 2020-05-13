using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class Flight : Module
    {
        public Flight() : base("Flight", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.isFlying = 0;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.isFlying = 1;
        }
    }
}
