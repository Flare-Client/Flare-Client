#include "scaffold.h"

/*
uintptr_t scaffoldSideAddr = mem::moduleBase + 0x5D240B;
uintptr_t additionalAddr = mem::moduleBase + 0x5D2410;

mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\xB0\x05\x90\x90\x90", 5, hProcess);
mem::NopEx((BYTE*)additionalAddr, 2, hProcess);

//Origin mem::PatchEx((BYTE*)targetAddr, (BYTE*)"\x0F\xB6\x85\x9C\x00\x00\x00", 7, hProcess);
*/

uintptr_t scaffoldSideAddr = mem::moduleBase + 0x5D240B;
uintptr_t additionalAddr = mem::moduleBase + 0x5D2410;

bool scaffoldRapidToggle;

Scaffold::Scaffold(HANDLE hProcess, int toggle) {

	scaffoldRapidToggle = true;

	uintptr_t facingEnt;
	ReadProcessMemory(hProcess, (BYTE*)pointers::entityFacing(), &facingEnt, sizeof(facingEnt), 0);

	int onGround;
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::onGround }), &onGround, sizeof(int), 0);

	if (toggle && onGround) {

		float playerYaw, currentX, currentY, currentZ;
		int blockPosX, blockPosY, blockPosZ;

		if (GetAsyncKeyState(VK_LBUTTON)) {
			if (!facingEnt) {
				byte val = 0;
				WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
			}
		}
		if (!GetAsyncKeyState(VK_LBUTTON)) {
			if (!facingEnt) {
				byte val = 1;
				WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
			}
		}

		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentYaw }), &playerYaw, sizeof(float), 0);
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentX1 }), &currentX, sizeof(float), 0);
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentY1 }), &currentY, sizeof(float), 0);
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentZ1 }), &currentZ, sizeof(float), 0);

		blockPosX = static_cast<int>(floor(currentX));
		blockPosY = static_cast<int>(floor(currentY - 1));
		blockPosZ = static_cast<int>(floor(currentZ));

		if (playerYaw >= -135 && playerYaw < -90 || playerYaw < -45 && playerYaw >= -90) {
			Scaffold::SpecifyBlockFace(5);
			Scaffold::SpecifiyBlockPosition(blockPosX, blockPosY, blockPosZ);
			//Scaffold::AdditionalCalculations(currentX, currentY, currentZ, playerYaw);
		}
		else if (playerYaw <= 135 && playerYaw >= 90 || playerYaw <= 90 && playerYaw >= 45) {
			Scaffold::SpecifyBlockFace(4);
			Scaffold::SpecifiyBlockPosition(blockPosX, blockPosY, blockPosZ);
			//Scaffold::AdditionalCalculations(currentX, currentY, currentZ, playerYaw);
		}
		else if (playerYaw <= 0 && playerYaw >= -45 || playerYaw >= 0 && playerYaw <= 45) {
			Scaffold::SpecifyBlockFace(3);
			Scaffold::SpecifiyBlockPosition(blockPosX, blockPosY, blockPosZ);
			//Scaffold::AdditionalCalculations(currentX, currentY, currentZ, playerYaw);
		}
		else if (playerYaw >= -180 && playerYaw <= -135 || playerYaw >= 135 && playerYaw <= 180) {
			Scaffold::SpecifyBlockFace(2);
			Scaffold::SpecifiyBlockPosition(blockPosX, blockPosY, blockPosZ);
			//Scaffold::AdditionalCalculations(currentX, currentY, currentZ, playerYaw);
		}

	}
	else {
		mem::PatchEx((BYTE*)scaffoldSideAddr, (BYTE*)"\x0F\xB6\x85\x9C\x00\x00\x00", 7, hProcess);

		if (scaffoldRapidToggle) {
			byte val = 1;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
			scaffoldRapidToggle = false;
		}
	}
}

void Scaffold::SpecifyBlockFace(int blockSide) {
	switch (blockSide) {
	
	case 5:
		mem::PatchEx((BYTE*)scaffoldSideAddr, (BYTE*)"\xB0\x05\x90\x90\x90", 5, mem::hProcess);
		mem::NopEx((BYTE*)additionalAddr, 2, mem::hProcess);
	break;
	
	case 4:
		mem::PatchEx((BYTE*)scaffoldSideAddr, (BYTE*)"\xB0\x04\x90\x90\x90", 5, mem::hProcess);
		mem::NopEx((BYTE*)additionalAddr, 2, mem::hProcess);
	break;

	case 3:
		mem::PatchEx((BYTE*)scaffoldSideAddr, (BYTE*)"\xB0\x03\x90\x90\x90", 5, mem::hProcess);
		mem::NopEx((BYTE*)additionalAddr, 2, mem::hProcess);
	break;

	case 2:
		mem::PatchEx((BYTE*)scaffoldSideAddr, (BYTE*)"\xB0\x02\x90\x90\x90", 5, mem::hProcess);
		mem::NopEx((BYTE*)additionalAddr, 2, mem::hProcess);
	break;

	}
}

void Scaffold::SpecifiyBlockPosition(int X, int Y, int Z) {
	BYTE FLAG = 0;
	WriteProcessMemory(mem::hProcess, (BYTE*)pointers::blockCoordX(), &X, sizeof(int), 0);
	WriteProcessMemory(mem::hProcess, (BYTE*)pointers::blockCoordY(), &Y, sizeof(int), 0);
	WriteProcessMemory(mem::hProcess, (BYTE*)pointers::blockCoordZ(), &Z, sizeof(int), 0);
	WriteProcessMemory(mem::hProcess, (BYTE*)pointers::canPlaceBlock(), &FLAG, sizeof(BYTE), 0);
}

void Scaffold::AdditionalCalculations(float X, float Y, float Z, float playerYaw) {
	if (playerYaw >= -135 && playerYaw < -90 || playerYaw < -45 && playerYaw >= -90) {
		float LEFT = floor(Z - 1);
		float RIGHT = floor(Z + 1);
		if (roundf(Z - 0.65f) == LEFT) {
			Scaffold::SpecifyBlockFace(2);
			//Scaffold::SpecifiyBlockPosition(roundf(X + 0.4f), floor(Y - 1), floor(Z));
		}
		else if (roundf(Z + 0.15f) == RIGHT) {
			Scaffold::SpecifyBlockFace(3);
			//Scaffold::SpecifiyBlockPosition(roundf(X + 0.4f), floor(Y - 1), floor(Z));
		}
	}
	else if (playerYaw <= 135 && playerYaw >= 90 || playerYaw <= 90 && playerYaw >= 45) {
		float LEFT = floor(Z + 1);
		float RIGHT = floor(Z - 1);
		if (roundf(Z + 0.15f) == LEFT) {
			Scaffold::SpecifyBlockFace(3);
			//Scaffold::SpecifiyBlockPosition(roundf(X - 0.6f), floor(Y - 1), floor(Z));
		}
		else if (roundf(Z - 0.65f) == RIGHT) {
			Scaffold::SpecifyBlockFace(2);
			//Scaffold::SpecifiyBlockPosition(roundf(X - 0.6f), floor(Y - 1), floor(Z));
		}
	}
	else if (playerYaw <= 0 && playerYaw >= -45 || playerYaw >= 0 && playerYaw <= 45) {
		float LEFT = floor(X + 1);
		float RIGHT = floor(X - 1);
		if (roundf(X + 0.15f) == LEFT) {
			Scaffold::SpecifyBlockFace(5);
			//Scaffold::SpecifiyBlockPosition(floor(X), floor(Y - 1), roundf(Z + 0.4f));
		}
		else if (roundf(X - 0.65f) == RIGHT) {
			Scaffold::SpecifyBlockFace(4);
			//Scaffold::SpecifiyBlockPosition(floor(X), floor(Y - 1), roundf(Z + 0.4f));
		}
	}
	else if (playerYaw >= -180 && playerYaw <= -135 || playerYaw >= 135 && playerYaw <= 180) {
		float LEFT = floor(X - 1);
		float RIGHT = floor(X + 1);
		if (roundf(X - 0.65f) == LEFT) {
			Scaffold::SpecifyBlockFace(4);
			//Scaffold::SpecifiyBlockPosition(floor(X), floor(Y - 1), roundf(Z - 0.6f));
		}
		else if (roundf(X + 0.15f) == RIGHT) {
			Scaffold::SpecifyBlockFace(5);
			//Scaffold::SpecifiyBlockPosition(floor(X), floor(Y - 1), roundf(Z - 0.6f));
		}
	}
}