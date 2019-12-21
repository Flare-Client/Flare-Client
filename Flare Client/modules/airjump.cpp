#include "airjump.h"

using namespace std;

AirJump::AirJump(HANDLE hProcess, uintptr_t localPlayer) {
	int canJump = 1;
	WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, localPlayer, { 0x178 }), &canJump, sizeof(canJump), 0);
}