#pragma once
#include "../LittleHacker.h"

class Instabreak {
public:
	Instabreak(HANDLE hProcess, byte value);
	static bool oneTimePatch;
};

