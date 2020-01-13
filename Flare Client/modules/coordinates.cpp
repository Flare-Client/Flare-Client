#include "coordinates.h"

Coordinates::Coordinates(HANDLE hProcess, int toggle) {
	
	if (toggle) {
		mem::PatchEx((BYTE*)pointers::showCoords(), (BYTE*)gameBytes::COORDINATESONBYTES, 6, hProcess);
	}
	else {
		mem::PatchEx((BYTE*)pointers::showCoords(), (BYTE*)gameBytes::COORDINATEOFFBYTES, 6, hProcess);
	}
}