#include "TabGui.h"

#include <objidl.h>
#include <gdiplus.h>
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

	hWnd = CreateWindow(wc.lpszClassName, NULL, WS_POPUP, 0, desktop.top, desktop.right, desktop.bottom, NULL, NULL, wc.hInstance, NULL);
	if (hWnd == NULL) {
		MessageBox(NULL, L"No HWND!", L"Failed to create window for Tab UI", MB_OK);
		return;
	}
	ShowWindow(hWnd, SW_SHOW);

	Gdiplus::GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);

	MSG msg = { };
	while (msg.message != WM_QUIT)
	{
		if (::PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
		{
			::TranslateMessage(&msg);
			::DispatchMessage(&msg);
			continue;
		}
		int gayUwpTitlesize = 0;
		WINDOWPLACEMENT wpsm;
		GetWindowPlacement(windowHandleMC, &wpsm);
		if (wpsm.showCmd == SW_MAXIMIZE) {
			gayUwpTitlesize = 7;
		}

		GetWindowRect(windowHandleMC, &rectMC);
		winPos = POINT { rectMC.left + 8, rectMC.top + 33 + gayUwpTitlesize };
		winSize = SIZE { rectMC.left, rectMC.bottom };
		SetWindowPos(hWnd, HWND_TOPMOST, rectMC.left + 8, rectMC.top + 33 + gayUwpTitlesize, rectMC.right, rectMC.bottom, SWP_NOSIZE);

		if (GetForegroundWindow() == hWnd) {
			SetLayeredWindowAttributes(hWnd, RGB(0, 0, 0), 1000, LWA_ALPHA);
		}
		else if (GetForegroundWindow() == windowHandleMC) {
			SetLayeredWindowAttributes(hWnd, RGB(0, 0, 0), 100, LWA_ALPHA);
		}
		else {
			SetLayeredWindowAttributes(hWnd, RGB(0, 0, 0), 0, LWA_ALPHA);
		}
		InvalidateRect(hWnd, 0, TRUE);
	}
	return;
}


VOID OnPaint(HDC hdc)
{
	Gdiplus::Graphics graphics(hdc);
	Gdiplus::SolidBrush bBrush(Gdiplus::Color(255, 0, 0, 0));
	graphics.FillRectangle(&bBrush, Gdiplus::Rect(desktop.left, desktop.top, rectMC.right-rectMC.left, rectMC.bottom- rectMC.top));

	Gdiplus::SolidBrush tBrush(Gdiplus::Color(255, 255, 255, 255));
	Gdiplus::FontFamily fontFamily(L"Arial");
	Gdiplus::Font font(&fontFamily, 72, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF pointF(desktop.left, desktop.top);
	graphics.DrawString(L"Flare", -1, &font, pointF, &tBrush);
	BLENDFUNCTION bf = { AC_SRC_OVER, 0, 200, AC_SRC_ALPHA };
	//UpdateLayeredWindow(hWnd, hdc, &winPos, &winSize, hdc, &winPos, RGB(0,0,0), NULL, NULL);
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
		OnPaint(hdc);
		EndPaint(hwnd, &ps);
	}
	break;
	}
	return DefWindowProc(hwnd, uMsg, wParam, lParam);
}