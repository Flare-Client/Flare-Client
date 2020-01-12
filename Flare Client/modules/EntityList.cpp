#include "EntityList.h"
#include "../LittleHacker.h"

using namespace std;

std::vector<uintptr_t> EntityList::EntityListHandler(HANDLE hProcess, uintptr_t localPlayer) {

	//Made by EchoHackCmd

	vector<uintptr_t> entityListArr = {};

	uintptr_t entityListStart = mem::FindAddr(hProcess, localPlayer, { 0x358, 0x40, 0x0 });
	uintptr_t entityListEnd = mem::FindAddr(hProcess, localPlayer, { 0x358, 0x48, 0x0 });

	for (uintptr_t entity = entityListStart; entity < entityListEnd; entity += 0x8) {
		if (entity == entityListStart) continue;
		int movingVal;
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, entity, { Player::movedTick }), &movingVal, sizeof(movingVal), 0);
		if(movingVal > 1) entityListArr.push_back(entity); //Only allow entities that move (Bye bye NPC's)
	}

	return entityListArr;
}
