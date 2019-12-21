#pragma once
#include <windows.h>
#include <vector>

namespace mem
{
	void Patch(BYTE* dst, BYTE* src, unsigned int size);
	void PatchEx(BYTE* dst, BYTE* src, unsigned int size, HANDLE hProcess);
	void Nop(BYTE* dst, unsigned int size);
	void NopEx(BYTE* dst, unsigned int size, HANDLE hProcess);
	uintptr_t FindAddr(HANDLE hProc, uintptr_t ptr, std::vector<unsigned int> offsets);
	DWORD GetProcId(const wchar_t* procName);
	uintptr_t GetModuleBaseAddress(DWORD procId, const wchar_t* modName);
	static DWORD procId = mem::GetProcId(L"Minecraft.Windows.exe");
	static DWORD frameId = mem::GetProcId(L"ApplicationFrameHost.exe");
	static HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, NULL, procId);
	static uintptr_t moduleBase = mem::GetModuleBaseAddress(procId, L"Minecraft.Windows.exe");
}