using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class Minecraft
    {
        public static ClientInstance clientInstance {
            get
            {
                return new ClientInstance(MCM.baseEvaluatePointer(0x03022AE0, MCM.ceByte2uLong("30 0")));
            }
        }
    }
}
