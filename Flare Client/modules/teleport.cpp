#include "teleport.h"

Teleport::Teleport(HANDLE hProcess, float X, float Y, float Z) {

	uintptr_t localPlayer = Player::LocalPlayer();
	float X2 = X + 0.6;
	float Y2 = Y + 1.8;
	float Z2 = Z + 0.6;

	uintptr_t xCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { Player::currentX1 });
	uintptr_t xCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { Player::currentX2 });

	uintptr_t yCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { Player::currentY1 });
	uintptr_t yCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { Player::currentY2 });

	uintptr_t zCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { Player::currentZ1 });
	uintptr_t zCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { Player::currentZ2 });

	WriteProcessMemory(hProcess, (BYTE*)xCoordinateAddr1, &X, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)xCoordinateAddr2, &X2, sizeof(float), 0);

	WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr1, &Y, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr2, &Y2, sizeof(float), 0);

	WriteProcessMemory(hProcess, (BYTE*)zCoordinateAddr1, &Z, sizeof(float), 0);
	WriteProcessMemory(hProcess, (BYTE*)zCoordinateAddr2, &Z2, sizeof(float), 0);
}