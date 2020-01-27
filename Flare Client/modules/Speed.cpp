#include "Speed.h"

bool speedToggle;
float originalSpeed;

Speed::Speed(HANDLE hProcess, float value, int toggle) {
	if (toggle) {
		if (!speedToggle) {
			ReadProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &originalSpeed, sizeof(float), 0);
			speedToggle = true;
		}
		WriteProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &value, sizeof(float), 0);
	}
	else {
		if (speedToggle) {
			WriteProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &originalSpeed, sizeof(float), 0);
			speedToggle = false;
		}
	}
}