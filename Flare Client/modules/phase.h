#pragma once
#include "../LittleHacker.h"
#include "ModuleHandler.h"

class Phase {
public:
	Phase(HANDLE hProcess, uintptr_t localPlayer, char option);
	static bool oneTimeWrite;
};

