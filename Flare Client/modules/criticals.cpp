#include "criticals.h"

Criticals::Criticals(HANDLE hProcess, char option) {
	switch (option) {
	case 'P': //Patch
		mem::PatchEx((BYTE*)pointers::criticalsPacket(), (BYTE*)gameBytes::CRITICALSPATCHBYTES, 7, hProcess);
	break;

	case 'F': //Fix
		mem::PatchEx((BYTE*)pointers::criticalsPacket(), (BYTE*)gameBytes::CRITICALSFIXBYTES, 7, hProcess);
	break;
	}
}