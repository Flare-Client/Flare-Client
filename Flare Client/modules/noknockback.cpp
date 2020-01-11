#include "noknockback.h"

NoKnockBack::NoKnockBack(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::knockBackX(), 6, hProcess);
		mem::NopEx((BYTE*)pointers::knockBackY(), 6, hProcess);
		mem::NopEx((BYTE*)pointers::knockBackZ(), 6, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::knockBackX(), (BYTE*)"\x89\x81\x6C\x04\x00\x00", 6, hProcess);
		mem::PatchEx((BYTE*)pointers::knockBackY(), (BYTE*)"\x89\x81\x70\x04\x00\x00", 6, hProcess);
		mem::PatchEx((BYTE*)pointers::knockBackZ(), (BYTE*)"\x89\x81\x74\x04\x00\x00", 6, hProcess);
	break;
	}
}