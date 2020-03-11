using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class NoPacket : Module
    {
        public NoPacket() : base("NoPacket", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            MCM.writeBaseByte(0xFA21E0, 1);
        }
        public override void onDisable()
        {
            base.onDisable();
            MCM.writeBaseByte(0xFA21E0, 3);
        }
    }
}
