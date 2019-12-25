#include "criticals.h"

Criticals::Criticals(HANDLE hProcess, char option) {
	uintptr_t critsAddr = mem::moduleBase + 0xFD1E56;
	switch (option) {
	case 'P': //Patch
		mem::PatchEx((BYTE*)critsAddr, (BYTE*)"\xB8\x00\x00\x00\x00\x90\x90", 7, hProcess);
	break;

	case 'F': //Fix
		mem::PatchEx((BYTE*)critsAddr, (BYTE*)"\x0F\xB6\x86\x78\x01\x00\x00", 7, hProcess);
	break;
	}
}