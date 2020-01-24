#pragma once
#include "ModuleHandler.h"

static struct Keybind {
	char key;
	bool* toggle;
};

class KeybindHandler {
public:
	KeybindHandler(HWND hWnd);
	static void RegisterKeybind(uint64_t id, char defaultKey, bool* toggle);
};

