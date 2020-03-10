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

        public Mob lookingEntity
        {
            get
            {
                return new Mob(MCM.readInt64(addr + 0x870));
            }
        }

        public FirstPersonLookBehavior firstPersonCamera
        {
            get
            {
                return new FirstPersonLookBehavior(MCM.evaluatePointer(addr, MCM.ceByte2uLong("60 38 0")));
            }
        }
    }
}
