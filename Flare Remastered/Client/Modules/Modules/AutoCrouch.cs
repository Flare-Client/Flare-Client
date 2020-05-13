using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class AutoCrouch : Module
    {
        public AutoCrouch() : base("AutoCrouch", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.vanillaMoveInputHandler.isCrouching = 1;
        }
    }
}
