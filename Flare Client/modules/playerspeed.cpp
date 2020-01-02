#include "playerspeed.h"

PlayerSpeed::PlayerSpeed(HANDLE hProcess, float value) {
	uintptr_t playerSpeedAddr = pointers::playerSpeed();
	WriteProcessMemory(hProcess, (BYTE*)playerSpeedAddr, &value, sizeof(value), 0);
}