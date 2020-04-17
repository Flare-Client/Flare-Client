using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoWater : Module
    {
        public NoWater() : base("NoWater", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] offs = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.inWaterTick, offs);
            Minecraft.clientInstance.localPlayer.isInWater = 0;
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] offs = { 0xC6, 0x83, 0x15, 0x02, 0x00, 0x00, 0x01 }; //Extra offset needed? EB
            MCM.writeBaseBytes(Statics.inWaterTick, offs);
        }
    }
}
