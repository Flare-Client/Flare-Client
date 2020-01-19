#include "TabGui.h"

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

TabGui::TabGui() {
	const wchar_t CLASS_NAME[] = L"Flare tab GUI";
	WNDCLASS wc = {};
	wc.lpfnWndProc = WindowProc;
	wc.hInstance = GetModuleHandle(NULL);
	wc.lpszClassName = CLASS_NAME;

	RegisterClass(&wc);

	HWND hwnd = CreateWindow(wc.lpszClassName, NULL, WS_POPUP, 0, 0, 420, 420, NULL, NULL, wc.hInstance, NULL);
	if (hwnd == NULL) {
		MessageBox(NULL, L"No HWND!", L"Failed to create window for Tab UI", MB_OK);
		return;
	}
	ShowWindow(hwnd, SW_SHOW);

	HWND windowHandleMC = find_main_window(mem::frameId);

	MSG msg = { };
	while (GetMessage(&msg, NULL, 0, 0))
	{
		RECT rectMC;
		RECT rectThis;
		GetWindowRect(windowHandleMC, &rectMC);
		GetWindowRect(hwnd, &rectThis);
		SetWindowPos(hwnd, HWND_TOPMOST, (rect.right - GetWindowSize().x) - 8, rect.top + 33 + gayUwpTitlesize, rect.right, rect.bottom, SWP_NOSIZE);

		if (GetForegroundWindow() == hwnd) {
			SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 1000, LWA_ALPHA);
		}
		else if (GetForegroundWindow() == windowHandleMC) {
			SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 100, LWA_ALPHA);
		}
		else {
			SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 0, LWA_ALPHA);
		}
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return;
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

			// All painting occurs here, between BeginPaint and EndPaint.

			FillRect(hdc, &ps.rcPaint, (HBRUSH)(COLOR_DESKTOP + 1));

			EndPaint(hwnd, &ps);
		}
	break;
	}
	return DefWindowProc(hwnd, uMsg, wParam, lParam);
}