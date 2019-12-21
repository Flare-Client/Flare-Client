#pragma once
#include <Windows.h>
#include <vector>

class Hitbox {
public:
	static float HitboxWidth(HANDLE hProcess, std::vector<uintptr_t> EntityList, float value);
	static float HitboxHeight(HANDLE hProcess, std::vector<uintptr_t> EntityList, float value);
};