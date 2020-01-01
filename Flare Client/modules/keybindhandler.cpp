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

	if (UI && KeybindHandler::keybindTick > 10) {
		
		keystateCheck(&KeybindHandler::hitboxKey, &ModuleHandler::hitboxToggle);
		keystateCheck(&KeybindHandler::triggerbotKey, &ModuleHandler::triggerbotToggle);
		keystateCheck(&KeybindHandler::airjumpKey, &ModuleHandler::airJumpToggle);
		keystateCheck(&KeybindHandler::airaccKey, &ModuleHandler::airaccspeedToggle);
		keystateCheck(&KeybindHandler::noslowdownKey, &ModuleHandler::noslowdownToggle);
		keystateCheck(&KeybindHandler::nowebKey, &ModuleHandler::nowebToggle);
		keystateCheck(&KeybindHandler::noknockbackKey, &ModuleHandler::noknockbackToggle);
		keystateCheck(&KeybindHandler::nofallKey, &ModuleHandler::nofallToggle);
		keystateCheck(&KeybindHandler::gamemodeKey, &ModuleHandler::gamemodeToggle);
		keystateCheck(&KeybindHandler::instabreakKey, &ModuleHandler::instabreakToggle);
		keystateCheck(&KeybindHandler::playerspeedKey, &ModuleHandler::playerspeedToggle);
		keystateCheck(&KeybindHandler::phaseKey, &ModuleHandler::phaseToggle);
		keystateCheck(&KeybindHandler::scaffoldKey, &ModuleHandler::scaffoldToggle);
		keystateCheck(&KeybindHandler::nowaterKey, &ModuleHandler::nowaterToggle);
		keystateCheck(&KeybindHandler::jesusKey, &ModuleHandler::jesusToggle);
		keystateCheck(&KeybindHandler::bhopKey, &ModuleHandler::bhopToggle);
		keystateCheck(&KeybindHandler::criticalsKey, &ModuleHandler::criticalsToggle);
		keystateCheck(&KeybindHandler::flightKey, &ModuleHandler::flightToggle);
		keystateCheck(&KeybindHandler::tpauraKey, &ModuleHandler::tpauraToggle);

		KeybindHandler::keybindTick = 0;
	}
}