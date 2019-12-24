#pragma once
#include "Discord/discord_register.h"
#include "Discord/discord_rpc.h"
#include <Windows.h>
#include <chrono>

class Discord {
public:
    static void Initialize();
    static void Update(char* details, int entityListSize);
};