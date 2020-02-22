using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class EntityList
    {
        //Made by EchoHackCmd
        public static List<Entity> getEntityList()
        {
            List<Entity> entityList = new List<Entity>();

            UInt64[] endOffs = { 0xA8, 0x18, 0xB8, 0x48, 0x18, 0x50, 0xA0, 0x0 };
            UInt64 entityListEnd = MCM.readInt64(MCM.baseEvaluatePointer(0x02FFAF50, endOffs));

            for (UInt64 entity = entityListStart; entity < entityListEnd; entity += 0x8)
            {
                if (entity == entityListStart) continue;

                Entity eObj = new Entity(entity);

                if (eObj.movedTick > 1)
                {
                    entityList.Add(eObj);
                }//Only allow entities that move (Bye bye NPC's)
            }
            return entityList;
        }
    }
}
