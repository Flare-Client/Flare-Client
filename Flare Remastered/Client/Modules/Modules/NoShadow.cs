using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class NoShadow : Module
    {
        public NoShadow() : base("NoShadow", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.shadowRenderer, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xEB, 0x1B };
            MCM.writeBaseBytes(Statics.shadowRenderer, write);
        }

    }
}
