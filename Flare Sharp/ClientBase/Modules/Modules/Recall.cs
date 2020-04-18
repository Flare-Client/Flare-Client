using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory.FlameSDK;
using System.Collections.Generic;
using System.Linq;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Recall : Module
    {
        public List<List<float>> prevPositions = new List<List<float>>();
        public List<List<float>> prevStaring = new List<List<float>>();
        public Recall() : base("Recall", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onDisable()
        {
            base.onDisable();
            prevPositions.Reverse();
            prevStaring.Reverse();
            for(var I = 0; I < prevPositions.Count(); I++)
            {
                Minecraft.clientInstance.localPlayer.teleport(prevPositions[I][0], prevPositions[I][1], prevPositions[I][2]);
                Minecraft.clientInstance.firstPersonLookBehavior.cameraPitch = prevStaring[I][0];
                Minecraft.clientInstance.firstPersonLookBehavior.cameraYaw = prevStaring[I][1];
                if (enabled) break;
            }
            prevStaring.Clear();
            prevPositions.Clear();
        }

        public override void onTick()
        {
            base.onTick();
            List<float> position = new List<float>();
            List<float> staringPos = new List<float>();
            position.Add(Minecraft.clientInstance.localPlayer.currentX1);
            position.Add(Minecraft.clientInstance.localPlayer.currentY1);
            position.Add(Minecraft.clientInstance.localPlayer.currentZ1);

            staringPos.Add(Minecraft.clientInstance.firstPersonLookBehavior.cameraPitch);
            staringPos.Add(Minecraft.clientInstance.firstPersonLookBehavior.cameraYaw);

            for (int I = 0; I < 10; I++)
            {
                prevPositions.Add(position);
                prevStaring.Add(staringPos);
            }
        }
    }
}
