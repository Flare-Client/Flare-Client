#include "keybindhandler.h"

char KeybindHandler::jetpackKey = 'F';
char KeybindHandler::hitboxKey = 'G';
char KeybindHandler::scaffoldKey = 'H';
char KeybindHandler::triggerbotKey = 'R';

int KeybindHandler::keybindTick = 0;

void keystateCheck(char *key, bool *respectiveToggle) {
	if (GetAsyncKeyState(*key)) {
		if (!*respectiveToggle) {
			*respectiveToggle = true;
		}
		else if (*respectiveToggle) {
			*respectiveToggle = false;
		}
	}
}

KeybindHandler::KeybindHandler(int UI) {
	KeybindHandler::keybindTick += 1;

	if (UI && GetAsyncKeyState(KeybindHandler::jetpackKey)) {
		if (!ModuleHandler::jetpackToggle) {
			ModuleHandler::jetpackToggle = true;
		}
	}

	if (UI && KeybindHandler::keybindTick > 40) {
		
		keystateCheck(&KeybindHandler::hitboxKey, &ModuleHandler::hitboxToggle);
		keystateCheck(&KeybindHandler::scaffoldKey, &ModuleHandler::scaffoldToggle);
		keystateCheck(&KeybindHandler::triggerbotKey, &ModuleHandler::triggerbotToggle);

		KeybindHandler::keybindTick = 0;
	}
}