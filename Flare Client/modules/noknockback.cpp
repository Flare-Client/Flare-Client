#include "noknockback.h"

NoKnockBack::NoKnockBack(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::knockBackX(), 6, hProcess);
		mem::NopEx((BYTE*)pointers::knockBackY(), 6, hProcess);
		mem::NopEx((BYTE*)pointers::knockBackZ(), 6, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::knockBackX(), (BYTE*)gameBytes::NOKNOCKBACKXBYTES, 6, hProcess);
		mem::PatchEx((BYTE*)pointers::knockBackY(), (BYTE*)gameBytes::NOKNOCKBACKYBYTES, 6, hProcess);
		mem::PatchEx((BYTE*)pointers::knockBackZ(), (BYTE*)gameBytes::NOKNOCKBACKZBYTES, 6, hProcess);
	break;
	}
}