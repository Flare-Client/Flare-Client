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
    public class Scaffold : Module
    {
        public Scaffold() : base("Scaffold", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            byte[] write1 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
            MCM.writeBaseBytes(Pointers.blockFace, write1);
        }

        public override void onTick()
        {
            base.onTick();
            UInt64 facing = SDK.instance.entityFacingMP + SDK.instance.entityFacingSP;
            if (facing > 0)
            {
                byte[] write2 = { 0x41, 0x80, 0x38, 0x00, 0x74, 0x76 };
                MCM.writeBaseBytes(Pointers.rapidPlace, write2);
            }
            else
            {
                byte[] write2 = { 0x41, 0x80, 0x38, 0x01, 0x74, 0x76 };
                MCM.writeBaseBytes(Pointers.rapidPlace, write2);
            }

            /*Pointers.blockPlaceFlag = 0;
            Pointers.blockPosX = (int)SDK.instance.player.currentX1;
            Pointers.blockPosY = (int)SDK.instance.player.currentY1 - 2;
            Pointers.blockPosZ = (int)SDK.instance.player.currentZ1;*/

            /*if(SDK.instance.entityFacing == 0)
            {
                Pointers.blockPlaceFlag = 0;
                Pointers.blockPosX = (int)SDK.instance.player.currentX1;
                Pointers.blockPosY = (int)SDK.instance.player.currentY1 - 2;
                Pointers.blockPosZ = (int)SDK.instance.player.currentZ1;
                float yaw = SDK.instance.player.yaw;

                if(yaw >= -135 && yaw <= -90 | yaw >= -90 && yaw <= -45)
                {
                    Pointers.blockSide = 5;
                } 
                else if(yaw <= 135 && yaw >= 90 | yaw <= 90 && yaw >= 45)
                {
                    Pointers.blockSide = 4;
                }
                else if(yaw <= 45 && yaw >= 0 | yaw <= 0 && yaw >= -45)
                {
                    Pointers.blockSide = 3;
                } else
                {
                    Pointers.blockSide = 2;
                }
            }*/

        }

        public override void onDisable()
        {
            base.onDisable();
            byte[] write1 = { 0x41, 0x88, 0x86, 0x54, 0x08, 0x00, 0x00 };
            byte[] write2 = { 0x41, 0x80, 0x38, 0x00, 0x74, 0x76 };
            MCM.writeBaseBytes(Pointers.blockFace, write1);
            MCM.writeBaseBytes(Pointers.rapidPlace, write2);
        }
    }
}
