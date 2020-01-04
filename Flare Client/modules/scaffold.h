#pragma once
#include "../LittleHacker.h"
#include "ModuleHandler.h"
#include <vector>

class Scaffold {
public:
	Scaffold(HANDLE hProcess, int toggle);
	static void SpecifyBlockFace(int blockSide);
	static void SpecifiyBlockPosition(int X, int Y, int Z);
	static void AdditionalCalculations(float X, float Y, float Z, float playerYaw);
};

