using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Jetpack : Module
    {
        public Jetpack() : base("Jetpack", CategoryHandler.registry.categories[1], '-', true)
        {
            KeybindHandler.clientKeyHeldEvent += OnKeyHeld;
        }
        public void OnKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == 'F') enabled = true;
        }
        public override void onTick()
        {
            base.onTick();
            if(!KeybindHandler.isKeyDown('F')) enabled = false;
        }
    }
}
