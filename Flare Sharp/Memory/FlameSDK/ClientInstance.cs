using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class ClientInstance : SDKObj
    {
        public ClientInstance(ulong addr) : base(addr)
        {
        }

        public Game gameInstance
        {
            get
            {
                return new Game(MCM.readInt64(addr + 0x60));
            }
        }
        public LocalPlayer localPlayer
        {
            get
            {
                return new LocalPlayer(MCM.readInt64(addr + 0xF0));
            }
        }
    }
}
