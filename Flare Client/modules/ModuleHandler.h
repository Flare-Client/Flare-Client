#pragma once
#include <iostream>
#include <Windows.h>
#include <vector>

#include "../LittleHacker.h"
#include "../GuiLoader.h"
#include "EntityList.h"
#include "Hitbox.h"
#include "triggerbot.h"
#include "airjump.h"
#include "airaccelerationspeed.h"
#include "noslowdown.h"
#include "noweb.h"
#include "noknockback.h"
#include "nofall.h"
#include "gamemode.h"
#include "instabreak.h"
#include "playerspeed.h"
#include "teleport.h"
#include "phase.h"

class ModuleHandler {
public:
    /* Variables */

    static bool hitboxToggle, triggerbotToggle, airJumpToggle, airaccspeedToggle, noslowdownToggle, nowebToggle, noknockbackToggle, nofallToggle, gamemodeToggle, instabreakToggle, playerspeedtoggle, phaseToggle;
    static float hitboxWidthFloat, hitboxHeightFloat, airAccelerationSpeed, playerSpeedVal, teleportX, teleportY, teleportZ;
    static bool hitboxToggle, triggerbotToggle, airJumpToggle, airaccspeedToggle, noslowdownToggle, nowebToggle, noknockbackToggle, nofallToggle, gamemodeToggle, instabreakToggle, playerspeedToggle;
    static float hitboxWidthFloat, hitboxHeightFloat, airAccelerationSpeed, playerSpeedVal;
    static int gamemodeVal;

    /* Main */
    ModuleHandler(HANDLE hProcess);

    void directionalVector(float vect[], float yaw, float pitch) {
        vect[0] = cos(yaw) * cos(pitch);
        vect[1] = sin(pitch);
        vect[2] = sin(yaw) * cos(pitch);
    };
};