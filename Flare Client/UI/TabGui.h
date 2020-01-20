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
#include <vector>

enum SettingType {
	Slider
};
struct ModuleUI {
	std::string name;
	bool selected;
	bool* moduleToggle;
};
struct Setting {
	SettingType type;
	std::string name;
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
