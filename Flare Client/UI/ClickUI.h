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
};

