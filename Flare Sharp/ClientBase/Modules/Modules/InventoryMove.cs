using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.FlameSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.ClientBase.Modules.Modules
{
    public class InventoryMove : Module
    {
        public InventoryMove() : base("InventoryMove", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Utils.Vec3f directionalVec;
            float walkSpeed = 0.3F;

            if (Minecraft.clientInstance.localPlayer.inventoryIsOpen)
            {
                if (KeybindHandler.isKeyDown((char)0x27)) //Arrow Key -> Right
                {
                    Statics.mouseYaw -= 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x25)) //Arrow Key -> Left
                {
                    Statics.mouseYaw += 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x26)) //Arrow Key -> Up
                {
                    Statics.mousePitch += 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x28)) //Arrow Key -> Down
                {
                    Statics.mousePitch -= 0.02F;
                }

                if (KeybindHandler.isKeyDown((char)0x20))
                {
                    if (Minecraft.clientInstance.localPlayer.isInAir > 1 | Minecraft.clientInstance.localPlayer.onGround > 0) Minecraft.clientInstance.localPlayer.velY = 0.4F;
                }

                if (KeybindHandler.isKeyDown('W'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                    else if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                }
                else if (KeybindHandler.isKeyDown('S'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + -90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                    else if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + -70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + -110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                }
                else if (!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S'))
                {
                    if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 180) * (float)Math.PI / 180, (float)Math.PI / 180);
                        Minecraft.clientInstance.localPlayer.velX = walkSpeed * directionalVec.x;
                        Minecraft.clientInstance.localPlayer.velZ = walkSpeed * directionalVec.z;
                    }
                }
            }
        }
    }
}
