using Flare_Sharp.ClientBase.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Triggerbot : Module
    {
        public Triggerbot() : base("Triggerbot", CategoryHandler.registry.categories[0], 'R', false)
        {
        }

        public override void onDisable()
        {
            base.onDisable();

        }
    }
}
