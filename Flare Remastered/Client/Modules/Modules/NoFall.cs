using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class NoFall : Module
    {
        public NoFall() : base("NoFall", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }
        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.isFalling = 0;
        }
    }
}
