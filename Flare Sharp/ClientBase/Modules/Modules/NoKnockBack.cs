using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoKnockBack : Module
    {
        public NoKnockBack() : base("NoKnockBack", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x8B, 0x42, 0x04, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x8B, 0x42, 0x08, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.NoKnockBack, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x89, 0x81, 0x94, 0x04, 0x00, 0x00, 0x8B, 0x42, 0x04, 0x89, 0x81, 0x98, 0x04, 0x00, 0x00, 0x8B, 0x42, 0x08, 0x89, 0x81, 0x9C, 0x04, 0x00, 0x00 };
            MCM.writeBaseBytes(Statics.NoKnockBack, write);
        }
    }
}
