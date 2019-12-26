#pragma once
struct Lang {
	//Categories
	const char* Combat;
	const char* Movement;
	const char* Misc;
	const char* Settings;
	const char* Keybinds;

	//Combat
	const char* Hitbox;
	const char* Triggerbot;

	//Movement
	const char* AirJump;
	const char* AirAcceleration;
	const char* NoSlowDown;
	const char* NoKnockBack;
	const char* PlayerSpeed;

	//Misc
	const char* NoWeb;
	const char* VanillaNoFall;
	const char* Gamemode;
	const char* Instabreak;
	const char* Phase;

	//Settings
};

Lang getEnglish() {
	Lang english = {
		//Categories
		"Combat",
		"Movement",
		"Misc",
		"Settings",
		"Keybinds",

		//Combat
		"Hitbox",
		"Triggerbot",

		//Movement
		"AirJump",
		"AirAcceleration",
		"NoSlowDown",
		"No KnockBack",
		"PlayerSpeed",

		//Misc
		"NoWeb",
		"VanillaNoFall",
		"Gamemode",
		"Instabreak",
		"Phase"
	};
	return english;
}

Lang getItalian() {
	Lang italian = {
		"Combattimento",
		"Movimento",
		"Varie",
		"Impostaz.",
		"Keybinds",

		//Combat
		"Hitbox",
		"Triggerbot",

		//Movement
		"Salta Aria",
		"Accelerazione di Aria",
		"No Rallenta",
		"No KnockBack",
		"Velocita",

		//Misc
		"No Ragnatela",
		"Vanilla NoCad.",
		"Gamemode",
		"Instabreak",
		"Fase"
	};
	return italian;
}