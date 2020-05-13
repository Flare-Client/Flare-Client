using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class Game : SDKObj
    {
        public Game(ulong addr) : base(addr)
        {

        }

        public Graphics graphics
        {
            get
            {
                return new Graphics(MCM.readInt64(addr + 0x38));
            }
        }
    }
}
