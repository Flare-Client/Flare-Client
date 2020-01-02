#include "triggerbot.h"

using namespace std;

TriggerBot::TriggerBot(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':

		uintptr_t facingEnt;
		ReadProcessMemory(hProcess, (BYTE*)pointers::entityFacing(), &facingEnt, sizeof(facingEnt), 0);

		if (facingEnt) {
			byte val = 0;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
		}
		else if (!facingEnt) {
			byte val = 1;
			WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
		}
		break;

	case 'F':
		byte val = 1;
		WriteProcessMemory(hProcess, (BYTE*)pointers::attackSwing(), &val, sizeof(byte), 0);
		break;
	}
}