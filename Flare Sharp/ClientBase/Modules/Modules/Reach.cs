using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Reach : Module
    {
        public Reach() : base("Reach", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x75, 0x13, 0x41, 0x0F, 0x28, 0xED };
            MCM.writeBaseBytes(Statics.survivalReachCmp, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x74, 0x13, 0x41, 0x0F, 0x28, 0xED };
            MCM.writeBaseBytes(Statics.survivalReachCmp, write);
        }
    }
}
