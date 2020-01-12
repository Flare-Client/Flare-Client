#include "freecam.h"

bool freecamToggle;
float originX, originY, originZ;

FreeCam::FreeCam(HANDLE hProcess, char option) {
	switch (option) {
	
	case 'N':
		mem::NopEx((BYTE*)pointers::movementPacket(), 8, hProcess);

		if (!freecamToggle) {
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentX1 }), &originX, sizeof(float), 0);
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentY1 }), &originY, sizeof(float), 0);
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentZ1 }), &originZ, sizeof(float), 0);
			freecamToggle = true;
		}

	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::movementPacket(), (BYTE*)"\x41\x80\xB8\x31\x03\x00\x00\x00", 8, hProcess);

		if (freecamToggle) {
			Teleport::Teleport(hProcess, originX, originY, originZ);
			freecamToggle = false;
		}
	break;

	}
}