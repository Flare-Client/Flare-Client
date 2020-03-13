using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class WeaponItem : Item
    {
        public WeaponItem(ulong addr) : base(addr) { }
        public int attackDamage
        {
            get
            {
                //MCM.readInt(addr + 0x1C0);
                return 0;
            }
            set
            {
                MCM.writeInt(addr + 0x1C0, value);
            }
        }
    }
}
