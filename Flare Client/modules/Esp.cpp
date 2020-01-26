#include "Esp.h"

//I don't know how this shit works, I followed this: https://guidedhacking.com/threads/csgo-simple-esp.12760/?__cf_chl_jschl_tk__=309ce74cec3fbf0f45e6dad7651f84fe7274a761-1579841786-0-AScFt1k_soANSmkQLUPCGSN5n2HNtOdnpu2_Q4s1wgNjAUziiQxmpP5k5XTV3A-zBSihbNfO1eLhBRFtKxIKrR8hvLdn1WEfJ7oc4pM-pvcWqGFMhevOlM2weQ-X2fSXGZHU0aUVXEfjRQX3Uc7wqWDLc5DJo_OOYuq6LQrTnUkAp_Zj461akuCwdVNyKeOkn5x6izlWgx4FGtBPcY4ZitSmO7sOPKvRG4M1vK0G78Wg15Xwf8kVzS6kNk5rfHe4soBtON6IfXaUVSsTy5eEat1f0n1TiB1lmtf3APTVqELK

Gdiplus::Pen cPen(Gdiplus::Color(255, 255, 0, 0));
float Matrix[16];
HANDLE hProcess;
std::vector<uintptr_t> EntityList;
Esp::Esp(HANDLE hProcesss, std::vector<uintptr_t> EntityListt) {
    hProcess = hProcesss;
    EntityList = EntityListt;
}

void Esp::OnPaint(Gdiplus::Graphics* g, int windowWidth, int windowHeight) {
    //Base of player
    Vec2 vScreen;
    //Head of player
    Vec2 vHead;

    for (int entity = 0; entity < EntityList.size(); entity++) {
        //Get the opponent position
        uintptr_t opponent = EntityList[entity];
        uintptr_t opponentX = mem::FindAddr(hProcess, opponent, { Player::currentX1 });
        uintptr_t opponentY = mem::FindAddr(hProcess, opponent, { Player::currentY1 });
        uintptr_t opponentZ = mem::FindAddr(hProcess, opponent, { Player::currentZ1 });
        Vec3 pos = { opponentX, opponentY, opponentZ };

        ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, mem::moduleBase + 0x029C9A98, { 0xB0, 0xE08 }), &Matrix, sizeof(Matrix), NULL);
        
        if (WorldToScreen(pos, vScreen, Matrix, windowWidth, windowHeight)) {
            if (WorldToScreen(pos, vHead, Matrix, windowWidth, windowHeight)) {
                float head = vHead.y - vScreen.y;
                float width = head / 2;
                float center = width / -2;
                Gdiplus::RectF bocks = { vScreen.x, vScreen.y, width, head - 5 };
                g->DrawRectangle(&cPen, bocks);
            }
        }
    }
}

bool Esp::WorldToScreen(Vec3 pos, Vec2& screen, float matrix[16], int windowWidth, int windowHeight)
{
    Vec4 clipCoords;
    clipCoords.x = pos.x * matrix[0] + pos.y * matrix[1] + pos.z * matrix[2] + matrix[3];
    clipCoords.y = pos.x * matrix[4] + pos.y * matrix[5] + pos.z * matrix[6] + matrix[7];
    clipCoords.z = pos.x * matrix[8] + pos.y * matrix[9] + pos.z * matrix[10] + matrix[11];
    clipCoords.w = pos.x * matrix[12] + pos.y * matrix[13] + pos.z * matrix[14] + matrix[15];

    if (clipCoords.w < 0.1f)
        return false;


    Vec3 NDC;
    NDC.x = clipCoords.x / clipCoords.w;
    NDC.y = clipCoords.y / clipCoords.w;
    NDC.z = clipCoords.z / clipCoords.w;

    screen.x = (windowWidth / 2 * NDC.x) + (NDC.x + windowWidth / 2);
    screen.y = -(windowHeight / 2 * NDC.y) + (NDC.y + windowHeight / 2);
    return true;
}