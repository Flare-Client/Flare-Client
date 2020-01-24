#include "keybindhandler.h"

std::vector<Keybind> keybinds;

static uint64_t keyBuf = 0;
KeybindHandler::KeybindHandler(HWND host) {
	uintptr_t UIOpen = pointers::UI();
	int UI = 0;
	ReadProcessMemory(mem::hProcess, (BYTE*)UIOpen, &UI, sizeof(int), 0);
	if (UI) {
		bool noKeys = true;
		for (uint64_t key2chek = 0; key2chek < keybinds.size(); key2chek++) {
			if (GetAsyncKeyState(keybinds[key2chek].key)) {
				noKeys = false;
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
			}
		}
		if (noKeys) {
			keyBuf = 0;
		}
	}
}

void RegisterKeybind(uint64_t id, char defaultKey, bool* toggle)
{
	keybinds.push_back({});
	keybinds[id] = { defaultKey, toggle };
}
