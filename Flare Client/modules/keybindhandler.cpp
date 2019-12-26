#include "keybindhandler.h"

char KeybindHandler::jetpackKey = 'F';
char KeybindHandler::hitboxKey = 'G';
char KeybindHandler::scaffoldKey = 'G';

int KeybindHandler::keybindTick = 0;

KeybindHandler::KeybindHandler(int UI) {
	KeybindHandler::keybindTick += 1;

	if (UI && GetAsyncKeyState(KeybindHandler::jetpackKey)) {
		if (!ModuleHandler::jetpackToggle) {
			ModuleHandler::jetpackToggle = true;
		}
	}

	if (UI && KeybindHandler::keybindTick > 40) {
		
		if (GetAsyncKeyState(KeybindHandler::hitboxKey)) {
			if (!ModuleHandler::hitboxToggle) {
				ModuleHandler::hitboxToggle = true;
			}
			else if (ModuleHandler::hitboxToggle) {
				ModuleHandler::hitboxToggle = false;
			}
		}

		if (GetAsyncKeyState(KeybindHandler::scaffoldKey)) {
			if (!ModuleHandler::scaffoldToggle) {
				ModuleHandler::scaffoldToggle = true;
			}
			else if (ModuleHandler::scaffoldToggle) {
				ModuleHandler::scaffoldToggle = false;
			}
		}

		KeybindHandler::keybindTick = 0;
	}
}