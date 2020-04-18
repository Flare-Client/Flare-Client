using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class FirstPersonLookBehavior : SDKObj
    {
        public FirstPersonLookBehavior(ulong addr) : base(addr)
        {
        }

        public float cameraPitch
        {
            get
            {
                return MCM.readFloat(addr + 0x14);
            }
            set
            {
                MCM.writeFloat(addr + 0x14, value);
            }
        }
        public float cameraYaw
        {
            get
            {
                return MCM.readFloat(addr + 0x10);
            }
            set
            {
                MCM.writeFloat(addr + 0x10, value);
            }
        }
    }
}
