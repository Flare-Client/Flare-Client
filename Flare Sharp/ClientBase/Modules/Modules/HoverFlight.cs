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
    public class HoverFlight : Module
    {
        public HoverFlight() : base("HoverFlight", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public async Task FlightDelay()
        {
            await Task.Delay(300);
            if (enabled)
            {
                SDK.instance.player.velY = 0.4F;
                await FlightDelay();
            }            
        }

        public override void onEnable()
        {
            base.onEnable();
            FlightDelay();
        }
    }
}
