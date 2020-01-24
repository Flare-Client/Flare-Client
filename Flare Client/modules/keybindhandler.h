#pragma once
#include "ModuleHandler.h"
#include <gdiplus.h>

static struct Keybind {
	char key;
	const char** name;
	bool* toggle;
};

class KeybindHandler {
public:
	KeybindHandler(HWND hWnd);
	static void RegisterKeybind(uint64_t id, const char** name, char defaultKey, bool* toggle);
	static void OnPaint(Gdiplus::Graphics* graphics,
		Gdiplus::SolidBrush* primary,
		Gdiplus::SolidBrush* secondary,
		Gdiplus::SolidBrush* ternary,
		Gdiplus::Font* font,
		float scale,
		int dcstrl,
		Gdiplus::Rect desktop);
};

