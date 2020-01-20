#include "TabGui.h"

#pragma comment (lib,"Gdiplus.lib")

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

static struct handle_data {
	unsigned long process_id;
	HWND window_handle;
};
static BOOL is_main_window(HWND handle)
{
	return GetWindow(handle, GW_OWNER) == (HWND)0 && IsWindowVisible(handle);
}
static BOOL CALLBACK enum_windows_callback(HWND handle, LPARAM lParam)
{
	handle_data& data = *(handle_data*)lParam;
	unsigned long process_id = 0;
	GetWindowThreadProcessId(handle, &process_id);
	if (data.process_id != process_id || !is_main_window(handle))
		return TRUE;
	data.window_handle = handle;
	return FALSE;
}
static HWND find_main_window(unsigned long process_id)
{
	handle_data data;
	data.process_id = process_id;
	data.window_handle = 0;
	EnumWindows(enum_windows_callback, (LPARAM)&data);
	return data.window_handle;
}

RECT rectMC;
RECT desktop;
ULONG_PTR gdiplusToken;
Gdiplus::GdiplusStartupInput gdiplusStartupInput;
HWND hWnd;
POINT winPos;
SIZE winSize;
static std::vector<Category> categories;
int categoryCount = 0;
HWND topStyle = HWND_TOPMOST;
bool render = true;
static Lang activeLang = getEnglish();

void GetDesktopRect(RECT* rect)
{
	RECT desktop;
	// Get a handle to the desktop window
	const HWND hDesktop = GetDesktopWindow();
	// Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates
	// (horizontal, vertical)
	rect->left = 0;
	rect->top = 0;
	rect->right = desktop.right;
	rect->bottom = desktop.bottom;
}

void RegisterCategory(std::string categoryName, byte id)
{
	categories.push_back({});
	categories[id] = { categoryName, id == 0 };
	categoryCount++;
}
void RegisterModule(byte categoryID, int moduleID, std::string hackName, bool* moduleToggle) {
	categories[categoryID].modules.push_back({ "",false,0 });
	categories[categoryID].modules[moduleID] = { hackName, false, moduleToggle };
	categories[categoryID].moduleCount++;
}
int getActiveCategoryID() {
	int active = -1;
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].active) {
			active = b;
			break;
		}
	}
	return active;
}

void selectNextCategory() {
	byte selected = 0;
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].selected) {
			selected = b;
			break;
		}
	}
	categories[selected].selected = false;
	if (categories[selected + 1].name != "") {
		categories[selected + 1].selected = true;
		return;
	}
	categories[0].selected = true;
}
void selectPrevCategory() {
	byte selected = 0;
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].selected) {
			selected = b;
			break;
		}
	}
	categories[selected].selected = false;
	if (categories[selected - 1].name != "") {
		if (selected - 1 < 0) {
			selected = 32;
		}
		categories[selected - 1].selected = true;
		return;
	}
	categories[0].selected = true;
}
void selectNextModule() {
	int selected = 0;
	int active = getActiveCategoryID();
	for (int b = 0; b < categories[active].moduleCount; b++) {
		if (categories[active].modules[b].selected) {
			selected = b;
			break;
		}
	}
	categories[active].modules[selected].selected = false;
	if (categories[active].moduleCount <= selected + 1) {
		categories[active].modules[0].selected = true;
	}
	else {
		categories[active].modules[selected + 1].selected = true;
	}
}
void selectPrevModule() {
	int selected = 0;
	int active = getActiveCategoryID();
	for (int b = 0; b < categories[active].moduleCount; b++) {
		if (categories[active].modules[b].selected) {
			selected = b;
			break;
		}
	}
	categories[active].modules[selected].selected = false;
	if (0 > selected - 1) {
		categories[active].modules[categories[active].moduleCount-1].selected = true;
	}
	else {
		categories[active].modules[selected - 1].selected = true;
	}
}
void activateSelectedCategory() {
	byte selected = 0;
	int active = getActiveCategoryID();
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].selected) {
			selected = b;
			break;
		}
	}
	categories[selected].active = true;
	if (categories[selected].moduleCount == 0) {
		return;
	}
	for (int c = 0; c < categories[selected].moduleCount; c++) {
		categories[selected].modules[c].selected = false;
	}
	categories[selected].modules[0].selected = true;
}
void deactivateSelectedCategory() {
	byte selected = 0;
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].selected) {
			selected = b;
			break;
		}
	}
	categories[selected].active = false;
}
void toggleSelectedModule() {
	int selected = 0;
	int active = getActiveCategoryID();
	for (int b = 0; b < categories[active].moduleCount; b++) {
		if (categories[active].modules[b].selected) {
			selected = b;
			break;
		}
	}
	*categories[active].modules[selected].moduleToggle = !*categories[active].modules[selected].moduleToggle;
}

TabGui::TabGui() {
	const wchar_t CLASS_NAME[] = L"Flare tab GUI";
	WNDCLASS wc = {};
	wc.lpfnWndProc = WindowProc;
	wc.hInstance = GetModuleHandle(NULL);
	wc.lpszClassName = CLASS_NAME;

	RegisterClass(&wc);

	HWND windowHandleMC = find_main_window(mem::frameId);
	GetWindowRect(windowHandleMC, &rectMC);
	GetDesktopRect(&desktop);

	hWnd = CreateWindow(wc.lpszClassName, NULL, WS_POPUP, rectMC.left, rectMC.top, rectMC.right- rectMC.left-8, rectMC.bottom- rectMC.top-33, NULL, NULL, wc.hInstance, NULL);
	if (hWnd == NULL) {
		MessageBox(NULL, L"No HWND!", L"Failed to create window for Tab UI", MB_OK);
		return;
	}
	SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
	SetLayeredWindowAttributes(hWnd, RGB(77, 77, 77), 0, LWA_COLORKEY);
	ShowWindow(hWnd, SW_SHOW);

	Gdiplus::GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);

	//Register categories
	RegisterCategory(activeLang.Combat,0);
	RegisterCategory(activeLang.Movement,1);
	RegisterCategory(activeLang.Misc, 2);
	RegisterCategory(activeLang.Settings, 3);

	//Register Modules
	RegisterModule(0, 0, "Hitbox", &ModuleHandler::hitboxToggle);
	RegisterModule(0, 1, "Triggerbot", &ModuleHandler::triggerbotToggle);
	RegisterModule(1, 0, "Jetpack", &ModuleHandler::jetpackToggle);

	MSG msg = { };
	int keyBuf = 0;
	while (msg.message != WM_QUIT)
	{
		if (::PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
		{
			::TranslateMessage(&msg);
			::DispatchMessage(&msg);
			continue;
		}
		//std::cout << getActiveCategory();
		int gayUwpTitlesize = 0;
		WINDOWPLACEMENT wpsm;
		GetWindowPlacement(windowHandleMC, &wpsm);
		if (wpsm.showCmd == SW_MAXIMIZE) {
			gayUwpTitlesize = 7;
		}

		ModuleHandler::ModuleHandler(mem::hProcess, hWnd);



		GetWindowRect(windowHandleMC, &rectMC);
		winPos = POINT { rectMC.left + 8, rectMC.top + 33 + gayUwpTitlesize };
		winSize = SIZE { rectMC.left, rectMC.bottom };
		SetWindowPos(hWnd, topStyle, rectMC.left + 8, rectMC.top + 33 + gayUwpTitlesize, rectMC.right - rectMC.left - 8, rectMC.bottom - rectMC.top - 33, SWP_NOSIZE);

		//std::cout << getActiveCategoryID();

		if (GetAsyncKeyState(VK_DOWN)) {
			if (getActiveCategoryID() != -1) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectNextModule();
				InvalidateRect(hWnd, 0, TRUE);
			}
			else {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectNextCategory();
				InvalidateRect(hWnd, 0, TRUE);
			}
		}
		else if (GetAsyncKeyState(VK_UP)) {
			if (getActiveCategoryID() != -1) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectPrevModule();
				InvalidateRect(hWnd, 0, TRUE);
			}
			else {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectPrevCategory();
				InvalidateRect(hWnd, 0, TRUE);
			}
		}
		else if (GetAsyncKeyState(VK_RIGHT)) {
			if (getActiveCategoryID() != -1) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				toggleSelectedModule();
				InvalidateRect(hWnd, 0, TRUE);
			}
			else {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				activateSelectedCategory();
				InvalidateRect(hWnd, 0, TRUE);
			}
		}
		else if (GetAsyncKeyState(VK_LEFT)) {
			if (keyBuf > 0) {
				continue;
			}
			keyBuf++;
			deactivateSelectedCategory();
			InvalidateRect(hWnd, 0, TRUE);
		}
		else {
			keyBuf = 0;
		}

		if (GetForegroundWindow() == windowHandleMC) {
			topStyle = HWND_TOPMOST;
		}
		else {
			topStyle = HWND_NOTOPMOST;
		}
		//InvalidateRect(hWnd, 0, TRUE);
	}
	return;
}

VOID OnPaint(HDC hdc)
{
	Gdiplus::Graphics graphics(hdc);
	Gdiplus::SolidBrush bBrush(Gdiplus::Color(255, 77, 77, 77));
	graphics.FillRectangle(&bBrush, Gdiplus::Rect(desktop.left, desktop.top, desktop.right, desktop.bottom));

	Gdiplus::SolidBrush tBrush(Gdiplus::Color(255, 255, 100, 100));
	Gdiplus::FontFamily titleFontFamily(L"Arial");
	Gdiplus::Font titleFont(&titleFontFamily, 72, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF pointF(desktop.left, desktop.top);
	graphics.DrawString(L"Flare", -1, &titleFont, pointF, &tBrush);

	Gdiplus::SolidBrush vBrush(Gdiplus::Color(255, 255, 100, 100));
	Gdiplus::FontFamily verFontFamily(L"Arial");
	Gdiplus::Font verFont(&verFontFamily, 16, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF verPointF(desktop.left+160, desktop.top+8);
	graphics.DrawString(L"v0.0.6", -1, &verFont, verPointF, &vBrush);

	Gdiplus::SolidBrush cPen(Gdiplus::Color(200, 0, 0, 0));
	graphics.FillRectangle(&cPen, Gdiplus::Rect(desktop.left + 8, desktop.top + 72, 200, 400));

	Gdiplus::FontFamily categoryFontFamily(L"Arial");
	Gdiplus::Font categoryFont(&categoryFontFamily, 32, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);

	Gdiplus::SolidBrush sBrush(Gdiplus::Color(255, 0, 255, 255));
	Gdiplus::SolidBrush aBrush(Gdiplus::Color(255, 255, 0, 255));
	for (byte b = 0; b < categoryCount; b++) {
		if (categories[b].selected) {
			if (categories[b].active) {
				graphics.FillRectangle(&aBrush, Gdiplus::Rect(desktop.left + 8, (desktop.top + 75) + (32 * b), 200, 32));
				int z = 0;
				for (int c = 0; c < categories[b].moduleCount; c++) {
					graphics.FillRectangle(&cPen, Gdiplus::Rect(desktop.left + 208, (desktop.top + 75) + (32 * b) + (32 * z), 200, 32));
					if (*categories[b].modules[c].moduleToggle) {
						graphics.FillRectangle(&aBrush, Gdiplus::Rect(desktop.left + 208, (desktop.top + 75) + (32 * b) + (32 * z), 200, 32));
					}else if (categories[b].modules[c].selected) {
						graphics.FillRectangle(&sBrush, Gdiplus::Rect(desktop.left + 208, (desktop.top + 75) + (32 * b) + (32 * z), 200, 32));
					}
					Gdiplus::PointF pointL(desktop.left + 208, (desktop.top + 75) + (32 * b) + (32 * z));
					std::wstring wstr = std::wstring(categories[b].modules[c].name.begin(), categories[b].modules[c].name.end());
					graphics.DrawString(wstr.c_str(), wstr.length(), &categoryFont, pointL, &tBrush);
					z++;
				}
			}
			else {
				graphics.FillRectangle(&sBrush, Gdiplus::Rect(desktop.left + 8, (desktop.top + 75) + (32 * b), 200, 32));
			}
		}
		Gdiplus::PointF pointL(desktop.left + 8, (desktop.top + 73) + (32 * b));
		std::wstring wstr = std::wstring(categories[b].name.begin(), categories[b].name.end());
		graphics.DrawString(wstr.c_str(), wstr.length(), &categoryFont, pointL, &tBrush);
	}

	/*BLENDFUNCTION bf;
	bf.BlendOp = AC_SRC_OVER;
	bf.SourceConstantAlpha = 255;
	bf.AlphaFormat = AC_SRC_ALPHA;
	UpdateLayeredWindow(hWnd, hdc, &winPos, &winSize, hdc, &winPos, RGB(77,77,77), &bf, ULW_ALPHA);*/
}

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hwnd, &ps);
		if (render) {
			OnPaint(hdc);
		}
		EndPaint(hwnd, &ps);
	}
	break;
	}
	return DefWindowProc(hwnd, uMsg, wParam, lParam);
}