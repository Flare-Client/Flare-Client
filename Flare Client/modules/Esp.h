#pragma once
#include "ModuleHandler.h"

//defining our vectors
struct Vec3
{
    float x, y, z;
};
struct Vec4
{
    float x, y, z, w;
};
struct Vec2
{
    float x, y;
};

class Esp
{
public:
	Esp(HANDLE hProcesss, std::vector<uintptr_t> EntityListt);
    static void OnPaint(Gdiplus::Graphics* g, int windowWidth, int windowHeight);
	static bool WorldToScreen(Vec3 pos, Vec2& screen, float matrix[16], int windowWidth, int windowHeight);
};

