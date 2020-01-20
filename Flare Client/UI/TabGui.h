#pragma once
#include <tchar.h>
#include <fstream>
#include <iostream>
#include <windows.h>
#include "../LittleHacker.h"
#include "../Lang.h"
#include <strsafe.h>

struct Category {
	std::string name;
	bool selected;
};

class TabGui
{
public:
	TabGui();
};
