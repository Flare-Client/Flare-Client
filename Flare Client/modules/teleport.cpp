#include "teleport.h"

Teleport::Teleport(HANDLE hProcess, float X, float Y, float Z) {

	uintptr_t localPlayer = mem::FindAddr(hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x10, 0x40, 0x0 }); //Can't pass as parameter since local player isn't defined within GuiLoader
	float X2 = X + 0.6;
	float Y2 = Y + 1.8;
	float Z2 = Z + 0.6;

	uintptr_t xCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { 0x430 });
	uintptr_t xCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { 0x43C });

	uintptr_t yCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { 0x434 });
	uintptr_t yCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { 0x440 });

	uintptr_t zCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { 0x438 });
	uintptr_t zCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { 0x444 });

	WriteProcessMemory(hProcess, (BYTE*)xCoordinateAddr1, &X, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)xCoordinateAddr2, &X2, sizeof(float), 0);

	WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr1, &Y, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr2, &Y2, sizeof(float), 0);

	WriteProcessMemory(hProcess, (BYTE*)zCoordinateAddr1, &Z, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)zCoordinateAddr2, &Z2, sizeof(float), 0);
}