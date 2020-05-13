using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class PlayerEntity : Mob
    {
        public PlayerEntity(UInt64 addr) : base(addr)
        {
        }

        public string username
        {
            get
            {
                return MCM.readString(addr+ 0xA18, 20);
            }
        }
    }
}
