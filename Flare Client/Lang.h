#pragma once
struct Lang {
	//Meta
	const char* Name;
	const char* Language;

	//Categories
	const char* Combat;
	const char* Movement;
	const char* Misc;
	const char* Settings;
	const char* Keybinds;

	//Combat
	const char* Hitbox;
	const char* Triggerbot;
	const char* Criticals;
	const char* TpAura;

	//Movement
	const char* Jetpack;
	const char* AirJump;
	const char* AirAcceleration;
	const char* NoSlowDown;
	const char* NoKnockBack;
	const char* PlayerSpeed;
	const char* NoWater;
	const char* Jesus;
	const char* Bhop;
	const char* Flight;

	//Misc
	const char* NoWeb;
	const char* VanillaNoFall;
	const char* Gamemode;
	const char* Instabreak;
	const char* Phase;
	const char* Scaffold;

	//Settings
};

Lang getEnglish() {
	Lang english = {
		//Meta
		"English",
		"Language",

		//Categories
		"Combat",
		"Movement",
		"Misc",
		"Settings",
		"Keybinds",

		//Combat
		"Hitbox",
		"Triggerbot",
		"Criticals",
		"TpAura",

		//Movement
		"Jetpack",
		"AirJump",
		"AirAcceleration",
		"NoSlowDown",
		"No KnockBack",
		"PlayerSpeed",
		"NoWater",
		"Jesus",
		"Bunny-Hop",
		"Flight",

		//Misc
		"NoWeb",
		"VanillaNoFall",
		"Gamemode",
		"Instabreak",
		"Phase",
		"Scaffold"
	};
	return english;
}

Lang getItalian() {
	Lang italian = {
		//Meta
		"Italiano",
		"Linguaggio",

		//Categories
		"Combattimento",
		"Movimento",
		"Varie",
		"Impostaz.",
		"Keybinds",

		//Combat
		"Hitbox",
		"Triggerbot",
		"Critici",
		"TpAura",

		//Movement
		"Jetpack",
		"Salta Aria",
		"Accelerazione di Aria",
		"No Rallenta",
		"No KnockBack",
		"Velocita",
		"NoAcqua",
		"Gesu",
		"Salto del Coniglietto",
		"Vola",

		//Misc
		"No Ragnatela",
		"Vanilla NoCad.",
		"Gamemode",
		"Instabreak",
		"Fase",
		"Impalcatura"
	};
	return italian;
}