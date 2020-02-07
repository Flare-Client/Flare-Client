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
        public Jetpack() : base("Jetpack", CategoryHandler.registry.categories[1], 'F', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }
        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind)
            {
                enabled = false;
            }
        }
        public override void onTick()
        {
            base.onTick();
            List<float> directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 89.9f) * (float)Math.PI / 178F, SDK.instance.player.pitch * (float)Math.PI / 178F);
            SDK.instance.player.velX = 1.2F * directionalVec[0];
            SDK.instance.player.velY = 1.2F * -directionalVec[1];
            SDK.instance.player.velZ = 1.2F * directionalVec[2];
        }
    }
}
