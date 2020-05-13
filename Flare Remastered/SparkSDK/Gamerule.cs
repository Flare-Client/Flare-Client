using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class Gamerule : SDKObj
    {
        public Gamerule(ulong addr) : base(addr)
        {
        }
        public string name
        {
            get
            {
                byte strLen = MCM.readByte(addr + 0x20);
                if (strLen <= 0xF)
                {
                    return MCM.readString(addr + 8, strLen);
                }
                else
                {
                    return MCM.readString(MCM.readInt64(addr + 8), strLen);
                }
            }
        }
        public bool toggle
        {
            get
            {
                return MCM.readByte(addr + 0x4) >= 1;
            }
            set
            {
                MCM.writeByte(addr + 0x4, Convert.ToByte(value));
            }
        }
    }
}
