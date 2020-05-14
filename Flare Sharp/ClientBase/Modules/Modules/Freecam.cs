using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.Memory;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class Freecam : Module
    {
        List<float> savedCoordinates = new List<float>();
        List<float> savedPitchAndYaw = new List<float>();
        byte savedFlightState;
        public Freecam() : base("Freecam", CategoryHandler.registry.categories[3], (char)0x07, false)
        {
            RegisterToggleSetting("Revert State", true);
        }

        public override void onEnable()
        {
            base.onEnable();
            savedCoordinates.Add(Minecraft.clientInstance.localPlayer.currentX1);
            savedCoordinates.Add((float)Math.Floor(Minecraft.clientInstance.localPlayer.currentY1));
            savedCoordinates.Add(Minecraft.clientInstance.localPlayer.currentZ1);
            savedPitchAndYaw.Add(Minecraft.clientInstance.firstPersonLookBehavior.cameraPitch);
            savedPitchAndYaw.Add(Minecraft.clientInstance.firstPersonLookBehavior.cameraYaw);
            savedFlightState = Minecraft.clientInstance.localPlayer.isFlying;
            byte[] write = { 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Statics.movementPacket, write);
        }

        public override void onDisable()
        {
            base.onDisable();

            if (toggleSettings[0].value)
            {
                Minecraft.clientInstance.localPlayer.teleport(savedCoordinates[0], savedCoordinates[1], savedCoordinates[2]);
                Minecraft.clientInstance.firstPersonLookBehavior.cameraPitch = savedPitchAndYaw[0];
                Minecraft.clientInstance.firstPersonLookBehavior.cameraYaw = savedPitchAndYaw[1];
                Minecraft.clientInstance.localPlayer.isFlying = savedFlightState;
                savedCoordinates.Clear();
                savedPitchAndYaw.Clear();
                byte[] write = { 0xFF, 0x50, 0x08 };
                MCM.writeBaseBytes(Statics.movementPacket, write);
            } else
            {
                savedCoordinates.Clear();
                savedPitchAndYaw.Clear();
                byte[] write = { 0xFF, 0x50, 0x08 };
                MCM.writeBaseBytes(Statics.movementPacket, write);
            }
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.clientInstance.localPlayer.isFlying = 1;
            Minecraft.clientInstance.localPlayer.Y2 = Minecraft.clientInstance.localPlayer.Y1;
        }
    }
}
