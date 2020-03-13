using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.NoKnockBackX, write);
            MCM.writeBaseBytes(Statics.NoKnockBackY, write);
            MCM.writeBaseBytes(Statics.NoKnockBackZ, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write1 = { 0x89, 0x81, 0x6C, 0x04, 0x00, 0x00 };
            byte[] write2 = { 0x89, 0x81, 0x70, 0x04, 0x00, 0x00 };
            byte[] write3 = { 0x89, 0x81, 0x74, 0x04, 0x00, 0x00 };
            MCM.writeBaseBytes(Statics.NoKnockBackX, write1);
            MCM.writeBaseBytes(Statics.NoKnockBackY, write2);
            MCM.writeBaseBytes(Statics.NoKnockBackZ, write2);
        }
    }
}
