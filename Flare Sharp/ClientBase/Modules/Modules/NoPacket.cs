using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoPacket : Module
    {
        public NoPacket() : base("NoPacket", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            MCM.writeBaseByte(Statics.noPacket, 117);
        }
        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.noPacket, 116);
        }
    }
}
