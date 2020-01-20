#pragma once
#include <tchar.h>
#include <fstream>
#include <iostream>
#include <windows.h>
#include "../LittleHacker.h"
#include "../Lang.h"
#include "../modules/ModuleHandler.h"
#include <strsafe.h>
#include <objidl.h>
#include <gdiplus.h>
#include <list>

struct ModuleUI {
	std::string name;
	bool selected;
	bool* moduleToggle;
};
struct Category {
	std::string name;
	bool selected;
	bool active;
	int moduleCount;
	std::vector<ModuleUI> modules;
};


class TabGui
{
public:
	TabGui();
};
