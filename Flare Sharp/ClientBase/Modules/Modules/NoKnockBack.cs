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
            MCM.writeBaseByte(Statics.NoKnockBackX, 0);
            MCM.writeBaseByte(Statics.NoKnockBackY, 0);
            MCM.writeBaseByte(Statics.NoKnockBackZ, 0);
        }

        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(Statics.NoKnockBackX, 4);
            MCM.writeBaseByte(Statics.NoKnockBackY, 4);
            MCM.writeBaseByte(Statics.NoKnockBackZ, 4);
        }
    }
}
