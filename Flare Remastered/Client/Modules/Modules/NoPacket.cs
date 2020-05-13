using Flare_Remastered.Client.Categories;
using Flare_Remastered.Memory;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class NoPacket : Module
    {
        public NoPacket() : base("NoPacket", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            if(Minecraft.clientInstance.localPlayer.username.Length > 0)
            {
                MCM.writeBaseByte(Statics.noPacket, 117);
            } else
            {
                MCM.writeBaseByte(Statics.noPacket, 116);
            }
        }
        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.noPacket, 116);
        }
    }
}
