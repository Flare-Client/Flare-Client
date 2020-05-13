using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
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
