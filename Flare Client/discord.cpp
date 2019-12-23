#include "discord.h"

static int64_t eptime = std::chrono::duration_cast<std::chrono::seconds>(std::chrono::system_clock::now().time_since_epoch()).count();

void Discord::Initialize() {
	DiscordEventHandlers handle;
	memset(&handle, 0, sizeof(handle));
	Discord_Initialize("658514848065257475", &handle, 0, NULL);
}

void Discord::Update(char* details) {
	DiscordRichPresence discordPresence;
	memset(&discordPresence, 0, sizeof(discordPresence));
	discordPresence.state = "Flare Client";
	discordPresence.details = details;
	discordPresence.startTimestamp = eptime;
	discordPresence.endTimestamp = NULL;
	discordPresence.largeImageKey = "icon";
	//discordPresence.largeImageText = "Flare Client";
	discordPresence.smallImageKey = "icon";
	//discordPresence.smallImageText = "Flare Client";

	Discord_UpdatePresence(&discordPresence);
}