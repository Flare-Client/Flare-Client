using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Instabreak : Module
    {
        public Instabreak() : base("Instabreak", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0xF3, 0x0F, 0x11, 0x57, 0x20 };
            MCM.writeBaseBytes(Statics.blockBreak, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xF3, 0x0F, 0x11, 0x4F, 0x20 };
            MCM.writeBaseBytes(Statics.blockBreak, write);
        }
    }
}
