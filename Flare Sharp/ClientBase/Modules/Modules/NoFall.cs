using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System;

namespace Flare_Sharp.ClientBase.Modules.Modules
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
