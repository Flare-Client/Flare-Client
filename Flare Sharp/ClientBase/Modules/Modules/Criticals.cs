using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Criticals : Module
    {
        public Criticals() : base("Criticals", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0xB8, 0x00, 0x00, 0x00, 0x00, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.criticalsPacket, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x0F, 0xB6, 0x86, 0x78, 0x01, 0x00, 0x00 };
            MCM.writeBaseBytes(Statics.criticalsPacket, write);
        }
    }
}
