//IMGUI Includes
#include "GuiLoader.h"
#include "Lang.h"
#include "Imgui/imgui.h"
#include "Imgui/imgui_impl_dx9.h"
#include "Imgui/imgui_impl_win32.h"
#include <d3d9.h>
#include <tchar.h>
#define DIRECTINPUAT_VERSION 0x0900
#pragma comment(lib,"d3d9.lib")

#include "modules/ModuleHandler.h"
#include <fstream>
#include <iostream>
bool loadedTheme = false;
bool loadedDrpDetails = false;

using namespace std;

bool GuiLoader::windowToggle = true;

struct handle_data {
	unsigned long process_id;
	HWND window_handle;
};
BOOL is_main_window(HWND handle)
{
	return GetWindow(handle, GW_OWNER) == (HWND)0 && IsWindowVisible(handle);
}
BOOL CALLBACK enum_windows_callback(HWND handle, LPARAM lParam)
{
	handle_data& data = *(handle_data*)lParam;
	unsigned long process_id = 0;
	GetWindowThreadProcessId(handle, &process_id);
	if (data.process_id != process_id || !is_main_window(handle))
		return TRUE;
	data.window_handle = handle;
	return FALSE;
}
HWND find_main_window(unsigned long process_id)
{
	handle_data data;
	data.process_id = process_id;
	data.window_handle = 0;
	EnumWindows(enum_windows_callback, (LPARAM)&data);
	return data.window_handle;
}

static LPDIRECT3D9              g_pD3D = NULL;
static LPDIRECT3DDEVICE9        g_pd3dDevice = NULL;
static D3DPRESENT_PARAMETERS    g_d3dpp = {};

bool CreateDeviceD3D(HWND hWnd);
void CleanupDeviceD3D();
void ResetDevice();
LRESULT WINAPI WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

HWND hwnd;

Lang activeLang;

void WindowAlwaysOnTop(HWND hwnd) {
	if (hwnd) {
		if (GuiLoader::windowToggle) {
			SetWindowPos(
				hwnd,
				HWND_TOPMOST,
				0, 0, 0, 0,
				SWP_DRAWFRAME | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW
			);
			ShowWindow(
				hwnd,
				SW_NORMAL
			);
		}
		else if (!GuiLoader::windowToggle) {
			SetWindowPos(
				hwnd,
				HWND_TOPMOST,
				0, 0, 0, 0,
				SWP_DRAWFRAME | SWP_NOMOVE | SWP_NOSIZE | SWP_HIDEWINDOW
			);
			ShowWindow(
				hwnd,
				SW_HIDE
			);
		}
	}
}

char* keyText = new char[1];
void createReassign(const char* hackName, char *hackKey) {
	ImGui::Text(hackName);
	ImGui::SameLine();
	if (*hackKey) {
		keyText[0] = *hackKey;
		if (ImGui::Button(&keyText[0])) *hackKey = NULL;
	}
	else if (!*hackKey) {
		ImGui::Button("Waiting for key input");
		for (int I = '1'; I < 'Z'; I++) {
			if (GetAsyncKeyState(I)) *hackKey = I;
		}
	}
}

GuiLoader::GuiLoader() {
	{
		WNDCLASSEX wc = { sizeof(WNDCLASSEX), CS_CLASSDC, WndProc, 0L, 0L, GetModuleHandle(NULL), NULL, NULL, NULL, NULL, _T("Flare Client"), NULL };
		::RegisterClassEx(&wc);
		HWND hwnd = ::CreateWindow(wc.lpszClassName, NULL, WS_POPUP, 0, 0, 420, 420, NULL, NULL, wc.hInstance, NULL);

		SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED);
		SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 1000, LWA_ALPHA);

		if (!CreateDeviceD3D(hwnd))
		{
			CleanupDeviceD3D();
			::UnregisterClass(wc.lpszClassName, wc.hInstance);

		}

		activeLang = getItalian();

		::ShowWindow(hwnd, SW_SHOW);
		::UpdateWindow(hwnd);

		IMGUI_CHECKVERSION();
		ImGui::CreateContext();
		ImGuiIO& io = ImGui::GetIO(); (void)io;

		ImGui::StyleColorsDark();

		ImGui_ImplWin32_Init(hwnd);
		ImGui_ImplDX9_Init(g_pd3dDevice);

		HWND windowHandleMC = find_main_window(mem::frameId);

		bool show_menu = true;
		bool show_another_window = false;
		ImVec4 clear_color = ImVec4(0.0f, 0.0f, 0.0f, 0.00f);


		MSG msg;
		ZeroMemory(&msg, sizeof(msg));
		while (msg.message != WM_QUIT)
		{
			if (::PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE))
			{
				::TranslateMessage(&msg);
				::DispatchMessage(&msg);
				continue;
			}
			ImGui_ImplDX9_NewFrame();
			ImGui_ImplWin32_NewFrame();
			ImGui::NewFrame();			

			ImGui::Begin("Flare Client v0.0.3 -D", 0, ImGuiWindowFlags_NoResize | ImGuiWindowFlags_NoMove | ImGuiWindowFlags_NoCollapse);
			ImGui::SetWindowSize(ImVec2(420, 420));
			ImGui::SetWindowPos(ImVec2(0, 0));

			static int switchTabs = 3;
			static int currentTheme = 0;
			static int currentLang = 0;

			ifstream inFile;
			if (!loadedTheme) {
				inFile.open("Theme.txt");
				if (inFile.is_open()) {
					inFile >> currentTheme;
					inFile.close();
				}
				loadedTheme = true;
				cout << "Loaded Theme" << endl;
			}

			if (!loadedDrpDetails) {
				inFile.open("Discord.txt");
				if (inFile.is_open()) {
					inFile >> ModuleHandler::drpDisplayName;
					inFile.close();
				}
				loadedDrpDetails = true;
				cout << "Loaded Discord Rich Presence Details" << endl;
			}

			switch (currentTheme) {
			case 0:
				ImGui::StyleColorsDark();
				break;
			case 1:
				ImGui::StyleColorsLight();
				break;
			case 2:
				ImGui::StyleColorsClassic();
				break;
			case 3:
				ImGui::StyleColorsGray();
				break;
			}

			switch (currentLang) {
			case 0:
				activeLang = getEnglish();
				break;
			case 1:
				activeLang = getItalian();
				break;
			}

			if (ImGui::Button(activeLang.Combat, ImVec2(100.0f, 0.0f)))
				switchTabs = 0;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button(activeLang.Movement, ImVec2(100.0f, 0.0f)))
				switchTabs = 1;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button(activeLang.Misc, ImVec2(100.0f, 0.0f)))
				switchTabs = 2;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button(activeLang.Settings, ImVec2(100.0f, 0.0f)))
				switchTabs = 3;

			int gayUwpTitlesize = 0;
			WINDOWPLACEMENT wpsm;
			GetWindowPlacement(windowHandleMC, &wpsm);
			if (wpsm.showCmd == SW_MAXIMIZE) {
				gayUwpTitlesize = 7;
			}

			RECT rect;
			GetWindowRect(windowHandleMC, &rect);
			SetWindowPos(hwnd, HWND_TOPMOST, (rect.right - ImGui::GetWindowSize().x) - 8, rect.top + 33 + gayUwpTitlesize, rect.right, rect.bottom, SWP_NOSIZE);

			if (GetForegroundWindow() == hwnd) {
				SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 1000, LWA_ALPHA);
			}
			else if (GetForegroundWindow() == windowHandleMC) {
				SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 100, LWA_ALPHA);
			}
			else {
				SetLayeredWindowAttributes(hwnd, RGB(0, 0, 0), 0, LWA_ALPHA);
			}

			const char* gamemodeItems[] = { "Survival", "Creative", "Adventure" };
			const char* themeItems[] = { "Dark Theme", "Light Theme", "Classic Theme", "Grey Theme" };
			const char* drpDisplayItems[] = { "Display username", "Display in game" };
			const char* langItems[] = { getEnglish().Name, getItalian().Name, getSpanish().Name };
			switch (switchTabs) {
			case 0:
				ImGui::Checkbox(activeLang.Hitbox, &ModuleHandler::hitboxToggle);
				ImGui::Checkbox(activeLang.Triggerbot, &ModuleHandler::triggerbotToggle);
				ImGui::Checkbox(activeLang.Criticals, &ModuleHandler::criticalsToggle);
				ImGui::Checkbox(activeLang.TpAura, &ModuleHandler::tpauraToggle);
				break;
			case 1:
				ImGui::Checkbox(activeLang.AirJump, &ModuleHandler::airJumpToggle);
				ImGui::Checkbox(activeLang.AirAcceleration, &ModuleHandler::airaccspeedToggle);
				ImGui::Checkbox(activeLang.NoSlowDown, &ModuleHandler::noslowdownToggle);
				ImGui::Checkbox(activeLang.NoKnockBack, &ModuleHandler::noknockbackToggle);
				ImGui::Checkbox(activeLang.PlayerSpeed, &ModuleHandler::playerspeedToggle);
				ImGui::Checkbox(activeLang.NoWater, &ModuleHandler::nowaterToggle);
				ImGui::Checkbox(activeLang.Jesus, &ModuleHandler::jesusToggle);
				ImGui::Checkbox(activeLang.Bhop, &ModuleHandler::bhopToggle);
				ImGui::Checkbox(activeLang.Flight, &ModuleHandler::flightToggle);
				break;
			case 2:
				ImGui::Checkbox(activeLang.NoWeb, &ModuleHandler::nowebToggle);
				ImGui::Checkbox(activeLang.VanillaNoFall, &ModuleHandler::nofallToggle);
				ImGui::Checkbox(activeLang.Gamemode, &ModuleHandler::gamemodeToggle);
				ImGui::Checkbox(activeLang.Instabreak, &ModuleHandler::instabreakToggle);
				ImGui::Checkbox(activeLang.Phase, &ModuleHandler::phaseToggle);
				ImGui::Checkbox(activeLang.Scaffold, &ModuleHandler::scaffoldToggle);
				break;
			case 3:
				ImGui::SliderFloat("Hitbox: Width", &ModuleHandler::hitboxWidthFloat, 0.6, 12.f);
				ImGui::SliderFloat("Hitbox: Height", &ModuleHandler::hitboxHeightFloat, 0.6, 12.f);
				ImGui::SliderFloat("Air Acceleration", &ModuleHandler::airAccelerationSpeed, 0.05, 0.5);
				ImGui::SliderFloat("Player Speed", &ModuleHandler::playerSpeedVal, 0.1, 4.f);
				ImGui::SliderFloat("Jesus (Y Boost)", &ModuleHandler::jesusVal, 0.1, 5.f);
				ImGui::SliderFloat("BHOP (Y Boost)", &ModuleHandler::bhopVal, 0.1, 5.f);
				ImGui::Combo("Gamemode", &ModuleHandler::gamemodeVal, gamemodeItems, IM_ARRAYSIZE(gamemodeItems));
				ImGui::Text("Teleport:");
				ImGui::InputFloat("X", &ModuleHandler::teleportX);
				ImGui::InputFloat("Y", &ModuleHandler::teleportY);
				ImGui::InputFloat("Z", &ModuleHandler::teleportZ);
				if (ImGui::Button("Teleport")) {
					Teleport::Teleport(mem::hProcess, ModuleHandler::teleportX, ModuleHandler::teleportY, ModuleHandler::teleportZ);
				}
				ImGui::SliderFloat("TP Aura: Range", &ModuleHandler::tpauraRange, 0.0, 48.0f);
				ImGui::SliderInt("TP Aura: TP Skips", &ModuleHandler::tpauraSkips, 0, 1000);
				ImGui::Text("Theme:");
				ImGui::Combo("Theme", &currentTheme, themeItems, IM_ARRAYSIZE(themeItems));
				ImGui::SameLine();
				if (ImGui::Button("Save Theme")) {
					ofstream themeFile;
					themeFile.open("Theme.txt");
					if (themeFile.is_open()) {
						themeFile << currentTheme << endl;
						themeFile.close();
						cout << "Saved Theme" << endl;
					}
				}
				ImGui::Text("Discord Rich Presence:");
				ImGui::Combo("DRP", &ModuleHandler::drpDisplayName, drpDisplayItems, IM_ARRAYSIZE(drpDisplayItems));
				ImGui::SameLine();
				if (ImGui::Button("Save DRP")) {
					ofstream discordFile;
					discordFile.open("Discord.txt");
					if (discordFile.is_open()) {
						discordFile << ModuleHandler::drpDisplayName;
						discordFile.close();
						cout << "Saved Presence" << endl;
					}
				}
				ImGui::Combo(activeLang.Language, &currentLang, langItems, IM_ARRAYSIZE(langItems));

				if (ImGui::Button("Keybinds")) switchTabs = 4;
				break;
			case 4:
				createReassign(activeLang.Jetpack, &KeybindHandler::jetpackKey);
				createReassign(activeLang.Hitbox, &KeybindHandler::hitboxKey);
				createReassign(activeLang.Scaffold, &KeybindHandler::scaffoldKey);
				createReassign(activeLang.Triggerbot, &KeybindHandler::triggerbotKey);
				createReassign(activeLang.AirJump, &KeybindHandler::airjumpKey);
				createReassign(activeLang.AirAcceleration, &KeybindHandler::airaccKey);
				createReassign(activeLang.NoSlowDown, &KeybindHandler::noslowdownKey);
				createReassign(activeLang.NoWeb, &KeybindHandler::nowebKey);
				createReassign(activeLang.NoKnockBack, &KeybindHandler::noknockbackKey);
				createReassign(activeLang.VanillaNoFall, &KeybindHandler::nofallKey);
				createReassign(activeLang.Gamemode, &KeybindHandler::gamemodeKey);
				createReassign(activeLang.Instabreak, &KeybindHandler::instabreakKey);
				createReassign(activeLang.PlayerSpeed, &KeybindHandler::playerspeedKey);
				createReassign(activeLang.Phase, &KeybindHandler::phaseKey);
				createReassign(activeLang.NoWater, &KeybindHandler::nowaterKey);
				createReassign(activeLang.Jesus, &KeybindHandler::jesusKey);
				createReassign(activeLang.Bhop, &KeybindHandler::bhopKey);
				createReassign(activeLang.Criticals, &KeybindHandler::criticalsKey);
				createReassign(activeLang.Flight, &KeybindHandler::flightKey);
				createReassign(activeLang.TpAura, &KeybindHandler::tpauraKey);
				break;
			}

			WindowAlwaysOnTop(hwnd);
			ModuleHandler::ModuleHandler(mem::hProcess);

			ImGui::EndFrame();
			g_pd3dDevice->SetRenderState(D3DRS_ZENABLE, false);
			g_pd3dDevice->SetRenderState(D3DRS_ALPHABLENDENABLE, false);
			g_pd3dDevice->SetRenderState(D3DRS_SCISSORTESTENABLE, false);
			D3DCOLOR clear_col_dx = D3DCOLOR_RGBA((int)(clear_color.x * 255.0f), (int)(clear_color.y * 255.0f), (int)(clear_color.z * 255.0f), (int)(clear_color.w * 255.0f));
			g_pd3dDevice->Clear(0, NULL, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER, clear_col_dx, 1.0f, 0);
			if (g_pd3dDevice->BeginScene() >= 0)
			{
				ImGui::Render();
				ImGui_ImplDX9_RenderDrawData(ImGui::GetDrawData());
				g_pd3dDevice->EndScene();
			}
			HRESULT result = g_pd3dDevice->Present(NULL, NULL, NULL, NULL);


			if (result == D3DERR_DEVICELOST && g_pd3dDevice->TestCooperativeLevel() == D3DERR_DEVICENOTRESET)
				ResetDevice();
		}
		ImGui_ImplDX9_Shutdown();
		ImGui_ImplWin32_Shutdown();
		ImGui::DestroyContext();

		CleanupDeviceD3D();
		::DestroyWindow(hwnd);
		::UnregisterClass(wc.lpszClassName, wc.hInstance);


	}
}

bool CreateDeviceD3D(HWND hWnd)
{
	if ((g_pD3D = Direct3DCreate9(D3D_SDK_VERSION)) == NULL)
		return false;


	ZeroMemory(&g_d3dpp, sizeof(g_d3dpp));
	g_d3dpp.Windowed = TRUE;
	g_d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	g_d3dpp.BackBufferFormat = D3DFMT_UNKNOWN;
	g_d3dpp.EnableAutoDepthStencil = TRUE;
	g_d3dpp.AutoDepthStencilFormat = D3DFMT_D16;
	g_d3dpp.PresentationInterval = D3DPRESENT_INTERVAL_ONE;

	if (g_pD3D->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hWnd, D3DCREATE_HARDWARE_VERTEXPROCESSING, &g_d3dpp, &g_pd3dDevice) < 0)
		return false;

	return true;
}

void CleanupDeviceD3D()
{
	if (g_pd3dDevice) { g_pd3dDevice->Release(); g_pd3dDevice = NULL; }
	if (g_pD3D) { g_pD3D->Release(); g_pD3D = NULL; }
}

void ResetDevice()
{
	ImGui_ImplDX9_InvalidateDeviceObjects();
	HRESULT hr = g_pd3dDevice->Reset(&g_d3dpp);
	if (hr == D3DERR_INVALIDCALL)
		IM_ASSERT(0);
	ImGui_ImplDX9_CreateDeviceObjects();
}


extern LRESULT ImGui_ImplWin32_WndProcHandler(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);
LRESULT WINAPI WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	if (ImGui_ImplWin32_WndProcHandler(hWnd, msg, wParam, lParam))
		return true;

	switch (msg)
	{
	case WM_SIZE:
		if (g_pd3dDevice != NULL && wParam != SIZE_MINIMIZED)
		{
			g_d3dpp.BackBufferWidth = LOWORD(lParam);
			g_d3dpp.BackBufferHeight = HIWORD(lParam);
			ResetDevice();
		}
		return 0;
	case WM_SYSCOMMAND:
		if ((wParam & 0xfff0) == SC_KEYMENU)
			return 0;
		break;
	case WM_DESTROY:
		::PostQuitMessage(0);
		return 0;
	}
	return ::DefWindowProc(hWnd, msg, wParam, lParam);
}