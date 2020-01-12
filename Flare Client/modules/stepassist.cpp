#include "stepassist.h"

bool stepAssistToggle;

StepAssist::StepAssist(HANDLE hProcess, uintptr_t localPlayer, int toggle) {
	float newFloatVal = 2;
	float val = 0.5625;
	switch (toggle) {
	case 1:
		WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::stepAssist }), &newFloatVal, sizeof(float), 0);
		stepAssistToggle = true;
	break;

	case 0:
		if (stepAssistToggle) {
			WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::stepAssist }), &val, sizeof(float), 0);
			stepAssistToggle = false;
		}
	break;
	}
}