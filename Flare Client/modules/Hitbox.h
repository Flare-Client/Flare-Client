#pragma once
#include "../LittleHacker.h"
#include "ModuleHandler.h"

class Hitbox {
public:
	Hitbox(HANDLE hProcess, std::vector<uintptr_t> EntityList, float widthValue, float heightValue);
};