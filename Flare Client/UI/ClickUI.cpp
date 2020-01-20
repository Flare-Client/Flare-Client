#include "ClickUI.h"

int x = 0;
int y = 0;
ClickUI::ClickUI() {
}
void ClickUI::OnPaint(Gdiplus::Graphics* graphics,
	Gdiplus::SolidBrush* primary,
	Gdiplus::SolidBrush* secondary,
	Gdiplus::SolidBrush* ternary,
	float scale,
	Gdiplus::Rect desktop)
{
	Gdiplus::Rect clickUIRect = Gdiplus::Rect(desktop.X + x, desktop.Y + y, 480 * scale, 360 * scale);
	graphics->FillRectangle(primary, clickUIRect);
}