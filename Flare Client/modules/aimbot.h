#pragma once
#include <iostream>
#include <algorithm>
#include "ModuleHandler.h"

class Aimbot {
public:
	Aimbot(HANDLE hProcess, std::vector<uintptr_t> EntityList);
};

