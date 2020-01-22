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
#include <locale>
#include <codecvt>
#include <string>
#include "ClickUI.h"

struct ModuleUI {
	const char** name;
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
	uint64_t min;
	uint64_t max;
	SettingType type;
	const char** name;
	bool selected;
};
struct Category {
	const char** name;
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
