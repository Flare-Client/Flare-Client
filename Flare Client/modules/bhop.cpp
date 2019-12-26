#include "bhop.h"

BHOP::BHOP(HANDLE hProcess, uintptr_t localPlayer, float value) {
	uintptr_t isOnGroundAddr = mem::FindAddr(hProcess, localPlayer, { 0x17C });
	uintptr_t velocityYAddr = mem::FindAddr(hProcess, localPlayer, { 0x470 });
	int isOnGround;
	ReadProcessMemory(hProcess, (BYTE*)isOnGroundAddr, &isOnGround, sizeof(isOnGround), 0);
	if (isOnGround) {
		WriteProcessMemory(hProcess, (BYTE*)velocityYAddr, &value, sizeof(value), 0);
	}
}