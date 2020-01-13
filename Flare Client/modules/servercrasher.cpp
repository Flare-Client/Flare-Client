#include "servercrasher.h"

ServerCrasher::ServerCrasher(HANDLE hProcess, char option) {
	switch (option) {
	
	case 'N':
		mem::NopEx((BYTE*)pointers::serverCrashPacket(), 7, hProcess);
	break;
	
	case 'F':
		mem::PatchEx((BYTE*)pointers::serverCrashPacket(), (BYTE*)gameBytes::SERVERCRASHERBYTES, 7, hProcess);
	break;
	}
}