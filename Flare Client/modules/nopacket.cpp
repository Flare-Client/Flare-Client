#include "nopacket.h"

NoPacket::NoPacket(HANDLE hProcess, char option) {
	switch (option) {
	case 'N':
		mem::NopEx((BYTE*)pointers::noPacket(), 7, hProcess);
	break;

	case 'F':
		mem::PatchEx((BYTE*)pointers::noPacket(), (BYTE*)gameBytes::NOPACKETBYTES, 7, hProcess);
	break;
	}
}