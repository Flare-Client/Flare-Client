using Flare_Sharp.ClientBase.Categories;
using Flare_Sharp.ClientBase.Keybinds;
using Flare_Sharp.Memory.CraftSDK;
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
            List<float> directionalVec;
            float walkSpeed = 0.3F;

            if (SDK.instance.player.inventoryIsOpen)
            {
                if (KeybindHandler.isKeyDown((char)0x27)) //Arrow Key -> Right
                {
                    Pointers.mouseYaw -= 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x25)) //Arrow Key -> Left
                {
                    Pointers.mouseYaw += 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x26)) //Arrow Key -> Up
                {
                    Pointers.mousePitch += 0.02F;
                }
                else if (KeybindHandler.isKeyDown((char)0x28)) //Arrow Key -> Down
                {
                    Pointers.mousePitch -= 0.02F;
                }

                if (KeybindHandler.isKeyDown((char)0x20))
                {
                    if (SDK.instance.player.isInAir > 1 | SDK.instance.player.onGround > 0) SDK.instance.player.velY = 0.4F;
                }

                if (KeybindHandler.isKeyDown('W'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                }
                else if (KeybindHandler.isKeyDown('S'))
                {
                    if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -90) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -70) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + -110) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                }
                else if (!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S'))
                {
                    if (KeybindHandler.isKeyDown('A'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                    else if (KeybindHandler.isKeyDown('D'))
                    {
                        directionalVec = SDK.instance.directionalVector((SDK.instance.player.yaw + 180) * (float)Math.PI / 180, (float)Math.PI / 180);
                        SDK.instance.player.velX = walkSpeed * directionalVec[0];
                        SDK.instance.player.velZ = walkSpeed * directionalVec[2];
                    }
                }
            }
        }
    }
}
