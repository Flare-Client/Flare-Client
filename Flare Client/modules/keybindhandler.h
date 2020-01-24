#pragma once
#include "ModuleHandler.h"

struct Keybind {
	char key;
	bool* toggle;
};

void RegisterKeybind(uint64_t id, char defaultKey, bool* toggle);

class KeybindHandler {
public:
	KeybindHandler(HWND hWnd);
};

