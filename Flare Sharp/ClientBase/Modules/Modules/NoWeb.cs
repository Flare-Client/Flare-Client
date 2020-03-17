using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoWeb : Module
    {

        public NoWeb() : base("NoWeb", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, };
            MCM.writeBaseBytes(Statics.webTick, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xF3, 0x0F, 0x11, 0x89, 0x38, 0x02, 0x00, 0x00, };
            MCM.writeBaseBytes(Statics.webTick, write);
        }
    }
}
