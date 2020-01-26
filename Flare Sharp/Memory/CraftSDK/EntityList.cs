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

            UInt64[] startOffs = { 0x358, 0x40, 0x0 };
            UInt64 entityListStart = MCM.evaluatePointer(SDK.instance.player.addr, startOffs);
            UInt64[] endOffs = { 0x358, 0x48, 0x0 };
            UInt64 entityListEnd = MCM.evaluatePointer(SDK.instance.player.addr, endOffs);

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
