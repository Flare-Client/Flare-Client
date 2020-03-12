using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
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
            RegisterSliderSetting("Jetpack", 0, 10, 50);
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
            Utils.Vec3f directionalVec = Minecraft.clientInstance.localPlayer.lookingVec;
            Minecraft.clientInstance.localPlayer.velX = sliderSettings[0].value / 10f * directionalVec.x;
            Minecraft.clientInstance.localPlayer.velY = sliderSettings[0].value / 10f * -directionalVec.y;
            Minecraft.clientInstance.localPlayer.velZ = sliderSettings[0].value / 10f * directionalVec.z;
        }
    }
}
