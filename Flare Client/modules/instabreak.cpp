#include "instabreak.h"

bool Instabreak::oneTimePatch = true;

Instabreak::Instabreak(HANDLE hProcess, byte value) {

	//Made by DisabledMallis

	if (Instabreak::oneTimePatch) {
		mem::PatchEx((BYTE*)mem::moduleBase + 0x149BA35, (BYTE*)"\xE9\x14\xC9\xA0\x00", 5, hProcess);
		mem::PatchEx((BYTE*)mem::moduleBase + 0x1EA834E, (BYTE*)"\x83\x3D\xF1\xFF\xFF\xFF\x00\x75\x0A\xF3\x0F\x11\x4F\x20\xE9\xD9\x36\x5F\xFF\xF3\x0F\x10\x0D\x02\x00\x00\x00\xEB\xEC\x00\x00\x80\x3F", 33, hProcess);
		Instabreak::oneTimePatch = false;
	}
	if (!Instabreak::oneTimePatch) {
		WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x1EA8346, &value, sizeof(value), 0);
	}
}