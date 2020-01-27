#pragma once
#include <iostream>
#include <Windows.h>
#include <vector>
#include <string>
#include <cstring>
#include <cctype>

#include "../LittleHacker.h"
#include "../UI/TabGui.h"
#include "../mcSDK/LocalPlayer.h"
#include "KeybindHandler.h"
#include "EntityList.h"
#include "Hitbox.h"
#include "TriggerBot.h"
#include "AirJump.h"
#include "AirAccelerationSpeed.h"
#include "NoSlowdown.h"
#include "NoWeb.h"
#include "NoKnockback.h"
#include "NoFall.h"
#include "Gamemode.h"
#include "InstaBreak.h"
#include "Speed.h"
#include "Teleport.h"
#include "Phase.h"
#include "Scaffold.h"
#include "NoWater.h"
#include "Jesus.h"
#include "BunnyHop.h"
#include "Criticals.h"
#include "Flight.h"
#include "TPAura.h"
#include "Step.h"
#include "NoPacket.h"
#include "Freecam.h"
#include "Crasher.h"
#include "Coordinates.h"
#include "NoClip.h"
#include "ClickTP.h"
#include "AutoSprint.h"
#include "Esp.h"
#include "AimBot.h"

#include "../discord.h"

class ModuleHandler {
public:
    /* Variables */

    static bool jetpackToggle, hitboxToggle, triggerbotToggle, airJumpToggle, airaccspeedToggle, noslowdownToggle, nowebToggle, noknockbackToggle, nofallToggle, gamemodeToggle, instabreakToggle, playerspeedToggle, phaseToggle, scaffoldToggle, nowaterToggle, jesusToggle, bhopToggle, criticalsToggle, flightToggle, tpauraToggle, stepAssistToggle, nopacketToggle, freecamToggle, servercrasherToggle, coordinatesToggle, noClipToggle, clicktpToggle, autoSprintToggle, espToggle, aimbotToggle;
    static float hitboxWidthFloat, hitboxHeightFloat, airAccelerationSpeed, playerSpeedVal, teleportX, teleportY, teleportZ, jesusVal, bhopVal, tpauraRange, jetpackVal;
    static int gamemodeVal, tpauraSkips;
	static int drpDisplayName;

    /* Main */
    ModuleHandler(HANDLE hProcess, HWND host);

    void directionalVector(float vect[], float yaw, float pitch) {
        vect[0] = cos(yaw) * cos(pitch);
        vect[1] = sin(pitch);
        vect[2] = sin(yaw) * cos(pitch);
    };
};