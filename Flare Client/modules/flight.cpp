#include "flight.h"

bool oneTimeWrite = false;

Flight::Flight(HANDLE hProcess, uintptr_t localPlayer, int toggle) {
	uintptr_t flightAddr = mem::FindAddr(hProcess, localPlayer, { 0xA88 });
	switch (toggle) {
	case 0:
		if (oneTimeWrite) {
			WriteProcessMemory(hProcess, (BYTE*)flightAddr, &toggle, sizeof(toggle), 0);
			oneTimeWrite = false; //Disable flight only once in case people are in GMC
		}
		break;

	case 1:
		WriteProcessMemory(hProcess, (BYTE*)flightAddr, &toggle, sizeof(toggle), 0);
		oneTimeWrite = true;
		break;
	}
}