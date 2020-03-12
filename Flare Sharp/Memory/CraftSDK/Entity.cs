using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Entity
    {
        ulong addr;
        public Entity(ulong addr)
        {
            this.addr = addr;
        }

        public string type
        {
            get
            {
                return MCM.readString(addr+0x388, 20);
            }
        }
        public float hitboxWidth
        {
            get
            {
                return MCM.readFloat(addr + 0x44C);
            }
            set
            {
                MCM.writeFloat(addr + 0x44C, value);
            }
        }
        public float hitboxHeight
        {
            get
            {
                return MCM.readFloat(addr + 0x450);
            }
            set
            {
                MCM.writeFloat(addr + 0x450, value);
            }
        }
        public float currentX1
        {
            get
            {
                return MCM.readFloat(addr + 0x454);
            }
            set
            {
                MCM.writeFloat(addr + 0x454, value);
            }
        }
        public float currentY1
        {
            get
            {
                return MCM.readFloat(addr + 0x458);
            }
            set
            {
                MCM.writeFloat(addr + 0x458, value);
            }
        }
        public float currentZ1
        {
            get
            {
                return MCM.readFloat(addr + 0x45C);
            }
            set
            {
                MCM.writeFloat(addr + 0x45C, value);
            }
        }
        public float currentX2
        {
            get
            {
                return MCM.readFloat(addr + 0x460);
            }
            set
            {
                MCM.writeFloat(addr+0x460, value);
            }
        }
        public float currentY2
        {
            get
            {
                return MCM.readFloat(addr + 0x464);
            }
            set
            {
                MCM.writeFloat(addr+0x464, value);
            }
        }
        public float currentZ2
        {
            get
            {
                return MCM.readFloat(addr+0x468);
            }
            set
            {
                MCM.writeFloat(addr+0x468, value);
            }
        }
        public float currentX3
        {
            get
            {
                return MCM.readFloat(addr+0x8C4);
            }
            set
            {
                MCM.writeFloat(addr + 0x8C4, value);
            }
        }
        public float currentY3
        {
            get
            {
                return MCM.readFloat(addr+0x8C8);
            }
            set
            {
                MCM.writeFloat(addr + 0x8C8, value);
            }
        }
        public float currentZ3
        {
            get
            {
                return MCM.readFloat(addr + 0x8CC);
            }
            set
            {
                MCM.writeFloat(addr + 0x8CC, value);
            }
        }
        public int movedTick
        {
            get
            {
                return MCM.readInt(addr+ 0x32C);
            }
            set
            {
                MCM.writeInt(addr + 0x32C, value);
            }
        }
        public void teleportE(float x, float y, float z)
        {
            currentX1 = x + 0.6f;
            currentY1 = y + 1.8f;
            currentZ1 = z + 0.6f;
        }
        public double distanceTo(Entity e)
        {
            float dX = currentX1 - e.currentX1;
            float dY = currentY1 - e.currentY1;
            float dZ = currentZ1 - e.currentZ1;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }
    }
}
