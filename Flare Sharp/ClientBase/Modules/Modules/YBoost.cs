using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class YBoost : Module
    {
        public YBoost() : base("YBoost", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Boost", 0, 10, 100);
        }

        public override void onEnable()
        {
            base.onEnable();
            SDK.instance.player.velY += (float)sliderSettings[0].value / 10;
            this.enabled = false;
        }
    }
}
