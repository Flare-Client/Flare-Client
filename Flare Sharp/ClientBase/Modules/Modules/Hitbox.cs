using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Hitbox : Module
    {
        public Hitbox() : base("Hitbox", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterSliderSetting("Hitbox Height", 0, 60, 120);
            RegisterSliderSetting("Hitbox Width", 0, 40, 80);
        }

        public override void onTick()
        {
            base.onTick();
            List<Mob> entList = Minecraft.clientInstance.localPlayer.level.getMovingEntities;
            foreach (Mob e in entList)
            {
                e.hitboxHeight = (float)sliderSettings[0].value / 10;
                e.hitboxWidth = (float)sliderSettings[1].value / 10;
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            List<Mob> entList = Minecraft.clientInstance.localPlayer.level.getAllEntities;
            foreach (Mob e in entList)
            {
                e.hitboxHeight = 0.6f;
                e.hitboxWidth = 1.8f;
            }
        }
    }
}
