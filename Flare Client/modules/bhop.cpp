#include "bhop.h"

BHOP::BHOP(HANDLE hProcess, uintptr_t localPlayer, float value) {
	uintptr_t isOnGroundAddr = mem::FindAddr(hProcess, localPlayer, { Player::onGround });
	uintptr_t velocityYAddr = mem::FindAddr(hProcess, localPlayer, { Player::velocityY });
	int isOnGround;
	ReadProcessMemory(hProcess, (BYTE*)isOnGroundAddr, &isOnGround, sizeof(isOnGround), 0);
	if (isOnGround) {
		WriteProcessMemory(hProcess, (BYTE*)velocityYAddr, &value, sizeof(value), 0);
	}
}