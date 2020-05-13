using Flare_Remastered.Client.Categories;
using Flare_Remastered.SparkSDK;
using System.Collections.Generic;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class Hitbox : Module
    {
        public Hitbox() : base("Hitbox", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterFloatSliderSetting("Hitbox Width", 0.6f, 0.6f, 60f);
            RegisterFloatSliderSetting("Hitbox Height", 1.8f, 1.8f, 18f);
        }

        public override void onTick()
        {
            base.onTick();
            List<Mob> entList = Minecraft.clientInstance.localPlayer.level.getMovingEntities;
            foreach (Mob e in entList)
            {
                e.hitboxWidth = (float)sliderFloatSettings[0].value;
                e.hitboxHeight = (float)sliderFloatSettings[1].value;
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
