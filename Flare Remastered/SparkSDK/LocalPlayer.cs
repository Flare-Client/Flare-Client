using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class LocalPlayer : PlayerEntity
    {
        public LocalPlayer(UInt64 addr) : base(addr)
        {
        }

        //SDK stuffs
        public EntityRegistry entityRegistry
        {
            get
            {
                return new EntityRegistry(MCM.evaluatePointer(addr + 0x820, MCM.ceByte2uLong("0 118")));
            }
        }
        public Level level
        {
            get
            {
                return new Level(MCM.readInt64(addr + 0x330));
            }
        }
        public PlayerInventoryProxy inventoryProxy
        {
            get
            {
                return new PlayerInventoryProxy(MCM.evaluatePointer(addr, MCM.ceByte2uLong("428 60 5F0 0")));
            }
        }

        public PlayerAttributes playerAttributes
        {
            get
            {
                return new PlayerAttributes(MCM.evaluatePointer(addr+ 0x438, MCM.ceByte2uLong("18 E0 8 0")));
            }
        }

        //Player offset shiz
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

        public Utils.Vec3f lookingVec
        {
            get
            {
                return Utils.directionalVector((Minecraft.clientInstance.localPlayer.yaw + 89.9f) * (float)Math.PI / 178F, Minecraft.clientInstance.localPlayer.pitch * (float)Math.PI / 178F);
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
                return MCM.readByte(addr + 0xAB8);
            }
            set
            {
                MCM.writeByte(addr+ 0xAB8, value);
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
                return MCM.readInt(addr+0x215);
            }
            set
            {
                MCM.writeInt(addr + 0x215, value);
            }
        }
        public int currentGamemode
        {
            get
            {
                return MCM.readInt(addr+ 0x1E74);
            }
            set
            {
                MCM.writeInt(addr + 0x1E74, value);
            }
        }
        public int viewCreativeItems
        {
            get
            {
                return MCM.readInt(addr+ 0xAD0);
            }
            set
            {
                MCM.writeInt(addr + 0xAD0, value);
            }
        }
        public float airAcceleration
        {
            get
            {
                return MCM.readFloat(addr+0x8CC);
            }
            set
            {
                MCM.writeFloat(addr + 0x8CC, value);
            }
        }

        public float X1
        {
            get
            {
                return MCM.readFloat(addr+0x458);
            }
            set
            {
                MCM.writeFloat(addr + 0x458, value);
            }
        }
        public float Y1
        {
            get
            {
                return MCM.readFloat(addr+ 0x45C);
            }
            set
            {
                MCM.writeFloat(addr + 0x45C, value);
            }
        }
        public float Z1
        {
            get
            {
                return MCM.readFloat(addr+0x460);
            }
            set
            {
                MCM.writeFloat(addr + 0x460, value);
            }
        }
        public float X2
        {
            get
            {
                return MCM.readFloat(addr+0x464);
            }
            set
            {
                MCM.writeFloat(addr + 0x464, value);
            }
        }
        public float Y2
        {
            get
            {
                return MCM.readFloat(addr+ 0x468);
            }
            set
            {
                MCM.writeFloat(addr + 0x468, value);
            }
        }
        public float Z2
        {
            get
            {
                return MCM.readFloat(addr+ 0x46C);
            }
            set
            {
                MCM.writeFloat(addr + 0x46C, value);
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
        public float velX
        {
            get
            {
                return MCM.readFloat(addr+0x494);
            }
            set
            {
                MCM.writeFloat(addr + 0x494, value);
            }
        }
        public float velY
        {
            get
            {
                return MCM.readFloat(addr+0x498);
            }
            set
            {
                MCM.writeFloat(addr + 0x498, value);
            }
        }
        public float velZ
        {
            get
            {
                return MCM.readFloat(addr+0x49C);
            }
            set
            {
                MCM.writeFloat(addr + 0x49C, value);
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
                return MCM.readByte(addr+ 0x225A);
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
                return MCM.readInt(addr+ 0x12BE) == 262144;
            }
        }
    }
}
