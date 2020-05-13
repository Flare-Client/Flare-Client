using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class RakNetInstance : SDKObj
    {
        public RakNetInstance(ulong addr) : base(addr)
        {

        }

        public string connectedServerIP
        {
            get
            {
                return MCM.readString(MCM.readInt64(addr + 0x360), 30);
            }
        }
    }
}
