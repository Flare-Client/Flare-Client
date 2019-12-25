#include <iostream>
#include <vector>
#include "GuiLoader.h"
#include "LittleHacker.h"

#include "discord.h"

Discord* g_Discord;

using namespace std;

int main()
{

	g_Discord->Initialize();
	g_Discord->Update((char*)"On the main menu", 0);
	DWORD procID;
	uintptr_t ModuleBase;
	HANDLE hProcess;

	procID = mem::GetProcId(L"Minecraft.Windows.exe");
	if (procID == NULL) {
		cout << "Unable to locate process, make sure Minecraft is running!\n";
	}
	else
	{
		cout << "Minecraft Process ID: " << procID << "\n";
		hProcess = OpenProcess(PROCESS_ALL_ACCESS, NULL, procID);
		ModuleBase = mem::GetModuleBaseAddress(procID, L"Minecraft.Window.exe");

		GuiLoader f;
	}
}