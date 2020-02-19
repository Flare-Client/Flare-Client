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
    public class AutoSword : Module
    {

        int autoSwordCounter;

        public AutoSword() : base("AutoSword", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();

            autoSwordCounter += 1;

            int heldItemID = SDK.instance.player.heldItemID;

            if(autoSwordCounter > 4)
            {
                if (heldItemID != 276 && heldItemID != 283 && heldItemID != 267 && heldItemID != 272 && heldItemID != 268)
                {
                    if (Pointers.selectedHotbarSlot < 8)
                    {
                        Pointers.selectedHotbarSlot += 1;
                    }
                    else
                    {
                        Pointers.selectedHotbarSlot = 0;
                    }
                }
                autoSwordCounter = 0;
            }
        }

    }
}
