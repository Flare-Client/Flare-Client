#pragma once
#include <Windows.h>
#include <vector>
#include <string>
#include <iostream>

class EntityList {
public:
	static std::vector<uintptr_t> EntityListHandler(HANDLE hProcess, uintptr_t localPlayer);
};