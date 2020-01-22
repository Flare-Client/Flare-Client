#pragma once
#include "TabGui.h"
class ClickUI
{
public:
	ClickUI();
	static void OnPaint(Gdiplus::Graphics* graphics,
		Gdiplus::SolidBrush *primary,
		Gdiplus::SolidBrush *secondary,
		Gdiplus::SolidBrush *ternary,
		float scale,
		Gdiplus::Rect desktop);
	static void HandleClick(bool left, int X, int Y, HWND host);
	static void HandleUnClick(HWND host);
};

