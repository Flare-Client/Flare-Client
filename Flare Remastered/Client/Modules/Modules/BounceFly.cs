using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
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
