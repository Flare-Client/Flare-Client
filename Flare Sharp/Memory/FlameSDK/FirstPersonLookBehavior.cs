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
                return MCM.readFloat(addr + 0x250);
            }
            set
            {
                MCM.writeFloat(addr + 0x250, value);
            }
        }
        public float cameraYaw
        {
            get
            {
                return MCM.readFloat(addr + 0x254);
            }
            set
            {
                MCM.writeFloat(addr + 0x254, value);
            }
        }
    }
}
