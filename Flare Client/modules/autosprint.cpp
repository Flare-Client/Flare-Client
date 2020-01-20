#include "autosprint.h"

AutoSprint::AutoSprint(HANDLE hProcess, int toggle) {
	if (toggle) {
		mem::NopEx((BYTE*)pointers::SprintInstruction(), 5, hProcess);
	}
	else {
		mem::PatchEx((BYTE*)pointers::SprintInstruction(), (BYTE*)gameBytes::SPRINTINSTRUCTIONBYTES, 5, hProcess);
	}
}