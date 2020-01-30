using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.CraftSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Freecam : Module
    {
        List<float> savedCoordinates = new List<float>();
        public Freecam() : base("Freecam", CategoryHandler.registry.categories[3], '-', false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            savedCoordinates.Add(SDK.instance.player.currentX1);
            savedCoordinates.Add(SDK.instance.player.currentY1 - 1);
            savedCoordinates.Add(SDK.instance.player.currentZ1);
            byte[] write = { 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.movementPacket, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            SDK.instance.player.teleport(savedCoordinates[0], savedCoordinates[1], savedCoordinates[2]);
            savedCoordinates.Clear();
            byte[] write = { 0xFF, 0x50, 0x08 };
            MCM.writeBaseBytes(Pointers.movementPacket, write);
        }
    }
}
