#include "scaffold.h"

Scaffold::Scaffold(HANDLE hProcess, char option) {
	uintptr_t entityFacingAddr = mem::FindAddr(hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 });
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)mem::moduleBase + 0x5D2412, 7, hProcess);

		if (GetAsyncKeyState(VK_LBUTTON)) {
			uintptr_t facingEnt;
			ReadProcessMemory(hProcess, (BYTE*)entityFacingAddr, &facingEnt, sizeof(facingEnt), 0);

			if (!facingEnt) {
				byte val = 0;
				WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &val, sizeof(byte), 0);
			}
		}
	break;

	case 'F':
		mem::PatchEx((BYTE*)mem::moduleBase + 0x5D2412, (BYTE*)"\x41\x88\x86\x54\x08\x00\x00", 7, hProcess);
	break;
	}
}