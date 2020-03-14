using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class TPFlight : Module
    {
        int delayCount = 0;
        int limitCheck = 0;
        public TPFlight():base("TPFlight", CategoryHandler.registry.categories[1], 0x07, false)
        {
            RegisterSliderSetting("Speed", 0, 10, 500);
            RegisterSliderSetting("Delay", 0, 100, 500);
            RegisterSliderSetting("Limit", 0, 2, 20);
        }
        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.velX = 0;
            Minecraft.clientInstance.localPlayer.velY = 0;
            Minecraft.clientInstance.localPlayer.velZ = 0;
            if (limitCheck <= sliderSettings[2].value || sliderSettings[2].value <= 0)
            {
                if (delayCount >= sliderSettings[1].value)
                {
                    Utils.Vec3f directionalVec = Minecraft.clientInstance.localPlayer.lookingVec;
                    Minecraft.clientInstance.localPlayer.teleport(Minecraft.clientInstance.localPlayer.X1 + sliderSettings[0].value / 10 * directionalVec.x, Minecraft.clientInstance.localPlayer.Y1 + sliderSettings[0].value / 10 * -directionalVec.y, Minecraft.clientInstance.localPlayer.Z1 + sliderSettings[0].value / 10 * directionalVec.z);
                    delayCount = 0;
                    limitCheck++;
                }
                delayCount++;
            }
            else
            {
                this.enabled = false;
                limitCheck = 0;
            }
        }
    }
}
