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
            List<Entity> Entity = EntityList.getEntityList();
            foreach(Entity e in Entity)
            {
                e.hitboxHeight = sliderSettings[0].value / 10;
                e.hitboxWidth = sliderSettings[1].value / 10;
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            List<Entity> Entity = EntityList.getEntityList();
            foreach (Entity e in Entity)
            {
                e.hitboxHeight = 0.6f;
                e.hitboxWidth = 1.8f;
            }
        }
    }
}
