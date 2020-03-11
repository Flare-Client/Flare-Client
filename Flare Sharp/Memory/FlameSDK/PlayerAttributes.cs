using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.FlameSDK
{
    public class PlayerAttributes : SDKObj
    {
        public PlayerAttributes(ulong addr) : base(addr)
        {
        }

        public AttributeInstance health
        {
            get
            {
                return new AttributeInstance(addr + 0x20);
            }
        }
        public AttributeInstance unknown_1
        {
            get
            {
                return new AttributeInstance(addr + 0x60);
            }
        }
        public AttributeInstance unknown_2
        {
            get
            {
                return new AttributeInstance(addr + 0xE0);
            }
        }
        public AttributeInstance xp
        {
            get
            {
                return new AttributeInstance(addr + 0x130);
            }
        }
        public AttributeInstance hunger
        {
            get
            {
                return new AttributeInstance(addr + 0x170);
            }
        }
        public AttributeInstance unknown_3
        {
            get
            {
                return new AttributeInstance(addr + 0x1B0);
            }
        }
        public AttributeInstance speed
        {
            get
            {
                return new AttributeInstance(addr + 0x1F0);
            }
        }
        public AttributeInstance level
        {
            get
            {
                return new AttributeInstance(addr + 0x200);
            }
        }
        public AttributeInstance unknown_4
        {
            get
            {
                return new AttributeInstance(addr + 0x2C0);
            }
        }
        public AttributeInstance unknown_5
        {
            get
            {
                return new AttributeInstance(addr + 0x390);
            }
        }
    }
}
