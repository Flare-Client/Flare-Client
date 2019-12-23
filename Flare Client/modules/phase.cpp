#include "phase.h"

bool Phase::oneTimeWrite = false;

Phase::Phase(HANDLE hProcess, uintptr_t localPlayer, char option) {
	float Y1, Y2;

	uintptr_t yCoordinateAddr1 = mem::FindAddr(hProcess, localPlayer, { 0x434 });
	uintptr_t yCoordinateAddr2 = mem::FindAddr(hProcess, localPlayer, { 0x440 });

	ReadProcessMemory(hProcess, (BYTE*)yCoordinateAddr1, &Y1, sizeof(Y1), 0);
	ReadProcessMemory(hProcess, (BYTE*)yCoordinateAddr1, &Y2, sizeof(Y2), 0);

	switch (option) {
	case 'E': //Edit
		if (!Phase::oneTimeWrite) {
			WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr2, &Y1, sizeof(Y1), 0);
			Phase::oneTimeWrite = true;
		}
	break;

	case 'F': //Fix
		if (Phase::oneTimeWrite) {
			Y2 = Y1 + 1.8;
			WriteProcessMemory(hProcess, (BYTE*)yCoordinateAddr2, &Y2, sizeof(Y1), 0);
			Phase::oneTimeWrite = false;
		}
	break;
	}
}