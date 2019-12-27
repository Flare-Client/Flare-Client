#include "tpaura.h"
#include "teleport.h"
#include "EntityList.h"
#include "ModuleHandler.h"

struct vec3 {
	float x;
	float y;
	float z;
};

bool reset = false;
byte swing = 1;
bool switchP = false;
vec3 lastpos;
int tptick;

TpAura::TpAura(HANDLE hProcess, uintptr_t LocalPlayer, std::vector<uintptr_t> EntityList, int option, float range, int tpskips) {
	
	//Made by ASM#6137

	uintptr_t entityFacingAddr = mem::FindAddr(hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 });
	switch (option) {
	case 0:
		reset = true;
		uintptr_t facingEnt;
		ReadProcessMemory(hProcess, (BYTE*)entityFacingAddr, &facingEnt, sizeof(facingEnt), 0);
		
		for (int entity = 0; entity < EntityList.size(); entity++) {
			//Get our local player position
			uintptr_t playerX = mem::FindAddr(hProcess, LocalPlayer, { 0x430 });
			uintptr_t playerY = mem::FindAddr(hProcess, LocalPlayer, { 0x434 });
			uintptr_t playerZ = mem::FindAddr(hProcess, LocalPlayer, { 0x438 });
			float xValPlr;
			float yValPlr;
			float zValPlr;
			ReadProcessMemory(hProcess, (BYTE*)playerX, &xValPlr, sizeof(xValPlr), 0);
			ReadProcessMemory(hProcess, (BYTE*)playerY, &yValPlr, sizeof(yValPlr), 0);
			ReadProcessMemory(hProcess, (BYTE*)playerZ, &zValPlr, sizeof(zValPlr), 0);

			//Get the opponent position
			uintptr_t opponent = EntityList[entity];
			uintptr_t opponentX = mem::FindAddr(hProcess, opponent, { 0x454 });
			uintptr_t opponentY = mem::FindAddr(hProcess, opponent, { 0x458 });
			uintptr_t opponentZ = mem::FindAddr(hProcess, opponent, { 0x45C });
			float xValOp;
			float yValOp;
			float zValOp;
			ReadProcessMemory(hProcess, (BYTE*)opponentX, &xValOp, sizeof(xValOp), 0);
			ReadProcessMemory(hProcess, (BYTE*)opponentY, &yValOp, sizeof(yValOp), 0);
			ReadProcessMemory(hProcess, (BYTE*)opponentZ, &zValOp, sizeof(zValOp), 0);

			//Calculate distance (ignore Y cuz most servers dont consider it
			float distance = sqrt(pow(xValOp - xValPlr, 2) + pow(zValOp - zValPlr, 2));

			//Make sure the entity is in range
			if (distance < range) {
				//a switch for it we are teleporting to the entity or teleporting back
				if (switchP) {
					//Save our position to return to
					lastpos = { xValPlr, yValPlr, zValPlr };
					//Swing arm
					swing = 0;
					WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &swing, sizeof(byte), 0);
					//Teleport
					tptick++;
					if (tptick >= tpskips) {
						Teleport::Teleport(hProcess, xValOp, yValOp, zValOp);
						tptick = 0;
					}
					switchP = false;
				}
				else {
					switchP = true;
					//if the position didn't save, try again.
					if (lastpos.x == 0 || lastpos.y == 0 || lastpos.z == 0) {
						return;
					}
					//teleport backs
					Teleport::Teleport(hProcess, lastpos.x, lastpos.y, lastpos.z);
				}
			}
		}
		break;
	case 1:
		switchP = true;
		if (reset) {
			//Stop swinging
			swing = 1;
			WriteProcessMemory(hProcess, (BYTE*)mem::moduleBase + 0x102460E, &swing, sizeof(byte), 0);
			reset = false;
		}
		break;
	}
	
}