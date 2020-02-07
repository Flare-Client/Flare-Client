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
        }

        public override void onTick()
        {
            base.onTick();
            List<Entity> Entity = EntityList.getEntityList();
            foreach(Entity e in Entity)
            {
                e.hitboxHeight = 6f;
                e.hitboxWidth = 4f;
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
