#pragma once
#include "../LittleHacker.h"

class Phase {
public:
	Phase(HANDLE hProcess, uintptr_t localPlayer, char option);
	static bool oneTimeWrite;
};

