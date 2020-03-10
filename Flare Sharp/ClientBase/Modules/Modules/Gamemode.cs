using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Gamemode : Module
    {
        public int inventoryState = Minecraft.clientInstance.localPlayer.viewCreativeItems;
        public int savedGamemode;
        public Gamemode() : base("Gamemode", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            RegisterSliderSetting("Mode", 0, 1, 2);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedGamemode = Minecraft.clientInstance.localPlayer.currentGamemode;
            inventoryState = Minecraft.clientInstance.localPlayer.viewCreativeItems;
            Minecraft.clientInstance.localPlayer.currentGamemode = sliderSettings[0].value;
            if(sliderSettings[0].value == 1) Minecraft.clientInstance.localPlayer.viewCreativeItems = 1;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.currentGamemode = savedGamemode;
            Minecraft.clientInstance.localPlayer.viewCreativeItems = inventoryState;
        }
    }
}
