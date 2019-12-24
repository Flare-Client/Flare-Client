#include "Hitbox.h"
#include "../LittleHacker.h"

float Hitbox::HitboxWidth(HANDLE hProcess, std::vector<uintptr_t> EntityList, float value) {
	for (int entity = 0; entity < EntityList.size(); entity++) {
		uintptr_t EntityWidthAddr = mem::FindAddr(hProcess, EntityList[entity], { 0x44C });
		WriteProcessMemory(hProcess, (BYTE*)EntityWidthAddr, &value, sizeof(value), 0);
	}
}

float Hitbox::HitboxHeight(HANDLE hProcess, std::vector<uintptr_t> EntityList, float value) {
	for (int entity = 0; entity < EntityList.size(); entity++) {
		uintptr_t EntityWidthAddr = mem::FindAddr(hProcess, EntityList[entity], { 0x450 });
		WriteProcessMemory(hProcess, (BYTE*)EntityWidthAddr, &value, sizeof(value), 0);
	}
}