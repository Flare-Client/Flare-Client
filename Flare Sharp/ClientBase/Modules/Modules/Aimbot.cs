using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Aimbot : Module
    {
        public Aimbot() : base("Aimbot", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            RegisterSliderSetting("Range", 0, 120, 500);
        }

        public override void onTick()
        {
            base.onTick();
            List<Mob> Entity = Minecraft.clientInstance.localPlayer.entityRegistry.targetableEntities;
            List<double> distancesArr = new List<double>();

            foreach(Mob e in Entity)
            {
                Double distance = e.distanceTo(Minecraft.clientInstance.localPlayer);
                if (distance <= sliderSettings[0].value / 10F) distancesArr.Add(distance);
            }

            if(distancesArr.Count() > 0)
            {
                distancesArr.Sort();

                foreach(Mob e in Entity)
                {
                    if(e.distanceTo(Minecraft.clientInstance.localPlayer) == distancesArr[0])
                    {
                        Utils.Vec3f localPosition = Minecraft.clientInstance.localPlayer.location;
                        Utils.Vec3f targetPosition = e.location;
                        Utils.Vec2f calculationsArr = Utils.getCalculationsToPos(localPosition, targetPosition);
                        Minecraft.clientInstance.localPlayer.level.firstPersonCamera.cameraPitch = calculationsArr.x;
                        Minecraft.clientInstance.localPlayer.level.firstPersonCamera.cameraYaw = calculationsArr.y;
                    }
                }
            }
        }
    }
}
