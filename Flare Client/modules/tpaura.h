#pragma once
#include "../LittleHacker.h"

class TpAura {
public:
	TpAura(HANDLE hProcess, uintptr_t LocalPlayer, std::vector<uintptr_t> EntityList, int option, float range, int tpskips);
};