#pragma once
#include "../LittleHacker.h"
#include "ModuleHandler.h"

class Gamemode {
public:
	Gamemode(HANDLE hProcess, uintptr_t LocalPlayer, int gamemodeVal, int toggle);
};