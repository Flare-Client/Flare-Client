#include "airaccelerationspeed.h"

using namespace std;

AirAccelerationSpeed::AirAccelerationSpeed(HANDLE hProcess, uintptr_t localPlayer, float value) {
	uintptr_t AirAccSpeedAddr = mem::FindAddr(hProcess, localPlayer, { 0x8A4 });
	WriteProcessMemory(hProcess, (BYTE*)AirAccSpeedAddr, &value, sizeof(value), 0);
}