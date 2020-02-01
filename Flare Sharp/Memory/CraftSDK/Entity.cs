using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Entity
    {
        public UInt64 addr;
        public Entity(UInt64 addr)
        {
            this.addr = addr;
        }

        public float hitboxWidth
        {
            get
            {
                UInt64[] offs = { 0x44C };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x44C };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float hitboxHeight
        {
            get
            {
                UInt64[] offs = { 0x450 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x450 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentX1
        {
            get
            {
                UInt64[] offs = { 0x454 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x454 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentY1
        {
            get
            {
                UInt64[] offs = { 0x458 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x458 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentZ1
        {
            get
            {
                UInt64[] offs = { 0x45C };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x45C };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentX2
        {
            get
            {
                UInt64[] offs = { 0x460 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x460 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentY2
        {
            get
            {
                UInt64[] offs = { 0x464 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x464 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentZ2
        {
            get
            {
                UInt64[] offs = { 0x468 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x468 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentX3
        {
            get
            {
                UInt64[] offs = { 0x8C4 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x8C4 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentY3
        {
            get
            {
                UInt64[] offs = { 0x8C8 };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x8C8 };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public float currentZ3
        {
            get
            {
                UInt64[] offs = { 0x8CC };
                return MCM.readFloat(MCM.evaluatePointer(addr, offs));
            }
            set
            {
                UInt64[] offs = { 0x8CC };
                MCM.writeFloat(MCM.evaluatePointer(addr, offs), value);
            }
        }
        public int movedTick
        {
            get
            {
                UInt64[] movedTic = { 0x32C };
                return MCM.readInt(MCM.evaluatePointer(addr, movedTic));
            }
            set
            {
                UInt64[] movedTic = { 0x32C };
                MCM.writeInt(MCM.evaluatePointer(addr, movedTic), value);
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
