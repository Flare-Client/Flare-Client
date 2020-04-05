using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AutoSword : Module
    {
        int autoSwordCounter;

        public AutoSword() : base("AutoSword", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterToggleSetting("Only near enemies", true);
            RegisterSliderSetting("Range", 0, 120, 240);
        }

        public override void onTick()
        {
            base.onTick();

            if (toggleSettings[0].value)
            {
                List<Mob> Entity = Minecraft.clientInstance.localPlayer.entityRegistry.targetableEntities;

                foreach (Mob e in Entity)
                {
                    double distance = e.distanceTo(Minecraft.clientInstance.localPlayer);

                    if (distance <= (float)sliderSettings[0].value / 10F)
                    {
                        autoSwordCounter += 1;

                        int heldItemID = Minecraft.clientInstance.localPlayer.heldItemID;

                        if (autoSwordCounter > 4)
                        {
                            if (heldItemID != 276 && heldItemID != 283 && heldItemID != 267 && heldItemID != 272 && heldItemID != 268)
                            {
                                if (Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot < 8)
                                {
                                    Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot += 1;
                                }
                                else
                                {
                                    Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot = 0;
                                }
                            }
                            autoSwordCounter = 0;
                        }
                    }
                }
            } else
            {
                autoSwordCounter += 1;

                int heldItemID = Minecraft.clientInstance.localPlayer.heldItemID;

                if (autoSwordCounter > 4)
                {
                    if (heldItemID != 276 && heldItemID != 283 && heldItemID != 267 && heldItemID != 272 && heldItemID != 268)
                    {
                        if (Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot < 8)
                        {
                            Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot += 1;
                        }
                        else
                        {
                            Minecraft.clientInstance.localPlayer.inventoryProxy.selectedHotbarSlot = 0;
                        }
                    }
                    autoSwordCounter = 0;
                }
            }
        }
    }
}
