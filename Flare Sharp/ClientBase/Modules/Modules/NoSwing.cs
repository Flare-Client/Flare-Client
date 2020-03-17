using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoSwing : Module
    {
        public NoSwing() : base("NoSwing", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            MCM.writeBaseByte(Statics.handSwingPacket, 1);
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.handSwingPacket, 0);
        }
    }
}
