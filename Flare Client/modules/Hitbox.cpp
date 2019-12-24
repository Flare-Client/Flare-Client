#include "Hitbox.h"
#include "../LittleHacker.h"

Hitbox::Hitbox(HANDLE hProcess, std::vector<uintptr_t> EntityList, float width, float height) {
	for (int entity = 0; entity < EntityList.size(); entity++) {
		uintptr_t EntityWidthAddr = mem::FindAddr(hProcess, EntityList[entity], { 0x44C });
		uintptr_t EntityHeightAddr = mem::FindAddr(hProcess, EntityList[entity], { 0x450 });
		WriteProcessMemory(hProcess, (BYTE*)EntityWidthAddr, &width, sizeof(width), 0);
		WriteProcessMemory(hProcess, (BYTE*)EntityHeightAddr, &height, sizeof(height), 0);
	}
}