using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class Minecraft
    {
        public static ClientInstance clientInstance {
            get
            {
                return new ClientInstance(MCM.baseEvaluatePointer(0x0307D3A0, MCM.ceByte2uLong("30 0")));
            }
        }
    }
}
