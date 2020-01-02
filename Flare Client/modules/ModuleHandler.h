#pragma once
#include <iostream>
#include <Windows.h>
#include <vector>
#include <string>
#include <cstring>

#include "../LittleHacker.h"
#include "../GuiLoader.h"
#include "../LocalPlayer.h"
#include "keybindhandler.h"
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
#include "scaffold.h"
#include "nowater.h"
#include "jesus.h"
#include "bhop.h"
#include "criticals.h"
#include "flight.h"
#include "tpaura.h"

#include "../discord.h"

class ModuleHandler {
public:
    /* Variables */

    static bool jetpackToggle, hitboxToggle, triggerbotToggle, airJumpToggle, airaccspeedToggle, noslowdownToggle, nowebToggle, noknockbackToggle, nofallToggle, gamemodeToggle, instabreakToggle, playerspeedToggle, phaseToggle, scaffoldToggle, nowaterToggle, jesusToggle, bhopToggle, criticalsToggle, flightToggle, tpauraToggle;
    static float hitboxWidthFloat, hitboxHeightFloat, airAccelerationSpeed, playerSpeedVal, teleportX, teleportY, teleportZ, jesusVal, bhopVal, tpauraRange;
    static int gamemodeVal, tpauraSkips;

	static int drpDisplayName;

    /* Main */
    ModuleHandler(HANDLE hProcess);

    void directionalVector(float vect[], float yaw, float pitch) {
        vect[0] = cos(yaw) * cos(pitch);
        vect[1] = sin(pitch);
        vect[2] = sin(yaw) * cos(pitch);
    };
};