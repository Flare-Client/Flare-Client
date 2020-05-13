using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public abstract class SDKObj
    {
        public ulong addr;
        public SDKObj(ulong addr)
        {
            this.addr = addr;
        }
    }
}
