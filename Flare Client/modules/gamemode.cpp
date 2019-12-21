#include "gamemode.h"

using namespace std;

Gamemode::Gamemode(HANDLE hProcess, uintptr_t LocalPlayer, int gamemodeVal) {
	uintptr_t gamemodeAddr = mem::FindAddr(hProcess, LocalPlayer, { 0x1D9C });
	WriteProcessMemory(hProcess, (BYTE*)gamemodeAddr, &gamemodeVal, sizeof(gamemodeVal), 0);
}