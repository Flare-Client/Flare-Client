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
        public Hitbox() : base("Hitbox", CategoryHandler.registry.categories[0], 'H', false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            List<Entity> entityList = EntityList.getEntityList();
            for(var I = 0; I < entityList.Count(); I++)
            {
                //
            }
        }

        public override void onDisable()
        {
            base.onDisable();
            //
        }
    }
}
