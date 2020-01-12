#include "scaffold.h"

bool rapidBuildToggle;

Scaffold::Scaffold(HANDLE hProcess, int toggle) {
	if (toggle) {
		mem::NopEx((BYTE*)pointers::blockFace(), 7, hProcess);

		uintptr_t facingEnt;
		ReadProcessMemory(hProcess, (BYTE*)pointers::entityFacing(), &facingEnt, sizeof(uintptr_t), 0);

		if (GetAsyncKeyState(VK_LBUTTON)) {
			if (!facingEnt) {
				BYTE TOGGLE = 0;
				WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &TOGGLE, sizeof(BYTE), 0);
				rapidBuildToggle = true;
			}
			else if (facingEnt) {
				if (rapidBuildToggle) {
					BYTE TOGGLE = 1;
					WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &TOGGLE, sizeof(BYTE), 0);
					rapidBuildToggle = false;
				}
			}
		}

	}
	else {
		mem::PatchEx((BYTE*)pointers::blockFace(), (BYTE*)"\x41\x88\x86\x54\x08\x00\x00", 7, hProcess);

		if (rapidBuildToggle) {
			BYTE TOGGLE = 1;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &TOGGLE, sizeof(BYTE), 0);
			rapidBuildToggle = false;
		}
	}
}