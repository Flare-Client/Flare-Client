#include "gamemode.h"

using namespace std;

bool oneTimeWriteGM;
int savedGamemode;

Gamemode::Gamemode(HANDLE hProcess, uintptr_t LocalPlayer, int gamemodeVal, int toggle) {
	uintptr_t gamemodeAddr = mem::FindAddr(hProcess, LocalPlayer, { Player::currentGamemode });
	uintptr_t displayCreativeItemsAddr = mem::FindAddr(hProcess, LocalPlayer, { Player::viewCreativeItems });
	switch (toggle) {
	case 0:
		if (oneTimeWriteGM) {
			WriteProcessMemory(hProcess, (BYTE*)gamemodeAddr, &savedGamemode, sizeof(savedGamemode), 0);
			if (savedGamemode != 1) {
				byte val = 0;
				WriteProcessMemory(hProcess, (BYTE*)displayCreativeItemsAddr, &val, sizeof(val), 0);
			}
			oneTimeWriteGM = false;
		}
		break;

	case 1:
		if (!oneTimeWriteGM) {
			ReadProcessMemory(hProcess, (BYTE*)gamemodeAddr, &savedGamemode, sizeof(savedGamemode), 0);
			WriteProcessMemory(hProcess, (BYTE*)gamemodeAddr, &gamemodeVal, sizeof(gamemodeVal), 0);
			if (gamemodeVal == 1) {
				byte val = 1;
				WriteProcessMemory(hProcess, (BYTE*)displayCreativeItemsAddr, &val, sizeof(val), 0);
			}
			oneTimeWriteGM = true;
		}
		break;
	}
}