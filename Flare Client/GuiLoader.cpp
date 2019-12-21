//IMGUI Includes
#include "GuiLoader.h"
#include "Imgui/imgui.h"
#include "Imgui/imgui_impl_dx9.h"
#include "Imgui/imgui_impl_win32.h"
#include <d3d9.h>
#include <tchar.h>
#define DIRECTINPUAT_VERSION 0x0900
#pragma comment(lib,"d3d9.lib")

#include "modules/ModuleHandler.h"

bool GuiLoader::windowToggle = true;


static LPDIRECT3D9              g_pD3D = NULL;
static LPDIRECT3DDEVICE9        g_pd3dDevice = NULL;
static D3DPRESENT_PARAMETERS    g_d3dpp = {};

bool CreateDeviceD3D(HWND hWnd);
void CleanupDeviceD3D();
void ResetDevice();
LRESULT WINAPI WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

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

GuiLoader::GuiLoader() {
	{
		WNDCLASSEX wc = { sizeof(WNDCLASSEX), CS_CLASSDC, WndProc, 0L, 0L, GetModuleHandle(NULL), NULL, NULL, NULL, NULL, _T("Flare Client"), NULL };
		::RegisterClassEx(&wc);
		HWND hwnd = ::CreateWindow(wc.lpszClassName, NULL, WS_POPUP, 0, 0, 700, 700, NULL, NULL, wc.hInstance, NULL);

		if (!CreateDeviceD3D(hwnd))
		{
			CleanupDeviceD3D();
			::UnregisterClass(wc.lpszClassName, wc.hInstance);

		}

		::ShowWindow(hwnd, SW_SHOW);
		::UpdateWindow(hwnd);

		IMGUI_CHECKVERSION();
		ImGui::CreateContext();
		ImGuiIO& io = ImGui::GetIO(); (void)io;



		ImGui::StyleColorsDark();


		ImGui_ImplWin32_Init(hwnd);
		ImGui_ImplDX9_Init(g_pd3dDevice);




		bool show_menu = true;
		bool show_another_window = false;
		ImVec4 clear_color = ImVec4(0.45f, 0.55f, 0.60f, 1.00f);


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


			ImGui::Begin("Flare Client");
			ImGui::SetWindowSize(ImVec2(700, 700));
			ImGui::SetWindowPos(ImVec2(0, 0));

			static int switchTabs = 3;

			if (ImGui::Button("Combat", ImVec2(100.0f, 0.0f)))
				switchTabs = 0;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button("Movement", ImVec2(100.0f, 0.0f)))
				switchTabs = 1;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button("Misc", ImVec2(100.0f, 0.0f)))
				switchTabs = 2;
			ImGui::SameLine(0.0, 2.0f);
			if (ImGui::Button("Settings", ImVec2(100.0f, 0.0f)))
				switchTabs = 3;

			switch (switchTabs) {
			case 0:
				
				ImGui::Checkbox("Hitbox", &ModuleHandler::hitboxToggle);
				ImGui::Checkbox("Triggerbot", &ModuleHandler::triggerbotToggle);
				break;
			case 1:
				ImGui::Checkbox("AirJump", &ModuleHandler::airJumpToggle);
				ImGui::Checkbox("Air Acceleration", &ModuleHandler::airaccspeedToggle);
				ImGui::Checkbox("NoSlowDown", &ModuleHandler::noslowdownToggle);
				ImGui::Checkbox("NoKnockBack", &ModuleHandler::noknockbackToggle);
				break;
			case 2:
				ImGui::Checkbox("NoWeb", &ModuleHandler::nowebToggle);
				ImGui::Checkbox("Vanilla NoFall", &ModuleHandler::nofallToggle);
				ImGui::Checkbox("Gamemode", &ModuleHandler::gamemodeToggle);
				break;
			case 3:
				const char* gamemodeItems[] = { "Survival", "Creative", "Adventure" };
				ImGui::SliderFloat("Hitbox: Width", &ModuleHandler::hitboxWidthFloat, 0.6, 12.f);
				ImGui::SliderFloat("Hitbox: Height", &ModuleHandler::hitboxHeightFloat, 0.6, 12.f);
				ImGui::SliderFloat("Air Acceleration", &ModuleHandler::airAccelerationSpeed, 0.05, 0.5);
				ImGui::Combo("Gamemode", &ModuleHandler::gamemodeVal, gamemodeItems, IM_ARRAYSIZE(gamemodeItems));
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
