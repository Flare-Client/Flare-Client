#include "ModuleHandler.h"

using namespace std;

int GuiLoaderTicker = 0;

bool ModuleHandler::hitboxToggle = false;
bool ModuleHandler::triggerbotToggle = false; 
bool ModuleHandler::airJumpToggle = false;
bool ModuleHandler::airaccspeedToggle = false;
bool ModuleHandler::noslowdownToggle = false;
bool ModuleHandler::nowebToggle = false;
bool ModuleHandler::noknockbackToggle = false;
bool ModuleHandler::nofallToggle = false;
bool ModuleHandler::gamemodeToggle = false;
bool ModuleHandler::instabreakToggle = false;
bool ModuleHandler::playerspeedtoggle = false;

float ModuleHandler::hitboxWidthFloat = 6.f;
float ModuleHandler::hitboxHeightFloat = 3.f;
float ModuleHandler::airAccelerationSpeed = 0.1;
float ModuleHandler::playerSpeedVal = 0.45;

int ModuleHandler::gamemodeVal = 1;

ModuleHandler::ModuleHandler(HANDLE hProcess) {
	uintptr_t LocalPlayer = mem::FindAddr(hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x10, 0x40, 0x0 });
	uintptr_t UIOpen = mem::FindAddr(hProcess, mem::moduleBase + 0x02FA94F0, { 0x200, 0x128, 0x40, 0x8, 0x248 });

	vector<uintptr_t> EntityListArr = EntityList::EntityListHandler(hProcess, LocalPlayer);

	GuiLoaderTicker += 1;

	if (GetAsyncKeyState(VK_F6)) {
		if (GuiLoaderTicker > 60) {
			if (GuiLoader::windowToggle) {
				GuiLoader::windowToggle = false;
			}
			else if (!GuiLoader::windowToggle) {
				GuiLoader::windowToggle = true;
			}
			GuiLoaderTicker = 0;
		}
	}

	if (GetAsyncKeyState('F')) {
		int UI;
		ReadProcessMemory(hProcess, (BYTE*)UIOpen, &UI, sizeof(UI), 0);
		if (UI) {
			float vect[3], pitch, yaw;
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, LocalPlayer, { 0xF0 }), &pitch, sizeof(pitch), 0);
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, LocalPlayer, { 0xF4 }), &yaw, sizeof(yaw), 0);
			ModuleHandler::directionalVector(vect, (yaw + 90) * 3.141592653589793 / 180, pitch * 3.141592653589793 / 180);
			float X = 1.2 * vect[0];
			float Y = 1.2 * -vect[1];
			float Z = 1.2 * vect[2];
			WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, LocalPlayer, { 0x46C }), &X, sizeof(X), 0);
			WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, LocalPlayer, { 0x470 }), &Y, sizeof(Y), 0);
			WriteProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, LocalPlayer, { 0x474 }), &Z, sizeof(Z), 0);
		}
	}

	if (ModuleHandler::hitboxToggle) {
		Hitbox::HitboxWidth(hProcess, EntityListArr, ModuleHandler::hitboxWidthFloat);
		Hitbox::HitboxHeight(hProcess, EntityListArr, ModuleHandler::hitboxHeightFloat);
	}
	else if (!ModuleHandler::hitboxToggle) {
		Hitbox::HitboxWidth(hProcess, EntityListArr, 0.6);
		Hitbox::HitboxHeight(hProcess, EntityListArr, 1.8);
	}
	if (ModuleHandler::triggerbotToggle) {
		TriggerBot::TriggerBot(hProcess, 'N');
	}
	else if (!ModuleHandler::triggerbotToggle) {
		TriggerBot::TriggerBot(hProcess, 'F');
	}
	if (ModuleHandler::airJumpToggle) {
		AirJump::AirJump(hProcess, LocalPlayer);
	}
	if (ModuleHandler::airaccspeedToggle) {
		AirAccelerationSpeed::AirAccelerationSpeed(hProcess, LocalPlayer, ModuleHandler::airAccelerationSpeed);
	}
	if (ModuleHandler::noslowdownToggle) {
		NoSlowDown::NoSlowDown(hProcess, 'N');
	}
	else if (!ModuleHandler::noslowdownToggle) {
		NoSlowDown::NoSlowDown(hProcess, 'F');
	}
	if (ModuleHandler::nowebToggle) {
		NoWeb::NoWeb(hProcess, 'N');
	}
	else if (!ModuleHandler::nowebToggle) {
		NoWeb::NoWeb(hProcess, 'F');
	}
	if (ModuleHandler::noknockbackToggle) {
		NoKnockBack::NoKnockBack(hProcess, 'N');
	}
	else if (!ModuleHandler::noknockbackToggle) {
		NoKnockBack::NoKnockBack(hProcess, 'F');
	}
	if (ModuleHandler::nofallToggle) {
		NoFall::NoFall(hProcess, LocalPlayer);
	}
	if (ModuleHandler::gamemodeToggle) {
		Gamemode::Gamemode(hProcess, LocalPlayer, ModuleHandler::gamemodeVal);
	}
	else if (!ModuleHandler::gamemodeToggle) {
		Gamemode::Gamemode(hProcess, LocalPlayer, 5);
	}
	if (ModuleHandler::instabreakToggle) {
		Instabreak::Instabreak(hProcess, 1);
	}
	else if (!ModuleHandler::instabreakToggle) {
		Instabreak::Instabreak(hProcess, 0);
	}
	if (ModuleHandler::playerspeedtoggle) {
		PlayerSpeed::PlayerSpeed(hProcess, ModuleHandler::playerSpeedVal);
	}
}