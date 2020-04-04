using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class CubeCraftFly : Module
    {
        public CubeCraftFly():base("CCFly", CategoryHandler.registry.categories[1], 0x7, false)
        {
            startTimer(300);
            RegisterSliderSetting("Speed", 0, 10, 50);
        }

        public override void onDisable()
        {
            base.onDisable();
            switcher = true;
            MCM.writeBaseByte(0xFA21E0, 0);
        }

        bool switcher = true;
        int timedTicks = 0;
        public override void onTimedTick()
        {
            base.onTimedTick();
            if(timedTicks > 3)
            {
                timedTicks = 0;
            }
            if (switcher)
            {
                //MCM.writeBaseByte(0xFA21E0, 1);
                switcher = false;
            }
            else
            {
                //MCM.writeBaseByte(0xFA21E0, 0);
                switcher = true;
            }
            timedTicks++;
        }

        public override void onTick()
        {
            base.onTick();
            if (!switcher)
            {
                if (timedTicks > 2)
                {
                    return;
                }
                Utils.Vec3f directionalVec = Minecraft.clientInstance.localPlayer.lookingVec;
                Minecraft.clientInstance.localPlayer.velX = sliderSettings[0].value / 10f * directionalVec.x;
                Minecraft.clientInstance.localPlayer.velY = sliderSettings[0].value / 10f * -directionalVec.y;
                Minecraft.clientInstance.localPlayer.velZ = sliderSettings[0].value / 10f * directionalVec.z;
            }
            else
            {
                if (timedTicks > 3)
                {
                    return;
                }
                Utils.Vec3f directionalVec = Minecraft.clientInstance.localPlayer.lookingVec;
                Minecraft.clientInstance.localPlayer.velX = 0.5f / 10f * directionalVec.x;
                Minecraft.clientInstance.localPlayer.velY = 0.5f / 10f * -directionalVec.y;
                Minecraft.clientInstance.localPlayer.velZ = 0.5f / 10f * directionalVec.z;
            }
        }
    }
}
