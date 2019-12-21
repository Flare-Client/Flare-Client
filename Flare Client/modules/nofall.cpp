#include "nofall.h"

NoFall::NoFall(HANDLE hProcess, uintptr_t LocalPlayer) {
	uintptr_t noFallAddr = mem::FindAddr(hProcess, LocalPlayer, { 0x194 });
	int val = 0;
	WriteProcessMemory(hProcess, (BYTE*)noFallAddr, &val, sizeof(val), 0);
}