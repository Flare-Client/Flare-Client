using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class NoSlowDown : Module
    {

        public NoSlowDown() : base("NoSlowDown", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.NoSlowDown1, write);
            MCM.writeBaseBytes(Statics.NoSlowDown2, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xF3, 0x0F, 0x11, 0x46, 0x0C };
            MCM.writeBaseBytes(Statics.NoSlowDown1, write);
            MCM.writeBaseBytes(Statics.NoSlowDown2, write);
        }
    }
}
