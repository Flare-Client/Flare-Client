#pragma once
#include "ModuleHandler.h"

class EntityList {
public:
	static std::vector<uintptr_t> EntityListHandler(HANDLE hProcess, uintptr_t localPlayer);
};