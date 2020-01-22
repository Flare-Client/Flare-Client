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
#include "ClickUI.h"

struct ModuleUI {
	std::string name;
	bool selected;
	bool* moduleToggle;
};
static enum SettingType {
	Bool,
	Byte,
	Int,
	Float
};
struct Setting {
	uint64_t* valuePtr;
	SettingType type;
	std::string name;
	bool selected;
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
