#include "keybindhandler.h"

char KeybindHandler::jetpackKey = 'F';
char KeybindHandler::hitboxKey = 'G';
char KeybindHandler::scaffoldKey = 'H';
char KeybindHandler::triggerbotKey = 'R';
char KeybindHandler::airjumpKey = '-';
char KeybindHandler::airaccKey = '-';
char KeybindHandler::noslowdownKey = '-';
char KeybindHandler::nowebKey = '-';
char KeybindHandler::noknockbackKey = '-';
char KeybindHandler::nofallKey = '-';
char KeybindHandler::gamemodeKey = '-';
char KeybindHandler::instabreakKey = '-';
char KeybindHandler::playerspeedKey = '-';
char KeybindHandler::phaseKey = '-';
char KeybindHandler::nowaterKey = '-';
char KeybindHandler::jesusKey = '-';
char KeybindHandler::bhopKey = '-';
char KeybindHandler::criticalsKey = '-';
char KeybindHandler::flightKey = '-';
char KeybindHandler::tpauraKey = 'L';

int KeybindHandler::keybindTick = 0;

void keystateCheck(char *key, bool *respectiveToggle, HWND hWnd) {
	if (GetAsyncKeyState(*key)) {
		KeybindHandler::keybindTick += 1;
		if (KeybindHandler::keybindTick >= 100) {
			if (!*respectiveToggle) {
				*respectiveToggle = true;
			}
			else if (*respectiveToggle) {
				*respectiveToggle = false;
			}
			KeybindHandler::keybindTick = 0;
			InvalidateRect(hWnd, 0, TRUE);
		}
	}
}

KeybindHandler::KeybindHandler(HWND host) {
	uintptr_t UIOpen = pointers::UI();
	int UI = 0;
	ReadProcessMemory(mem::hProcess, (BYTE*)UIOpen, &UI, sizeof(int), 0);
	if (UI) {
		keystateCheck(&KeybindHandler::hitboxKey, &ModuleHandler::hitboxToggle, host);
		keystateCheck(&KeybindHandler::triggerbotKey, &ModuleHandler::triggerbotToggle, host);
		keystateCheck(&KeybindHandler::airjumpKey, &ModuleHandler::airJumpToggle, host);
		keystateCheck(&KeybindHandler::airaccKey, &ModuleHandler::airaccspeedToggle, host);
		keystateCheck(&KeybindHandler::noslowdownKey, &ModuleHandler::noslowdownToggle, host);
		keystateCheck(&KeybindHandler::nowebKey, &ModuleHandler::nowebToggle, host);
		keystateCheck(&KeybindHandler::noknockbackKey, &ModuleHandler::noknockbackToggle, host);
		keystateCheck(&KeybindHandler::nofallKey, &ModuleHandler::nofallToggle, host);
		keystateCheck(&KeybindHandler::gamemodeKey, &ModuleHandler::gamemodeToggle, host);
		keystateCheck(&KeybindHandler::instabreakKey, &ModuleHandler::instabreakToggle, host);
		keystateCheck(&KeybindHandler::playerspeedKey, &ModuleHandler::playerspeedToggle, host);
		keystateCheck(&KeybindHandler::phaseKey, &ModuleHandler::phaseToggle, host);
		keystateCheck(&KeybindHandler::scaffoldKey, &ModuleHandler::scaffoldToggle, host);
		keystateCheck(&KeybindHandler::nowaterKey, &ModuleHandler::nowaterToggle, host);
		keystateCheck(&KeybindHandler::jesusKey, &ModuleHandler::jesusToggle, host);
		keystateCheck(&KeybindHandler::bhopKey, &ModuleHandler::bhopToggle, host);
		keystateCheck(&KeybindHandler::criticalsKey, &ModuleHandler::criticalsToggle, host);
		keystateCheck(&KeybindHandler::flightKey, &ModuleHandler::flightToggle, host);
		keystateCheck(&KeybindHandler::tpauraKey, &ModuleHandler::tpauraToggle, host);

		if (GetAsyncKeyState(KeybindHandler::jetpackKey)) {
			ModuleHandler::jetpackToggle = true;
		}
	}
}