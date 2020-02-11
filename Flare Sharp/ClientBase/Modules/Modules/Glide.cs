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
    public class Glide : Module
    {
        public Glide() : base("Glide", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Value", -30, 0, 30);
        }

        public override void onTick()
        {
            base.onTick();
            SDK.instance.player.velY = sliderSettings[0].value;
        }
    }
}
