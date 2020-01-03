#include "scaffold.h"

Scaffold::Scaffold(HANDLE hProcess, int toggle) {
	uintptr_t targetAddr = mem::moduleBase + 0x5D240B;
	uintptr_t additionalAddr = mem::moduleBase + 0x5D2410;
	uintptr_t yawAddr = mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentYaw });
	float yaw, currentX, currentY, currentZ;
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentX1 }), &currentX, sizeof(float), 0);
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentY1 }), &currentY, sizeof(float), 0);
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentZ1 }), &currentZ, sizeof(float), 0);
	int blockPosX = static_cast<int>(floor(currentX));
	int blockPosY = static_cast<int>(floor(currentY) - 1);
	int blockPosZ = static_cast<int>(floor(currentZ));
	byte canPlace = 0;
	ReadProcessMemory(hProcess, (BYTE*)yawAddr, &yaw, sizeof(yaw), 0);
	if (toggle) {
		if (yaw > -135 && yaw < -45) { //East
			mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\xB0\x05\x90\x90\x90", 5, hProcess);
			mem::NopEx((BYTE*)additionalAddr, 2, hProcess);
			WriteProcessMemory(hProcess, (BYTE*)pointers::canPlaceBlock(), &canPlace, sizeof(byte), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordX(), &blockPosX, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordY(), &blockPosY, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordZ(), &blockPosZ, sizeof(int), 0);
		}
		else if (yaw < 135 && yaw > 45) { //West
			mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\xB0\x04\x90\x90\x90", 5, hProcess);
			mem::NopEx((BYTE*)additionalAddr, 2, hProcess);
			WriteProcessMemory(hProcess, (BYTE*)pointers::canPlaceBlock(), &canPlace, sizeof(byte), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordX(), &blockPosX, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordY(), &blockPosY, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordZ(), &blockPosZ, sizeof(int), 0);
		}
		else if (yaw > -45 && yaw < 45) { //South
			mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\xB0\x03\x90\x90\x90", 5, hProcess);
			mem::NopEx((BYTE*)additionalAddr, 2, hProcess);
			WriteProcessMemory(hProcess, (BYTE*)pointers::canPlaceBlock(), &canPlace, sizeof(byte), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordX(), &blockPosX, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordY(), &blockPosY, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordZ(), &blockPosZ, sizeof(int), 0);
		}
		else if (yaw > -135 && yaw > 179 || yaw < 179 && yaw > 135) { //North
			mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\xB0\x02\x90\x90\x90", 5, hProcess);
			mem::NopEx((BYTE*)additionalAddr, 2, hProcess);
			WriteProcessMemory(hProcess, (BYTE*)pointers::canPlaceBlock(), &canPlace, sizeof(byte), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordX(), &blockPosX, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordY(), &blockPosY, sizeof(int), 0);
			WriteProcessMemory(hProcess, (BYTE*)pointers::blockCoordZ(), &blockPosZ, sizeof(int), 0);
		}
		if (GetAsyncKeyState(VK_LBUTTON)) {
			byte val = 0;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
		} else if (!GetAsyncKeyState(VK_LBUTTON)) {
			byte val = 1;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
		}
	} 
	else if (!toggle) {
		mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\x0F\xB6\x85\x9C\x00\x00\x00", 7, hProcess);
	}
}