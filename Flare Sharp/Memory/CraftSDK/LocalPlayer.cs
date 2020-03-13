using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class LocalPlayer : PlayerEntity
    {
        public LocalPlayer(UInt64 addr) : base(addr)
        {
        }

        public void teleport(float x, float y, float z)
        {
            currentX1 = x;
            currentY1 = y;
            currentZ1 = z;
            X1 = x;
            X2 = x + 0.6f;
            Y1 = y;
            Y2 = y + 1.8f;
            Z1 = z;
            Z2 = z + 0.6f;
        }

        public double velocityXZ
        {
            get
            {
                return Math.Sqrt(velX * velX + velZ * velZ);
            }
        }

        public double velocityXYZ
        {
            get
            {
                return Math.Sqrt(velX * velX + velY * velY + velZ * velZ);
            }
        }

        public List<float> lookingVec
        {
            get
            {
                return SDK.instance.directionalVector((SDK.client.localPlayer.yaw + 89.9f) * (float)Math.PI / 178F, SDK.client.localPlayer.pitch * (float)Math.PI / 178F);
            }
        }

        public byte onGround
        {
            get {
                return MCM.readByte(addr+0x178);
            }
            set
            {
                MCM.writeByte(addr+0x178, value);
            }
        }
        public int onGround_type2
        {
            get
            {
                return MCM.readInt(addr + 0x17B);
            }
        }
        public byte isFlying
        {
            get
            {
                return MCM.readByte(addr + 0xA90);
            }
            set
            {
                MCM.writeByte(addr+0xA90, value);
            }
        }
        public byte isInAir
        {
            get
            {
                return MCM.readByte(addr+0x17C);
            }
            set
            {
                MCM.writeByte(addr+0x17C, value);
            }
        }
        public int isInWater
        {
            get
            {
                return MCM.readInt(addr+0x23D);
            }
            set
            {
                MCM.writeInt(addr + 0x23D, value);
            }
        }
        public int currentGamemode
        {
            get
            {
                return MCM.readInt(addr+ 0x1DB4);
            }
            set
            {
                MCM.writeInt(addr + 0x1DB4, value);
            }
        }
        public int viewCreativeItems
        {
            get
            {
                return MCM.readInt(addr+ 0xAA8);
            }
            set
            {
                MCM.writeInt(addr + 0xAA8, value);
            }
        }
        public float airAcceleration
        {
            get
            {
                return MCM.readFloat(addr+0x8A4);
            }
            set
            {
                MCM.writeFloat(addr + 0x8A4, value);
            }
        }

        public float X1
        {
            get
            {
                return MCM.readFloat(addr+0x430);
            }
            set
            {
                MCM.writeFloat(addr + 0x430, value);
            }
        }
        public float Y1
        {
            get
            {
                return MCM.readFloat(addr+0x434);
            }
            set
            {
                MCM.writeFloat(addr + 0x434, value);
            }
        }
        public float Z1
        {
            get
            {
                return MCM.readFloat(addr+0x438);
            }
            set
            {
                MCM.writeFloat(addr + 0x438, value);
            }
        }
        public float X2
        {
            get
            {
                return MCM.readFloat(addr+0x43C);
            }
            set
            {
                MCM.writeFloat(addr + 0x43C, value);
            }
        }
        public float Y2
        {
            get
            {
                return MCM.readFloat(addr+0x440);
            }
            set
            {
                MCM.writeFloat(addr + 0x440, value);
            }
        }
        public float Z2
        {
            get
            {
                return MCM.readFloat(addr+0x444);
            }
            set
            {
                MCM.writeFloat(addr + 0x444, value);
            }
        }
        public int isFalling
        {
            get
            {
                return MCM.readInt(addr+0x194);
            }
            set
            {
                MCM.writeInt(addr + 0x194, value);
            }
        }
        public float blockCollisionStep
        {
            get
            {
                return MCM.readFloat(addr+0x220);
            }
            set
            {
                MCM.writeFloat(addr + 0x220, value);
            }
        }
        public float velX
        {
            get
            {
                return MCM.readFloat(addr+0x46C);
            }
            set
            {
                MCM.writeFloat(addr + 0x46C, value);
            }
        }
        public float velY
        {
            get
            {
                return MCM.readFloat(addr+0x470);
            }
            set
            {
                MCM.writeFloat(addr + 0x470, value);
            }
        }
        public float velZ
        {
            get
            {
                return MCM.readFloat(addr+0x474);
            }
            set
            {
                MCM.writeFloat(addr + 0x474, value);
            }
        }
        public float yaw
        {
            get
            {
                return MCM.readFloat(addr+0xF4);
            }
            set
            {
                MCM.writeFloat(addr + 0xF4, value);
            }
        }
        public float pitch
        {
            get
            {
                return MCM.readFloat(addr+0xF0);
            }
            set
            {
                MCM.writeFloat(addr + 0xF0, value);
            }
        }

        public byte heldItemCount
        {
            get
            {
                return MCM.readByte(addr+0x2102);
            }
            set
            {
                MCM.writeByte(addr + 0x2102, value);
            }
        }

        public int heldItemID
        {
            get
            {
                return MCM.readInt(addr+0x10E2);
            }
            set
            {
                MCM.writeInt(addr + 0x10E2, value);
            }
        }
        public bool inventoryIsOpen //Located near held item ID
        {
            get
            {
                return MCM.readInt(addr+0x11FE) == 262144;
            }
        }
    }
}
