#include "triggerbot.h"

using namespace std;

TriggerBot::TriggerBot(HANDLE hProcess, char option) {
	uintptr_t entityFacingAddr = mem::FindAddr(hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 });
	switch (option) {
	case 'N':

		uintptr_t facingEnt;
		ReadProcessMemory(hProcess, (BYTE*)entityFacingAddr, &facingEnt, sizeof(facingEnt), 0);

		if (facingEnt) {
			byte val = 0;
			WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &val, sizeof(byte), 0);
		}
		else if (!facingEnt) {
			byte val = 1;
			WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &val, sizeof(byte), 0);
		}
		break;

	case 'F':
		byte val = 1;
		WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &val, sizeof(byte), 0);
		break;
	}
}