#include <iostream>
#include <vector>
#include "GuiLoader.h"
#include "LittleHacker.h"

#include "modules/EntityList.h"
#include "modules/Hitbox.h"

void GetGameKeyInput(HANDLE hProcess);

using namespace std;

int main()
{
	DWORD procID;
	uintptr_t ModuleBase;
	HANDLE hProcess;

	procID = mem::GetProcId(L"Minecraft.Windows.exe");
	if (procID == NULL) {
		cout << "Unable to locate process, make sure Minecraft is running!!\n";
	}
	else
	{
		cout << "Minecraft Process ID: " << procID << "\n";
		hProcess = OpenProcess(PROCESS_ALL_ACCESS, NULL, procID);
		ModuleBase = mem::GetModuleBaseAddress(procID, L"Minecraft.Window.exe");

		GuiLoader f;
	}
}