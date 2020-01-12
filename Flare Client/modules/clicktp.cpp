#include "clicktp.h"

ClickTP::ClickTP(HANDLE hProcess, uintptr_t LocalPlayer) {
	if (GetAsyncKeyState(VK_RBUTTON)) {
		int blockPosX, blockPosY, blockPosZ;
		ReadProcessMemory(hProcess, (BYTE*)pointers::blockCoordX(), &blockPosX, sizeof(int), 0);
		ReadProcessMemory(hProcess, (BYTE*)pointers::blockCoordY(), &blockPosY, sizeof(int), 0);
		ReadProcessMemory(hProcess, (BYTE*)pointers::blockCoordZ(), &blockPosZ, sizeof(int), 0);
		if (blockPosX && blockPosY && blockPosZ) {
			float tpX = static_cast<float>(blockPosX);
			float tpY = static_cast<float>(blockPosY + 1);
			float tpZ = static_cast<float>(blockPosZ);
			Teleport::Teleport(hProcess, tpX, tpY, tpZ);
		}
	}
}