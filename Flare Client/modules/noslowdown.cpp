#include "noslowdown.h"

using namespace std;

NoSlowDown::NoSlowDown(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::noSlowDownOne(), 5, hProcess);
		mem::NopEx((BYTE*)pointers::noSlowDownTwo(), 5, hProcess);
		break;
	case 'F':
		mem::PatchEx((BYTE*)pointers::noSlowDownOne(), (BYTE*)"\xF3\x0F\x11\x46\x0C", 5, hProcess);
		mem::PatchEx((BYTE*)pointers::noSlowDownTwo(), (BYTE*)"\xF3\x0F\x11\x46\x0C", 5, hProcess);
		break;
	}
}