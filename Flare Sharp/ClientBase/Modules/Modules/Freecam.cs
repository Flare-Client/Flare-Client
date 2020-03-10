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
        List<float> savedPitchAndYaw = new List<float>();
        byte savedFlightState;
        public Freecam() : base("Freecam", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            savedCoordinates.Add(Minecraft.clientInstance.localPlayer.currentX1);
            savedCoordinates.Add((float)Math.Floor(Minecraft.clientInstance.localPlayer.currentY1 - 1));
            savedCoordinates.Add(Minecraft.clientInstance.localPlayer.currentZ1);
            savedPitchAndYaw.Add(Pointers.mousePitch);
            savedPitchAndYaw.Add(Pointers.mouseYaw);
            savedFlightState = Minecraft.clientInstance.localPlayer.isFlying;
            byte[] write = { 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.movementPacket, write);
        }
        public override void onDisable()
        {
            base.onDisable();
            Minecraft.clientInstance.localPlayer.teleport(savedCoordinates[0], savedCoordinates[1], savedCoordinates[2]);
            Pointers.mousePitch = savedPitchAndYaw[0];
            Pointers.mouseYaw = savedPitchAndYaw[1];
            Minecraft.clientInstance.localPlayer.isFlying = savedFlightState;
            savedCoordinates.Clear();
            savedPitchAndYaw.Clear();
            byte[] write = { 0xFF, 0x50, 0x08 };
            MCM.writeBaseBytes(Pointers.movementPacket, write);
        }
    }
}
