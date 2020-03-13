using Flare_Sharp.ClientBase.UI.VObjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flare_Sharp.Memory.CraftSDK
{
    public class EntityList
    {
        public static List<string> targetable
        {
            get
            {
                List<string> returned = new List<string>();
                foreach(VStringShelf shelf in VTargetsWindow.instance.targetObjects)
                {
                    returned.Add(shelf.text);
                }
                return returned;
            }
        }
        //Made by EchoHackCmd
        public static List<Entity> getEntityList(bool filter)
        {
            List<Entity> entityList = new List<Entity>();
            UInt64 likelySize = MCM.readBaseInt64(0x30366B0);

            for (UInt64 index = 0; index<likelySize; index++)
            {
                UInt64[] startOffs = { 0x30, 0xF0, 0x8, 0x50, 0x120, 0x38, index*0x8 };
                UInt64 indexedEntity = MCM.readInt64(MCM.baseEvaluatePointer(0x03022AE0, startOffs));
                if (indexedEntity == SDK.client.localPlayer.addr) continue;

                Entity eObj = new Entity(indexedEntity);
                if (eObj.movedTick > 1)
                {
                    if (filter)
                    {
                        if (targetable.Contains(eObj.type))
                        {
                            entityList.Add(eObj);
                        }
                    }
                    else
                        entityList.Add(eObj);
                }
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
            List<Entity> entityList = getEntityList(false);
            foreach (Entity entity in entityList)
            {
                if (entity.addr == SDK.client.localPlayer.addr) continue;
                if (entity.type == "player")
                {
                    playerEntityList.Add(new PlayerEntity(entity.addr));
                }
            }
            return playerEntityList;
        }

        public static ulong SwapEndianness(ulong value)
        {
            var b1 = (value >> 0) & 0xff;
            var b2 = (value >> 8) & 0xff;
            var b3 = (value >> 16) & 0xff;
            var b4 = (value >> 24) & 0xff;

            return b1 << 24 | b2 << 16 | b3 << 8 | b4 << 0;
        }
    }
}
