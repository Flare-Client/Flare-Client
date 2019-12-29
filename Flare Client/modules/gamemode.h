#pragma once
#include <iostream>
#include "../LittleHacker.h"

class Gamemode {
public:
	Gamemode(HANDLE hProcess, uintptr_t LocalPlayer, int gamemodeVal, int toggle);
};