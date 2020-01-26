#include "keybindhandler.h"

std::vector<Keybind> keybinds;

void KeybindHandler::selectNextKeybind() {
	int selected = 0;
	for (Keybind kb : keybinds) {
		if (kb.selected) {
			break;
		}
		selected++;
	}
	keybinds[selected].selected = false;
	if (keybinds.size() <= selected + 1) {
		keybinds[0].selected = true;
	}
	else {
		keybinds[selected+1].selected = true;
	}
}
void KeybindHandler::selectPrevKeybind() {
	int selected = 0;
	for (Keybind kb : keybinds) {
		if (kb.selected) {
			break;
		}
		selected++;
	}
	keybinds[selected].selected = false;
	if (selected <= 0) {
		keybinds[keybinds.size()-1].selected = true;
	}
	else {
		keybinds[selected - 1].selected = true;
	}
}
void KeybindHandler::changeKeybind() {
	int selected = 0;
	for (Keybind kb : keybinds) {
		if (kb.selected) {
			break;
		}
		selected++;
	}
	keybinds[selected].changing = true;
}

uint64_t keyBuff = 0;
KeybindHandler::KeybindHandler(HWND host) {
	uintptr_t UIOpen = pointers::UI();
	int UI = 1;
	ReadProcessMemory(mem::hProcess, (BYTE*)UIOpen, &UI, sizeof(int), 0);
	if (1) {
		bool noKeys = true;
		for (uint64_t key2chek = 0; key2chek < keybinds.size(); key2chek++) {
			if (keybinds[key2chek].changing) {
				for (char c = -128; c < 127; c++) {
					if (c == VK_RIGHT) {
						continue;
					}
					if (GetAsyncKeyState(c)) {
						keybinds[key2chek].changing = false;
						keybinds[key2chek].key = c;
					}
				}
				continue;
			}
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

void KeybindHandler::RegisterKeybind(uint64_t id, const char** name, char defaultKey, bool* toggle)
{
	keybinds.push_back({});
	keybinds[id] = { defaultKey, name, toggle, false, false };
}

std::wstring char2String(const char* in) {
	std::string str(in);
	std::wstring wstr(str.begin(), str.end());
	return wstr;
}
int largestKeybindLen(Gdiplus::Graphics* g, Gdiplus::Font* font) {
	int top = 0;
	for (uint64_t key2chek = 0; key2chek < keybinds.size(); key2chek++) {
		std::wstring wstr = char2String(*keybinds[key2chek].name);
		Gdiplus::PointF ptf;
		Gdiplus::RectF rtf;
		g->MeasureString(wstr.c_str(), wstr.length(), font, ptf, &rtf);
		if (rtf.Width > top) {
			top = rtf.Width;
		}
	}
	return top;
}

void KeybindHandler::OnPaint(Gdiplus::Graphics* graphics,
	Gdiplus::SolidBrush* primary,
	Gdiplus::SolidBrush* secondary,
	Gdiplus::SolidBrush* ternary,
	Gdiplus::Font* font,
	float scale,
	int dcstrl,
	Gdiplus::Rect desktop) {
	int len = largestKeybindLen(graphics, font);
	int yBase = desktop.GetTop() + (75 * scale);
	for (uint64_t key2chek = 0; key2chek < keybinds.size(); key2chek++) {
		int x = (desktop.GetLeft() + dcstrl + 8) * scale;
		int y = yBase + ((32 * scale) * key2chek);
		graphics->FillRectangle(primary, x, y, len + 30, 32);
		if (keybinds[key2chek].selected) {
			graphics->FillRectangle(ternary, x, y, len + 30, 32);
		}
		graphics->DrawString(char2String(*keybinds[key2chek].name).c_str(), -1, font, Gdiplus::PointF(x, y), secondary);
		if (keybinds[key2chek].changing) {
			graphics->DrawString(char2String("...").c_str(), -1, font, Gdiplus::PointF(x + len, y), secondary);
		}
		else {
			graphics->DrawString(char2String(&keybinds[key2chek].key).c_str(), -1, font, Gdiplus::PointF(x + len, y), secondary);
		}
	}
}