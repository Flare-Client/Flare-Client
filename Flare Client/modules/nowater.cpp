#include "nowater.h"

NoWater::NoWater(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::inWaterTick(), 7, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::inWaterTick(), (BYTE*)gameBytes::INWATERBYTES, 7, hProcess);
	break;
	}
}