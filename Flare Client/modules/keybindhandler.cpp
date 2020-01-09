#include "keybindhandler.h"

char KeybindHandler::jetpackKey = 'F';
char KeybindHandler::hitboxKey = 'G';
char KeybindHandler::scaffoldKey = 'H';
char KeybindHandler::triggerbotKey = 'R';
char KeybindHandler::tpauraKey = 'L';

int KeybindHandler::keybindTick = 0;

void keystateCheck(char *key, bool *respectiveToggle) {
	if (GetAsyncKeyState(*key)) {
		KeybindHandler::keybindTick += 1;
		if (KeybindHandler::keybindTick >= 6) {
			if (!*respectiveToggle) {
				*respectiveToggle = true;
			}
			else if (*respectiveToggle) {
				*respectiveToggle = false;
			}
			KeybindHandler::keybindTick = 0;
		}
	}
}

KeybindHandler::KeybindHandler() {
	uintptr_t UIOpen = pointers::UI();
	int UI = 0;
	ReadProcessMemory(mem::hProcess, (BYTE*)UIOpen, &UI, sizeof(int), 0);
	if (UI) {
		keystateCheck(&KeybindHandler::hitboxKey, &ModuleHandler::hitboxToggle);
		keystateCheck(&KeybindHandler::scaffoldKey, &ModuleHandler::scaffoldToggle);
		keystateCheck(&KeybindHandler::triggerbotKey, &ModuleHandler::triggerbotToggle);
		keystateCheck(&KeybindHandler::tpauraKey, &ModuleHandler::tpauraToggle);

		if (GetAsyncKeyState(KeybindHandler::jetpackKey)) {
			ModuleHandler::jetpackToggle = true;
		}
	}
}