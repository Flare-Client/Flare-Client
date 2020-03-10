using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class Level : SDKObj
    {
        public Level(ulong addr) : base(addr)
        {
        }

        public Entity lookingEntity
        {
            get
            {
                return new Entity(MCM.readInt64(addr + 0x870));
            }
        }
    }
}
