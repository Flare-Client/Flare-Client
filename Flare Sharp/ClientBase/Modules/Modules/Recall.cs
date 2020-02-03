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
    public class Recall : Module
    {
        public List<List<float>> prevPositions = new List<List<float>>();
        public List<List<float>> prevStaring = new List<List<float>>();
        public Recall() : base("Recall", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
        }

        public override void onDisable()
        {
            base.onDisable();
            prevPositions.Reverse();
            prevStaring.Reverse();
            for(var I = 0; I < prevPositions.Count(); I++)
            {
                SDK.instance.player.teleport(prevPositions[I][0], prevPositions[I][1], prevPositions[I][2]);
                MCM.writeFloat(Pointers.mousePitch(), prevStaring[I][0]);
                MCM.writeFloat(Pointers.mouseYaw(), prevStaring[I][1]);
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
            position.Add(SDK.instance.player.currentX1);
            position.Add(SDK.instance.player.currentY1);
            position.Add(SDK.instance.player.currentZ1);

            staringPos.Add(MCM.readFloat(Pointers.mousePitch()));
            staringPos.Add(MCM.readFloat(Pointers.mouseYaw()));

            for (int I = 0; I < 10; I++)
            {
                prevPositions.Add(position);
                prevStaring.Add(staringPos);
            }
        }
    }
}
