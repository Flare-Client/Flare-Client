#include "coordinates.h"

Coordinates::Coordinates(HANDLE hProcess, int toggle) {
	
	if (toggle) {
		mem::PatchEx((BYTE*)pointers::showCoords(), (BYTE*)"\x90\x90\x90\x90\x74\x07", 6, hProcess);
	}
	else {
		mem::PatchEx((BYTE*)pointers::showCoords(), (BYTE*)"\x80\x78\x04\x00\x74\x07", 6, hProcess);
	
	}
}