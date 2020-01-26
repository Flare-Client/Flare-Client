using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class AutoSprint : Module
    {
        public AutoSprint() : base("AutoSprint", CategoryHandler.registry.categories[1], '-', false)
        {

        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write = { 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(0x1A5B8F0, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            byte[] write = { 0x44,0x0F,0x2F,0x66,0x0C };
            MCM.writeBaseBytes(0x1A5B8F0, write);
        }
    }
}
