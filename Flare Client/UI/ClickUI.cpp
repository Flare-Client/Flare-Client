#include "ClickUI.h"

int x = 0;
int y = 0;
int dx = 0;
int dy = 0;
bool dragging = false;
Gdiplus::Rect clickUIRect;
Gdiplus::Rect clickUIDragRect;
Gdiplus::Rect clickUIPanelRect;
std::vector<Setting> settings;
uint32_t currentLine = 0;


interface Settings {
public:
	virtual void OnPaint();
};

class FSliderSetting : public Setting {
	float value;
	float min;
	float max;
public:
	void OnPaint() {

	}
};

void RegisterText(Gdiplus::Graphics* graphics, float scale, std::wstring text, Gdiplus::SolidBrush* brush) {
	Gdiplus::FontFamily textFontFamily(L"Arial");
	Gdiplus::Font textFont(&textFontFamily, 24 * scale, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF textPos(clickUIPanelRect.X + 208, (clickUIPanelRect.Y + (75 * scale)) + (24 * scale) + ((32 * scale) * currentLine));
	graphics->DrawString(text.c_str(), text.length(), &textFont, textPos, brush);
}

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
		RECT ref = { x,y,x+ clickUIPanelRect.Width,y+ clickUIPanelRect.Height+20 };
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
