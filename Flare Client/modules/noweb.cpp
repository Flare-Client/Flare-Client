#include "noweb.h"

using namespace std;

NoWeb::NoWeb(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::webTick(), 8, hProcess);
	break;
	
	case 'F':
		mem::PatchEx((BYTE*)pointers::webTick(), (BYTE*)gameBytes::WEBTICKBYTES, 8, hProcess);
	break;
	}
}