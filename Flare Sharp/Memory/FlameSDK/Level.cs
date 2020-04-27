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

        public ulong setLookingEnt
        {
            set
            {
                MCM.writeInt64(addr + 0x870, value);
            }
        }

        public int lookingState
        {
            get
            {
                return MCM.readInt(addr + 0x850);
            }
            set
            {
                MCM.writeInt(addr + 0x850, value);
            }
        }

        public int lookingBlockSide 
        {
            get
            {
                return MCM.readInt(addr + 0x854);
            }
            set
            {
                MCM.writeInt(addr + 0x854, value);
            }
        }
        public int lookingBlockX
        {
            get
            {
                return MCM.readInt(addr + 0x858);
            }
            set
            {
                MCM.writeInt(addr + 0x858, value);
            }
        }
        public int lookingBlockY
        {
            get
            {
                return MCM.readInt(addr + 0x85C);
            }
            set
            {
                MCM.writeInt(addr + 0x85C, value);
            }
        }
        public int lookingBlockZ
        {
            get
            {
                return MCM.readInt(addr + 0x860);
            }
            set
            {
                MCM.writeInt(addr + 0x860, value);
            }
        }

        public List<Mob> getMovingEntities
        {
            get
            {
                List<Mob> Entities = new List<Mob>();
                ulong startList = MCM.readInt64(addr + 0x40);
                ulong endList = MCM.readInt64(addr + 0x48);
                for (ulong ent = startList; ent < endList; ent += 0x8)
                {
                    if (ent == startList) continue;
                    Mob entObj = new Mob(MCM.readInt64(ent));
                    if (entObj.movedTick > 1) Entities.Add(entObj);
                }
                return Entities;
            }
        }

        public List<Mob> getAllEntities
        {
            get
            {
                List<Mob> Entities = new List<Mob>();
                ulong startList = MCM.readInt64(addr + 0x40);
                ulong endList = MCM.readInt64(addr + 0x48);
                for (ulong ent = startList; ent < endList; ent += 0x8)
                {
                    if (ent == startList) continue;
                    Mob entObj = new Mob(MCM.readInt64(ent));
                    Entities.Add(entObj);
                }
                return Entities;
            }
        }

        public List<Gamerule> gamerules
        {
            get
            {
                List<Gamerule> returnRules = new List<Gamerule>();
                for (ulong ruleIndex = 0; ruleIndex < 28; ruleIndex++)
                {
                    returnRules.Add(new Gamerule(MCM.readInt64(addr + 0x340) + (ruleIndex * 176)));
                }
                return returnRules;
            }
        }
    }
}
