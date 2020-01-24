#include "keybindhandler.h"

std::vector<Keybind> keybinds;

uint64_t keyBuff = 0;
KeybindHandler::KeybindHandler(HWND host) {
	uintptr_t UIOpen = pointers::UI();
	int UI = 1;
	ReadProcessMemory(mem::hProcess, (BYTE*)UIOpen, &UI, sizeof(int), 0);
	if (1) {
		bool noKeys = true;
		for (uint64_t key2chek = 0; key2chek < keybinds.size(); key2chek++) {
			if (GetAsyncKeyState(keybinds[key2chek].key)) {
				noKeys = false;
				if (keyBuff > 0) {
					continue;
				}
				keyBuff++;
				*keybinds[key2chek].toggle = !*keybinds[key2chek].toggle;
				InvalidateRect(host, 0, TRUE);
			}
		}
		if (noKeys) {
			keyBuff = 0;
		}
	}
}

void KeybindHandler::RegisterKeybind(uint64_t id, char defaultKey, bool* toggle)
{
	keybinds.push_back({});
	keybinds[id] = { defaultKey, toggle };
}
