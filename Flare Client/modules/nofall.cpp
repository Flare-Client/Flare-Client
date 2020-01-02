#include "nofall.h"

NoFall::NoFall(HANDLE hProcess, uintptr_t LocalPlayer) {
	uintptr_t noFallAddr = mem::FindAddr(hProcess, LocalPlayer, { Player::isFalling });
	int val = 0;
	WriteProcessMemory(hProcess, (BYTE*)noFallAddr, &val, sizeof(val), 0);
}