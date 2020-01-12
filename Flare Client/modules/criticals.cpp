#include "criticals.h"

Criticals::Criticals(HANDLE hProcess, char option) {
	switch (option) {
	case 'P': //Patch
		mem::PatchEx((BYTE*)pointers::criticalsPacket(), (BYTE*)"\xB8\x00\x00\x00\x00\x90\x90", 7, hProcess);
	break;

	case 'F': //Fix
		mem::PatchEx((BYTE*)pointers::criticalsPacket(), (BYTE*)"\x0F\xB6\x86\x78\x01\x00\x00", 7, hProcess);
	break;
	}
}