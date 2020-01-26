using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class Entity
    {
        UInt64 addr;
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
    }
}
