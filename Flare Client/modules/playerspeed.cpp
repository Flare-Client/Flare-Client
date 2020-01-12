#include "playerspeed.h"

bool playerSpeedToggle;
float originalSpeed;

PlayerSpeed::PlayerSpeed(HANDLE hProcess, float value, int toggle) {
	if (toggle) {
		if (!playerSpeedToggle) {
			ReadProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &originalSpeed, sizeof(float), 0);
			playerSpeedToggle = true;
		}
		WriteProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &value, sizeof(float), 0);
	}
	else {
		if (playerSpeedToggle) {
			WriteProcessMemory(hProcess, (BYTE*)pointers::playerSpeed(), &originalSpeed, sizeof(float), 0);
			playerSpeedToggle = false;
		}
	}
}