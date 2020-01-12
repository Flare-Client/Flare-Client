#include "nowater.h"

NoWater::NoWater(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::inWaterTick(), 7, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::inWaterTick(), (BYTE*)"\xC6\x83\x3D\x02\x00\x00\x01", 7, hProcess);
	break;
	}
}