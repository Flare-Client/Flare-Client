using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class LocalPlayer : Entity
    {
        public UInt64 addr;
        public LocalPlayer(UInt64 addr) : base(addr)
        {
            this.addr = addr;
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

        public int onGround
        {
            get {
                UInt64[] offs = { 0x178 };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x178 };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public byte isFlying
        {
            get
            {
                UInt64[] offs = { 0xA90 };
                return MCM.readByte(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0xA90 };
                MCM.writeByte(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public byte isInAir
        {
            get
            {
                UInt64[] offs = { 0x8FC };
                return MCM.readByte(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x8FC };
                MCM.writeByte(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public int isInWater
        {
            get
            {
                UInt64[] offs = { 0x23D };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x23D };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public int currentGamemode
        {
            get
            {
                UInt64[] offs = { 0x1DB4 };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x1DB4 };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public int viewCreativeItems
        {
            get
            {
                UInt64[] offs = { 0xAA8 };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0xAA8 };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float airAcceleration
        {
            get
            {
                UInt64[] offs = { 0x8A4 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x8A4 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }

        public float X1
        {
            get
            {
                UInt64[] offs = { 0x430 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x430 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float Y1
        {
            get
            {
                UInt64[] offs = { 0x434 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x434 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float Z1
        {
            get
            {
                UInt64[] offs = { 0x438 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x438 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float X2
        {
            get
            {
                UInt64[] offs = { 0x43C };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x43C };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float Y2
        {
            get
            {
                UInt64[] offs = { 0x440 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x440 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float Z2
        {
            get
            {
                UInt64[] offs = { 0x444 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x444 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public int isFalling
        {
            get
            {
                UInt64[] offs = { 0x194 };
                return MCM.readInt(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x194 };
                MCM.writeInt(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float blockCollisionStep
        {
            get
            {
                UInt64[] offs = { 0x220 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x220 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float velX
        {
            get
            {
                UInt64[] offs = { 0x46C };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x46C };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float velY
        {
            get
            {
                UInt64[] offs = { 0x470 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x470 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float velZ
        {
            get
            {
                UInt64[] offs = { 0x474 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x474 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float yaw
        {
            get
            {
                UInt64[] offs = { 0xF4 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0xF4 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float pitch
        {
            get
            {
                UInt64[] offs = { 0xF0 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0xF0 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
    }
}
