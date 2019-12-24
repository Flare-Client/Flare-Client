#include "discord.h"

static int64_t eptime = std::chrono::duration_cast<std::chrono::seconds>(std::chrono::system_clock::now().time_since_epoch()).count();

void Discord::Initialize() {
	DiscordEventHandlers handle;
	memset(&handle, 0, sizeof(handle));
	Discord_Initialize("658514848065257475", &handle, 1, NULL);
}

void Discord::Update(char* details, int entityListSize) {
	DiscordRichPresence discordPresence;
	memset(&discordPresence, 0, sizeof(discordPresence));
	discordPresence.state = "Minecraft";
	discordPresence.details = details;
	discordPresence.startTimestamp = eptime;
	discordPresence.endTimestamp = NULL;
	discordPresence.largeImageKey = "flare";
	discordPresence.largeImageText = "Flare Client";
	discordPresence.smallImageKey = "flaresmall";
	discordPresence.smallImageText = "Hacking in style";
	discordPresence.partySize = 1;
	discordPresence.partyMax = entityListSize + 1;

	Discord_UpdatePresence(&discordPresence);
}