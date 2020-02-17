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
        //New version by ASM#6173
        public static List<Entity> getEntityList()
        {
            List<Entity> entityList = new List<Entity>();

            UInt64[] endOffs = { 0xA8, 0x18, 0xB8, 0x48, 0x18, 0x50, 0xA0, 0x0 };
            UInt64 entityListEnd = MCM.baseEvaluatePointer(0x02FFAF50, endOffs);

            UInt64 listSize = MCM.readBaseInt64(0x30366B0);

            for(UInt64 index = 0; index < listSize; index++)
            {
                UInt64[] listOffs = { 0xA8, 0x18, 0xB8, 0x48, 0xD18, 0x50, 0x98, index * 0x8, 0x0 };
                UInt64 addr = MCM.baseEvaluatePointer(0x030366F8, listOffs);
                if(addr == entityListEnd)
                    return entityList;
                Entity eObj = new Entity(addr);
                if (eObj.movedTick > 1)
                {
                    entityList.Add(eObj);
                }//Only allow entities that move (Bye bye NPC's)
            }
            return entityList;
        }
    }
}
