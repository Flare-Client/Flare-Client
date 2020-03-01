using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity(UInt64 addr) : base(addr)
        {
        }

        public string username
        {
            get
            {
                return MCM.readString(addr+0x9E8, 20);
            }
        }
    }
}
