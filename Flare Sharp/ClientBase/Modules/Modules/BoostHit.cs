using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;
using System;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class BoostHit : Module
    {
        public BoostHit() : base("Boost Hit", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += keyHeldEvent;
            RegisterSliderSetting("Boost", 0, 20, 50);
        }

        public void keyHeldEvent(object sender, clientKeyEvent e)
        {
            if (enabled)
            {
                UInt64 facingEnt = Minecraft.clientInstance.localPlayer.level.lookingEntity.addr;
                if(facingEnt > 0 && e.key == (char)0x01)
                {
                    Utils.Vec3f directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                    Minecraft.clientInstance.localPlayer.velX = (float)sliderSettings[0].value / 10F * directionalVec.x;
                    Minecraft.clientInstance.localPlayer.velZ = (float)sliderSettings[0].value / 10F * directionalVec.z;
                }
            }
        }
    }
}
