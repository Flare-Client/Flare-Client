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
    public class NoSlowDown : Module
    {

        public NoSlowDown() : base("NoSlowDown", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.NoSlowDown1, write);
            MCM.writeBaseBytes(Pointers.NoSlowDown2, write);
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0xF3, 0x0F, 0x11, 0x46, 0x0C };
            MCM.writeBaseBytes(Pointers.NoSlowDown1, write);
            MCM.writeBaseBytes(Pointers.NoSlowDown2, write);
        }
    }
}
