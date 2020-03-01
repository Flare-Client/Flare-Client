using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class ListTest : Module
    {
        public ListTest():base("ListTest", CategoryHandler.registry.categories[0], 0x07, false)
        {

        }

        public override void onEnable()
        {
            List<Entity> entities = EntityList.getEntityList(true);
            Console.WriteLine("Entity List ({0})", entities.Count);
            ulong index = 0;
            foreach(Entity e in entities)
            {
                Console.WriteLine("Entity{0}: {1}", index, e.addr.ToString("X"));
                index++;
            }
            this.enabled = false;
        }
    }
}
