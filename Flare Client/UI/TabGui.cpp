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
static std::vector<Setting> settings;
int settingCount = 0;
HWND topStyle = HWND_TOPMOST;
bool render = true;
Lang activeLang = getEnglish();
float scale = 1.0f;
int pLangID = 0;
int langID = 0;

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

void RegisterCategory(const char** categoryName, byte id)
{
	categories.push_back({});
	categories[id] = { categoryName, id == 0 };
	categoryCount++;
}
void RegisterModule(byte categoryID, int moduleID, const char** hackName, bool* moduleToggle) {
	categories[categoryID].modules.push_back({});
	categories[categoryID].modules[moduleID] = { hackName, false, moduleToggle };
	categories[categoryID].moduleCount++;
}
void RegisterSetting(int settingID, const char** settingName, SettingType type, uint64_t* value) {
	settings.push_back({});
	settings[settingID] = { value, type, settingName, false };
	settingCount++;
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
	if (*categories[selected + 1].name != "") {
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
	if (*categories[selected - 1].name != "") {
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
	if (categories[active].moduleCount == 0) { return; }
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
	if (categories[active].moduleCount == 0) { return; }
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
	if (categories[active].moduleCount == 0) { return; }
	for (int b = 0; b < categories[active].moduleCount; b++) {
		if (categories[active].modules[b].selected) {
			selected = b;
			break;
		}
	}
	*categories[active].modules[selected].moduleToggle = !*categories[active].modules[selected].moduleToggle;
}
void selectNextSetting() {
	int selected = 0;
	for (int b = 0; b < settingCount; b++) {
		if (settings[b].selected) {
			selected = b;
			break;
		}
	}
	settings[selected].selected = false;
	if (settingCount <= selected + 1) {
		settings[0].selected = true;
	}
	else {
		settings[selected+1].selected = true;
	}
}
void selectPrevSetting() {
	int selected = 0;
	for (int b = 0; b < settingCount; b++) {
		if (settings[b].selected) {
			selected = b;
			break;
		}
	}
	settings[selected].selected = false;
	if (0 > selected - 1) {
		settings[settingCount-1].selected = true;
	}
	else {
		settings[selected - 1].selected = true;
	}
}
void increaseSetting() {
	int selected = 0;
	for (int b = 0; b < settingCount; b++) {
		if (settings[b].selected) {
			selected = b;
			break;
		}
	}
	bool* valB;
	byte* valBB;
	int* valI;
	float* valF;
	switch (settings[selected].type) {
	case 0:
		valB = reinterpret_cast<bool*>(settings[selected].valuePtr);
		*valB = true;
		std::cout << "BOOL: " << *valB;
		break;
	case 1:
		valBB = reinterpret_cast<byte*>(settings[selected].valuePtr);
		*valBB++;
		std::cout << "BYTE: " << *valBB;
		break;
	case 2:
		valI = reinterpret_cast<int*>(settings[selected].valuePtr);
		*valI += 1;
		std::cout << "INT: " << *valI;
		break;
	case 3:
		valF = reinterpret_cast<float*>(settings[selected].valuePtr);
		*valF+=0.1f;
		std::cout << "FLOAT: " << *valF;
		break;
	}
}
void decreaseSetting() {
	int selected = 0;
	for (int b = 0; b < settingCount; b++) {
		if (settings[b].selected) {
			selected = b;
			break;
		}
	}
	bool* valB;
	byte* valBB;
	int* valI;
	float* valF;
	switch (settings[selected].type) {
	case 0:
		valB = reinterpret_cast<bool*>(settings[selected].valuePtr);
		*valB = false;
		break;
	case 1:
		valBB = reinterpret_cast<byte*>(settings[selected].valuePtr);
		*valBB--;
		break;
	case 2:
		valI = reinterpret_cast<int*>(settings[selected].valuePtr);
		*valI -= 1;
		std::cout << "INT: " << *valI;
		break;
	case 3:
		valF = reinterpret_cast<float*>(settings[selected].valuePtr);
		*valF-=0.1f;
		break;
	}
}

TabGui::TabGui() {
	const wchar_t CLASS_NAME[] = L"Flare tab GUI";
	WNDCLASS wc = {};
	wc.lpfnWndProc = WindowProc;
	wc.hInstance = GetModuleHandle(NULL);
	wc.lpszClassName = CLASS_NAME;

	RegisterClass(&wc);

	//Register categories
	RegisterCategory(&activeLang.Combat, 0);
	RegisterCategory(&activeLang.Movement, 1);
	RegisterCategory(&activeLang.Misc, 2);
	RegisterCategory(&activeLang.Settings, 3);
	RegisterCategory(&activeLang.ClickUI, 4);

	//Register Modules
	/* Combat */
	RegisterModule(0, 0, &activeLang.Hitbox, &ModuleHandler::hitboxToggle);
	RegisterModule(0, 1, &activeLang.Triggerbot, &ModuleHandler::triggerbotToggle);
	RegisterModule(0, 2, &activeLang.Criticals, &ModuleHandler::criticalsToggle);
	RegisterModule(0, 3, &activeLang.TpAura, &ModuleHandler::tpauraToggle);
	/* Movement */
	RegisterModule(1, 0, &activeLang.Jetpack, &ModuleHandler::jetpackToggle);
	RegisterModule(1, 1, &activeLang.AirJump, &ModuleHandler::airJumpToggle);
	RegisterModule(1, 2, &activeLang.NoSlowDown, &ModuleHandler::noslowdownToggle);
	RegisterModule(1, 3, &activeLang.NoKnockBack, &ModuleHandler::noknockbackToggle);
	RegisterModule(1, 4, &activeLang.PlayerSpeed, &ModuleHandler::playerspeedToggle);
	RegisterModule(1, 5, &activeLang.NoWater, &ModuleHandler::nowaterToggle);
	RegisterModule(1, 6, &activeLang.Jesus, &ModuleHandler::jesusToggle);
	RegisterModule(1, 7, &activeLang.Bhop, &ModuleHandler::bhopToggle);
	RegisterModule(1, 8, &activeLang.Flight, &ModuleHandler::flightToggle);
	RegisterModule(1, 9, &activeLang.NoClip, &ModuleHandler::noClipToggle);
	RegisterModule(1, 10, &activeLang.StepAssist, &ModuleHandler::stepAssistToggle);
	RegisterModule(1, 11, &activeLang.AutoSprint, &ModuleHandler::autoSprintToggle);

	/* Other */
	RegisterModule(2, 0, &activeLang.NoWeb, &ModuleHandler::nowebToggle);
	RegisterModule(2, 1, &activeLang.VanillaNoFall, &ModuleHandler::nofallToggle);
	RegisterModule(2, 2, &activeLang.Gamemode, &ModuleHandler::gamemodeToggle);
	RegisterModule(2, 3, &activeLang.Instabreak, &ModuleHandler::instabreakToggle);
	RegisterModule(2, 4, &activeLang.Phase, &ModuleHandler::phaseToggle);
	RegisterModule(2, 5, &activeLang.Scaffold, &ModuleHandler::scaffoldToggle);
	RegisterModule(2, 6, &activeLang.NoPacket, &ModuleHandler::nopacketToggle);
	RegisterModule(2, 7, &activeLang.Freecam, &ModuleHandler::freecamToggle);
	RegisterModule(2, 8, &activeLang.ServerCrasher, &ModuleHandler::servercrasherToggle);
	RegisterModule(2, 9, &activeLang.Coordinates, &ModuleHandler::coordinatesToggle);
	RegisterModule(2, 10, &activeLang.clickTP, &ModuleHandler::clicktpToggle);

	/* Settings */
	//There is a special case for the first setting, it wont modify the value, it will just close the settings list always.
	RegisterSetting(0, &activeLang.Back, Bool, reinterpret_cast<uint64_t*>(&categories[3].active));
	RegisterSetting(1, &activeLang.GuiScale, Float, reinterpret_cast<uint64_t*>(&scale));
	RegisterSetting(2, &activeLang.Language, Int, reinterpret_cast<uint64_t*>(&langID));

	settings[0].selected = true;

	HWND windowHandleMC = find_main_window(mem::frameId);
	GetWindowRect(windowHandleMC, &rectMC);
	GetDesktopRect(&desktop);

	hWnd = CreateWindow(wc.lpszClassName, NULL, WS_POPUP, rectMC.left, rectMC.top, rectMC.right- rectMC.left-8, rectMC.bottom- rectMC.top-33, NULL, NULL, wc.hInstance, NULL);
	if (hWnd == NULL) {
		MessageBox(NULL, L"No HWND!", L"Failed to create window for Tab UI", MB_OK);
		return;
	}
	SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT);
	SetLayeredWindowAttributes(hWnd, RGB(77, 77, 77), 0, LWA_COLORKEY);
	ShowWindow(hWnd, SW_SHOW);

	Gdiplus::GdiplusStartup(&gdiplusToken, &gdiplusStartupInput, NULL);

	ClickUI::ClickUI();

	MSG msg = { };
	int keyBuf = 0;
	bool trig = false;
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
		SetWindowPos(hWnd, topStyle, rectMC.left + 8, rectMC.top + 33 + gayUwpTitlesize, rectMC.right - rectMC.left - 8, rectMC.bottom - rectMC.top - 33, NULL);

		if (GetAsyncKeyState(1)) {
			POINT p;
			GetCursorPos(&p);

			ClickUI::HandleClick(true, p.x - (rectMC.left + 8), p.y - (rectMC.top + 33 + gayUwpTitlesize), hWnd);
		}
		else {
			ClickUI::HandleUnClick(hWnd);
		}

		//std::cout << "Lang ID: " << langID << std::endl;
		switch (langID) {
		case 0:
			activeLang = getEnglish();
			break;
		case 1:
			activeLang = getItalian();
			break;
		case 2:
			activeLang = getSpanish();
			break;
		}
		if (pLangID != langID) {
			InvalidateRect(hWnd, 0, TRUE);
			pLangID = langID;
		}
		//std::cout << "Lang: " << activeLang.Language << std::endl;

		if (GetAsyncKeyState(VK_DOWN)) {
			if (getActiveCategoryID() == 3) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectNextSetting();
				InvalidateRect(hWnd, 0, TRUE);
			}
			else if (getActiveCategoryID() != -1) {
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
			if (getActiveCategoryID() == 3) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				selectPrevSetting();
				InvalidateRect(hWnd, 0, TRUE);
			}
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
			if (getActiveCategoryID() == 3) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				if (settings[0].selected) {
					categories[3].active = false;
					continue;
				}
				increaseSetting();
				InvalidateRect(hWnd, 0, TRUE);
				continue;
			}
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
			if (getActiveCategoryID() == 3) {
				if (keyBuf > 0) {
					continue;
				}
				keyBuf++;
				if (settings[0].selected) {
					categories[3].active = false;
					continue;
				}
				decreaseSetting();
				InvalidateRect(hWnd, 0, TRUE);
				continue;
			}
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
			trig = true;
			topStyle = HWND_TOPMOST;
		}
		else {
			if (trig) {
				topStyle = HWND_BOTTOM;
			}
			else {
				topStyle = HWND_NOTOPMOST;
			}
			trig = false;
		}
		//InvalidateRect(hWnd, 0, TRUE);
	}
	return;
}

std::wstring char2String(const char* in) {
	std::string str(in);
	std::wstring wstr(str.begin(), str.end());
	return wstr;
}
int drawnStringLen(std::wstring str, Gdiplus::Graphics* g, Gdiplus::Font* font) {
	Gdiplus::PointF ptf;
	Gdiplus::RectF rtf;
	g->MeasureString(str.c_str(), str.length(), font, ptf, &rtf);
	return rtf.Width;
}
int largestCatNameLen(Gdiplus::Graphics* g, Gdiplus::Font* font) {
	int dcstrl = 0;
	for (byte b = 0; b < categoryCount; b++) {
		std::wstring cwstr = char2String(*categories[b].name);
		int ndcstrl = drawnStringLen(cwstr, g, font);
		if (ndcstrl > dcstrl) {
			dcstrl = ndcstrl;
		}
	}
	return dcstrl;
}
int largestModNameLen(int catID, Gdiplus::Graphics* g, Gdiplus::Font* font) {
	int dcstrl = 0;
	for (byte b = 0; b < categories[catID].moduleCount; b++) {
		std::wstring cwstr = char2String(*categories[catID].modules[b].name);
		int ndcstrl = drawnStringLen(cwstr, g, font);
		if (ndcstrl > dcstrl) {
			dcstrl = ndcstrl;
		}
	}
	return dcstrl;
}

VOID OnPaint(HDC hdc)
{
	//Main box, basically the screen ig. idk how to describe it but it makes it transparent
	Gdiplus::Graphics graphics(hdc);
	Gdiplus::SolidBrush bBrush(Gdiplus::Color(255, 77, 77, 77));
	Gdiplus::Rect desktopRect = Gdiplus::Rect(desktop.left, desktop.top, desktop.right, desktop.bottom);
	graphics.FillRectangle(&bBrush, desktopRect);

	//Draw the Flare branding
	Gdiplus::SolidBrush tBrush(Gdiplus::Color(255, 255, 100, 100));
	Gdiplus::FontFamily titleFontFamily(L"Arial");
	Gdiplus::Font titleFont(&titleFontFamily, 72*scale, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF pointF(desktop.left, desktop.top);
	graphics.DrawString(L"Flare", -1, &titleFont, pointF, &tBrush);

	//Version too
	Gdiplus::SolidBrush vBrush(Gdiplus::Color(255, 255, 100, 100));
	Gdiplus::FontFamily verFontFamily(L"Arial");
	Gdiplus::Font verFont(&verFontFamily, 16 * scale, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);
	Gdiplus::PointF verPointF(desktop.left+ (160 * scale), desktop.top+8);
	graphics.DrawString(L"v0.0.6", -1, &verFont, verPointF, &vBrush);

	//Clear pen. basically what the box for categories and modules are.
	Gdiplus::SolidBrush cPen(Gdiplus::Color(200, 0, 0, 0));

	//Font for categories and shit
	Gdiplus::FontFamily categoryFontFamily(L"Arial");
	Gdiplus::Font categoryFont(&categoryFontFamily, 32 * scale, Gdiplus::FontStyleRegular, Gdiplus::UnitPixel);

	//Overlap brush. when a module is both selected and active
	Gdiplus::SolidBrush oBrush(Gdiplus::Color(255, 255, 255, 0));
	//Selected brush. when a module is selected
	Gdiplus::SolidBrush sBrush(Gdiplus::Color(255, 0, 255, 255));
	//Active brush. When the module or category is active
	Gdiplus::SolidBrush aBrush(Gdiplus::Color(255, 255, 0, 255));
	//for every category
	int dcstrl = largestCatNameLen(&graphics, &categoryFont);
	for (byte b = 0; b < categoryCount; b++) {
		//Draw a rect for each category
		Gdiplus::PointF pointL(desktop.left + 8, (desktop.top + (73 * scale)) + ((32 * scale) * b));
		std::wstring cwstr = char2String(*categories[b].name);
		graphics.FillRectangle(&cPen, Gdiplus::Rect(desktop.left + 8, desktop.top + (75 * scale) + ((32 * scale) * b), dcstrl * scale, 32 * scale));
		if (categories[b].selected) {
			if (categories[b].active) {
				//Draw a diff color rect for active categories
				graphics.FillRectangle(&aBrush, Gdiplus::Rect(desktop.left + 8, (desktop.top + (75 * scale)) + ((32 * scale) * b), dcstrl * scale, 32 * scale));
				int z = 0;
				int dstrl = largestModNameLen(b, &graphics, &categoryFont);
				for (int c = 0; c < categories[b].moduleCount; c++) {
					//Draw rects for modules
					//Form module name
					Gdiplus::PointF pointL(desktop.left + dcstrl+8, (desktop.top + (75 * scale)) + ((32 * scale) * b) + ((32 * scale) * z));
					std::wstring wstr = char2String(*categories[b].modules[c].name);
					graphics.FillRectangle(&cPen, Gdiplus::Rect(desktop.left + dcstrl+8, (desktop.top + (75 * scale)) + ((32 * scale) * b) + ((32 * scale) * z), dstrl * scale, 32 * scale));
					if (*categories[b].modules[c].moduleToggle && categories[b].modules[c].selected) {
						graphics.FillRectangle(&oBrush, Gdiplus::Rect(desktop.left + dcstrl+8, (desktop.top + (75 * scale)) + ((32 * scale) * b) + ((32 * scale) * z), dstrl * scale, 32 * scale));
					}
					else if (*categories[b].modules[c].moduleToggle) {
						graphics.FillRectangle(&aBrush, Gdiplus::Rect(desktop.left + dcstrl+8, (desktop.top + (75 * scale)) + ((32 * scale) * b) + ((32 * scale) * z), dstrl * scale, 32 * scale));
					} else if (categories[b].modules[c].selected) {
						graphics.FillRectangle(&sBrush, Gdiplus::Rect(desktop.left + dcstrl+8, (desktop.top + (75 * scale)) + ((32 * scale) * b) + ((32 * scale) * z), dstrl * scale, 32 * scale));
					}
					//Draw module name
					graphics.DrawString(wstr.c_str(), wstr.length(), &categoryFont, pointL, &tBrush);
					z++;
				}
			}
			else {
				//Only if we're just selected
				graphics.FillRectangle(&sBrush, Gdiplus::Rect(desktop.left + 8, (desktop.top + (75 * scale)) + ((32 * scale) * b), dcstrl * scale, 32 * scale));
			}
		}
		graphics.DrawString(cwstr.c_str(), cwstr.length(), &categoryFont, pointL, &tBrush);
	}
	if (categories[3].active) {
		//graphics.FillRectangle(&aBrush, Gdiplus::Rect(desktop.left + 8, (desktop.top + (75 * scale)) + (32 * scale), 200 * scale, 32 * scale));
		for (int c = 0; c < settingCount; c++) {
			//Draw rects for settings
			graphics.FillRectangle(&cPen, Gdiplus::Rect((desktop.left + dcstrl+8) * scale, (desktop.top + (75 * scale)) + ((32 * scale) * c), 200 * scale, 32 * scale));
			if (settings[c].selected) {
				graphics.FillRectangle(&sBrush, Gdiplus::Rect((desktop.left + dcstrl+8)*scale, (desktop.top + (75 * scale)) + ((32 * scale) * c), 200 * scale, 32 * scale));
			}
			//Draw setting name
			Gdiplus::PointF pointL((desktop.left + dcstrl+8) * scale, (desktop.top + (75 * scale)) + ((32 * scale) * c));
			std::wstring wstr = char2String(*settings[c].name);
			graphics.DrawString(wstr.c_str(), wstr.length(), &categoryFont, pointL, &tBrush);
		}
	}
	if (categories[4].active) {
		ClickUI::OnPaint(&graphics, &tBrush, &cPen, &sBrush, scale, desktopRect);
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