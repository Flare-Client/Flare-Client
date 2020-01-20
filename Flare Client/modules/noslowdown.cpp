#include "noslowdown.h"

using namespace std;

NoSlowDown::NoSlowDown(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::noSlowDownOne(), 5, hProcess);
		mem::NopEx((BYTE*)pointers::noSlowDownTwo(), 5, hProcess);
		break;
	case 'F':
		mem::PatchEx((BYTE*)pointers::noSlowDownOne(), (BYTE*)gameBytes::NOSLOWDOWN1BYTES, 5, hProcess);
		mem::PatchEx((BYTE*)pointers::noSlowDownTwo(), (BYTE*)gameBytes::NOSLOWDOWN2BYTES, 5, hProcess);
		break;
	}
}