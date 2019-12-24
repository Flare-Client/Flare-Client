#include "nowater.h"

NoWater::NoWater(HANDLE hProcess, char option) {
	uintptr_t waterTickAddr = mem::moduleBase + 0x121883D;
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)waterTickAddr, 7, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)waterTickAddr, (BYTE*)"\xC6\x83\x3D\x02\x00\x00\x01", 7, hProcess);
	break;
	}
}