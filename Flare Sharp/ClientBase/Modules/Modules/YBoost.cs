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
        int boostBy = 10;
        public YBoost() : base("YBoost", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSetting("Boost Amount", ref boostBy);
        }

        public override void onEnable()
        {
            base.onEnable();
            SDK.instance.player.velY += boostBy / 10;
            this.enabled = false;
        }
    }
}
