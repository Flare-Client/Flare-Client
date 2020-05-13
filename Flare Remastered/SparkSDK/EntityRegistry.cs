using Flare_Remastered.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Remastered.SparkSDK
{
    public class EntityRegistry : SDKObj
    {
        List<string> targetable = new List<string>();
        public List<Mob> Entities
        {
            get
            {
                List<Mob> entityList = new List<Mob>();
                UInt64 likelySize = MCM.readBaseInt64(0x3090EE0);

                for (UInt64 index = 0; index < likelySize; index++)
                {
                    UInt64[] startOffs = { index * 0x8 };
                    UInt64 indexedEntity = MCM.readInt64(MCM.evaluatePointer(addr, startOffs));
                    if (indexedEntity == Minecraft.clientInstance.localPlayer.addr) continue;

                    Mob eObj = new Mob(indexedEntity);
                    if (eObj.movedTick > 1)
                    {
                        entityList.Add(eObj);
                    }
                }
                return entityList;
            }
        }
        public List<Mob> targetableEntities
        {
            get
            {
                List<Mob> entityList = new List<Mob>();
                UInt64 likelySize = MCM.readBaseInt64(0x3090EE0);

                for (UInt64 index = 0; index < likelySize; index++)
                {
                    UInt64[] startOffs = { index * 0x8 };
                    UInt64 indexedEntity = MCM.readInt64(MCM.evaluatePointer(addr, startOffs));
                    if (indexedEntity == Minecraft.clientInstance.localPlayer.addr) continue;

                    Mob eObj = new Mob(indexedEntity);
                    if (eObj.movedTick > 1)
                    {
                        if (targetable.Contains(eObj.type))
                        {
                            entityList.Add(eObj);
                        }
                    }
                }
                return entityList;
            }
        }
        public EntityRegistry(ulong addr) : base(addr)
        {
            Console.WriteLine("Ent Reg Addr:"+addr.ToString("X"));
        }
    }
}
