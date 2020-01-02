#include "jesus.h"

Jesus::Jesus(HANDLE hProcess, uintptr_t localPlayer, float value) {
	uintptr_t inWaterAddr = mem::FindAddr(hProcess, localPlayer, { Player::isInWater });
	uintptr_t velocityYAddr = mem::FindAddr(hProcess, localPlayer, { Player::velocityY });
	int isInWater;
	ReadProcessMemory(hProcess, (BYTE*)inWaterAddr, &isInWater, sizeof(isInWater), 0);
	if (isInWater) {
		WriteProcessMemory(hProcess, (BYTE*)velocityYAddr, &value, sizeof(value), 0);
	}
}