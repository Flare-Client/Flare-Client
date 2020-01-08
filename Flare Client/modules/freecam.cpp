#include "freecam.h"

FreeCam::FreeCam(HANDLE hProcess, char option) {
	switch (option) {
	
	case 'N':
		mem::NopEx((BYTE*)mem::moduleBase + 0xF9508B, 8, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)mem::moduleBase + 0xF9508B, (BYTE*)"\x41\x80\xB8\x31\x03\x00\x00\x00", 8, hProcess);
	break;

	}
}