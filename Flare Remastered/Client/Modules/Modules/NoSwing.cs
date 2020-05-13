using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class NoSwing : Module
    {
        public NoSwing() : base("NoSwing", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0xC6, 0x83, 0xB4, 0x08, 0x00, 0x00, 00 };
            MCM.writeBaseBytes(Statics.handSwingPacket, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xC6, 0x83, 0xB4, 0x08, 0x00, 0x00, 01 };
            MCM.writeBaseBytes(Statics.handSwingPacket, write);
        }
    }
}
