#pragma once
#include <Windows.h>
#include <vector>

class Hitbox {
public:
	Hitbox(HANDLE hProcess, std::vector<uintptr_t> EntityList, float width, float height);
};