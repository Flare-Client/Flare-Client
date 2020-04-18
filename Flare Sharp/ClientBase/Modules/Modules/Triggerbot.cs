using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.UI.VObjs;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Triggerbot : Module
    {
        public static int triggerbotCounter = 0;
        public Triggerbot() : base("Triggerbot", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterSliderSetting("Delay", 0, 0, 500);
        }

        public override void onTick()
        {
            base.onTick();
            Mob facing = Minecraft.clientInstance.localPlayer.level.lookingEntity;
            if(facing.movedTick > 1)
            {
                MCM.writeBaseByte(Statics.attackSwing, 0);
            } else
            {
                MCM.writeBaseByte(Statics.attackSwing, 1);
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.attackSwing, 1);
        }
    }
}
