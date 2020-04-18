using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class FloatOption : SDKObj
    {
        public FloatOption(ulong addr) : base(addr)
        {
        }

        public float playerFOV
        {
            get
            {
                return MCM.readFloat(addr + 0xF0);
            }
            set
            {
                MCM.writeFloat(addr + 0xF0, value);
            }
        }
    }
}
