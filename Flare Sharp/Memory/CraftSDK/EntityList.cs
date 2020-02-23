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

            UInt64[] endOffs = { 0xA8, 0x18, 0xB8, 0x48, 0xD18, 0x50, 0xA0, 0x0 };
            UInt64 entityListEnd = MCM.readInt64(MCM.baseEvaluatePointer(0x02FFAF50, endOffs));

            UInt64 likelySize = MCM.readBaseInt64(0x30366B0);

            for (UInt64 index = 0; index<likelySize; index++)
            {
                UInt64[] startOffs = { 0xA8, 0x18, 0xB8, 0x48, 0xD18, 0x50, 0x98, index*0x8 };
                UInt64 indexedEntity = MCM.readInt64(MCM.baseEvaluatePointer(0x02FFAF50, startOffs));
                if (indexedEntity == SDK.instance.player.addr) continue;
                if (indexedEntity == entityListEnd) 
                    break;

                Entity eObj = new Entity(indexedEntity);
                entityList.Add(eObj);
                /*
                if (eObj.movedTick > 1)
                {
                    entityList.Add(eObj);
                }//Only allow entities that move (Bye bye NPC's)
                *///Hi NPCs... sorry you werent invited last time...
            }
            return entityList;
        }

        public static List<PlayerEntity> getPlayerList()
        {
            List<PlayerEntity> playerEntityList = new List<PlayerEntity>();
            List<Entity> entityList = getEntityList();
            foreach (Entity entity in entityList)
            {
                if (entity.addr == SDK.instance.player.addr) continue;
                if (entity.type == "player")
                {
                    playerEntityList.Add(new PlayerEntity(entity.addr));
                }
            }
            return playerEntityList;
        }
    }
}
