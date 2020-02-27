using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class KillauraTest : Module
    {
        public KillauraTest() : base("Killaura", CategoryHandler.registry.categories[0], 0x07, false)
        {

        }
        public override void onEnable()
        {
            try
            {
                base.onEnable();
                SDK.instance.AttackEntity(SDK.instance.player, SDK.instance.entityFacing);
                this.enabled = false;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
