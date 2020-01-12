#include "noclip.h"

bool noclipToggle;

NoClip::NoClip(HANDLE hProcess, int toggle) {
	if (toggle) {
		mem::NopEx((BYTE*)pointers::groundCollision(), 5, hProcess);
		Flight::Flight(hProcess, Player::LocalPlayer(), 1);
		noclipToggle = true;
	}
	else {
		mem::PatchEx((BYTE*)pointers::groundCollision(), (BYTE*)"\xF3\x41\x0F\x5C\x19", 5, hProcess);
		if (noclipToggle) {
			Flight::Flight(hProcess, Player::LocalPlayer(), 0);
			noclipToggle = false;
		}
	}
}