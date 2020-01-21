#include "ClickUI.h"

int x = 0;
int y = 0;
int dx = 0;
int dy = 0;
bool dragging = false;
Gdiplus::Rect clickUIRect;
Gdiplus::Rect clickUIDragRect;
Gdiplus::Rect clickUIPanelRect;
ClickUI::ClickUI() {
}
void ClickUI::OnPaint(Gdiplus::Graphics* graphics,
	Gdiplus::SolidBrush* primary,
	Gdiplus::SolidBrush* secondary,
	Gdiplus::SolidBrush* ternary,
	float scale,
	Gdiplus::Rect desktop)
{
	clickUIDragRect = Gdiplus::Rect(desktop.X + x, desktop.Y + y, 480 * scale, 20);
	clickUIPanelRect = Gdiplus::Rect(desktop.X + x, desktop.Y + 20 + y, 480 * scale, (360 * scale) - 20);
	graphics->FillRectangle(secondary, clickUIPanelRect);
	graphics->FillRectangle(ternary, clickUIDragRect);
}

void ClickUI::HandleClick(bool left, int X, int Y, HWND host)
{
	if (!dragging) {
		if (clickUIDragRect.Contains(X, Y)) {
			dx = X - x;
			dy = Y - y;
			dragging = true;
		}
	}
	if (dragging) {
		x = X - dx;
		y = Y - dy;
		RECT ref = { clickUIPanelRect.X,clickUIPanelRect.Y + 20,clickUIPanelRect.Width,clickUIPanelRect.Height };
		InvalidateRect(host, &ref, false);
	}
}

void ClickUI::HandleUnClick(HWND host)
{
	if (dragging) {
		InvalidateRect(host, 0, false);
	}
	dragging = false;
}
