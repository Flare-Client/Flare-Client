#include "noslowdown.h"

using namespace std;

NoSlowDown::NoSlowDown(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)mem::moduleBase + 0x1A5B9F9, 5, hProcess);
		mem::NopEx((BYTE*)mem::moduleBase + 0xF72506, 5, hProcess);
		break;
	case 'F':
		mem::PatchEx((BYTE*)mem::moduleBase + 0x1A5B9F9, (BYTE*)"\xF3\x0F\x11\x46\x0C", 5, hProcess);
		mem::PatchEx((BYTE*)mem::moduleBase + 0xF72506, (BYTE*)"\xF3\x0F\x11\x46\x0C", 5, hProcess);
		break;
	}
}