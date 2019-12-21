#include "noknockback.h"

NoKnockBack::NoKnockBack(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)mem::moduleBase + 0x1210362, 6, hProcess);
		mem::NopEx((BYTE*)mem::moduleBase + 0x121036B, 6, hProcess);
		mem::NopEx((BYTE*)mem::moduleBase + 0x1210374, 6, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)mem::moduleBase + 0x1210362, (BYTE*)"\x89\x81\x6C\x04\x00\x00", 6, hProcess);
		mem::PatchEx((BYTE*)mem::moduleBase + 0x121036B, (BYTE*)"\x89\x81\x70\x04\x00\x00", 6, hProcess);
		mem::PatchEx((BYTE*)mem::moduleBase + 0x1210374, (BYTE*)"\x89\x81\x74\x04\x00\x00", 6, hProcess);
	break;
	}
}