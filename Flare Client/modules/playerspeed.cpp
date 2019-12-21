#include "playerspeed.h"

PlayerSpeed::PlayerSpeed(HANDLE hProcess, float value) {
	uintptr_t playerSpeedAddr = mem::FindAddr(hProcess, mem::moduleBase + 0x03016010, { 0x30, 0xF0, 0x410, 0x18, 0xE0, 0x8, 0x9C });
	WriteProcessMemory(hProcess, (BYTE*)playerSpeedAddr, &value, sizeof(value), 0);
}