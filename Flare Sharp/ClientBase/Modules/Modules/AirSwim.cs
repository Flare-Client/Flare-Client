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
    public class AirSwim : Module
    {
        public AirSwim() : base("AirSwim", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] offs = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.notInWaterTick, offs);
            SDK.instance.player.isInWater = 1;
        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] offs = { 0x0F, 0xB6, 0x81, 0x3D, 0x02, 0x00, 0x00 };
            MCM.writeBaseBytes(Pointers.notInWaterTick, offs);
            SDK.instance.player.isInWater = 0;
        }
    }
}
