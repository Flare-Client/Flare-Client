using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class Mob : Actor
    {
        public Mob(ulong addr):base(addr)
        {
        }

        public Utils.Vec3f location
        {
            get
            {
                Utils.Vec3f vec3 = new Utils.Vec3f();
                vec3.x = currentX1;
                vec3.y = currentY1;
                vec3.z = currentZ1;
                return vec3;
            }
            set
            {
                teleportE(value.x, value.y, value.z);
            }
        }
        public string type
        {
            get
            {
                return MCM.readString(addr+ 0x3B0, 20);
            }
        }
        public float hitboxWidth
        {
            get
            {
                return MCM.readFloat(addr + 0x474);
            }
            set
            {
                MCM.writeFloat(addr + 0x474, value);
            }
        }
        public float hitboxHeight
        {
            get
            {
                return MCM.readFloat(addr + 0x478);
            }
            set
            {
                MCM.writeFloat(addr + 0x478, value);
            }
        }
        public float currentX1
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
        public float currentY1
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
        public float currentZ1
        {
            get
            {
                return MCM.readFloat(addr + 0x460);
            }
            set
            {
                MCM.writeFloat(addr + 0x460, value);
            }
        }
        public float currentX2
        {
            get
            {
                return MCM.readFloat(addr + 0x464);
            }
            set
            {
                MCM.writeFloat(addr+ 0x464, value);
            }
        }
        public float currentY2
        {
            get
            {
                return MCM.readFloat(addr + 0x468);
            }
            set
            {
                MCM.writeFloat(addr+ 0x468, value);
            }
        }
        public float currentZ2
        {
            get
            {
                return MCM.readFloat(addr+ 0x46C);
            }
            set
            {
                MCM.writeFloat(addr+ 0x46C, value);
            }
        }
        public float currentX3
        {
            get
            {
                return MCM.readFloat(addr+0x488);
            }
            set
            {
                MCM.writeFloat(addr + 0x488, value);
            }
        }
        public float currentY3
        {
            get
            {
                return MCM.readFloat(addr+ 0x48C);
            }
            set
            {
                MCM.writeFloat(addr + 0x48C, value);
            }
        }
        public float currentZ3
        {
            get
            {
                return MCM.readFloat(addr + 0x490);
            }
            set
            {
                MCM.writeFloat(addr + 0x490, value);
            }
        }
        public int movedTick
        {
            get
            {
                return MCM.readInt(addr+ 0x304);
            }
            set
            {
                MCM.writeInt(addr + 0x304, value);
            }
        }
        public void teleportE(float x, float y, float z)
        {
            currentX1 = x + 0.6f;
            currentY1 = y + 1.8f;
            currentZ1 = z + 0.6f;
        }
        public double distanceTo(Mob e)
        {
            float dX = currentX1 - e.currentX1;
            float dY = currentY1 - e.currentY1;
            float dZ = currentZ1 - e.currentZ1;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }
    }
}
