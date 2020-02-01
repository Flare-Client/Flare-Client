using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class YPort : Module
    {
        float boostBy = 1;
        public YPort() : base("YPort", CategoryHandler.registry.categories[1], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            SDK.instance.player.velY += boostBy;
            this.enabled = false;
        }
    }
}
