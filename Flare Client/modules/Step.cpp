#include "Step.h"

bool stepToggle;

Step::Step(HANDLE hProcess, uintptr_t localPlayer, int toggle) {
	float newFloatVal = 2;
	float val = 0.5625;
	switch (toggle) {
	case 1:
		WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::stepAssist }), &newFloatVal, sizeof(float), 0);
		stepToggle = true;
	break;

	case 0:
		if (stepToggle) {
			WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::stepAssist }), &val, sizeof(float), 0);
			stepToggle = false;
		}
	break;
	}
}