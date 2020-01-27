using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoKnockBack : Module
    {
        private bool writeOnce;

        public NoKnockBack() : base("NoKnockBack", CategoryHandler.registry.categories[1], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.NoKnockBackX, write);
            MCM.writeBaseBytes(Pointers.NoKnockBackY, write);
            MCM.writeBaseBytes(Pointers.NoKnockBackZ, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write1 = { 0x89, 0x81, 0x6C, 0x04, 0x00, 0x00 };
            byte[] write2 = { 0x89, 0x81, 0x70, 0x04, 0x00, 0x00 };
            byte[] write3 = { 0x89, 0x81, 0x74, 0x04, 0x00, 0x00 };
            MCM.writeBaseBytes(Pointers.NoKnockBackX, write1);
            MCM.writeBaseBytes(Pointers.NoKnockBackY, write2);
            MCM.writeBaseBytes(Pointers.NoKnockBackZ, write2);
        }
    }
}
