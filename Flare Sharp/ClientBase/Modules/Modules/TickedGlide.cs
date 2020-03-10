using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TickedGlide: Module
    {
        public int Counter;
        public float savedY;

        public double distanceTo(float currentY, float savedY)
        {
            float dY = currentY - savedY;
            return Math.Sqrt(dY * dY);
        }
        public TickedGlide() : base("TickedGlide", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            RegisterSliderSetting("Speed", 0, 4, 50);
            RegisterSliderSetting("Decrement Y", -20, -08, 0);
            RegisterSliderSetting("Delay", 0, 20, 50);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedY = Minecraft.clientInstance.localPlayer.currentY1;
        }

        public override void onTick()
        {
            base.onTick();

            Minecraft.clientInstance.localPlayer.velY = 0;
            Minecraft.clientInstance.localPlayer.velY = (float)sliderSettings[1].value / 10;

            if (KeybindHandler.isKeyDown('W'))
            {
                List<float> directionalVec = SDK.instance.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 89.9f) * (float)Math.PI / 178F, (float)Math.PI / 178F);

                Minecraft.clientInstance.localPlayer.velX = (float)sliderSettings[0].value / 10F * directionalVec[0];
                Minecraft.clientInstance.localPlayer.velZ = (float)sliderSettings[0].value / 10F * directionalVec[2];
            }

            Counter += 1;

            if(Counter > sliderSettings[2].value)
            {
                if(distanceTo(Minecraft.clientInstance.localPlayer.currentY1, savedY) <= 12)
                {
                    Minecraft.clientInstance.localPlayer.teleport(Minecraft.clientInstance.localPlayer.currentX1, savedY, Minecraft.clientInstance.localPlayer.currentZ1);
                } else
                {
                    savedY = Minecraft.clientInstance.localPlayer.currentY1;
                }
                Counter = 0;
            }
        }
    }
}
