#pragma once
struct Lang {
	/*
		Meta
	*/
	const char* Name;
	const char* Language;

	/*
		Categories
	*/
	const char* Combat;
	const char* Movement;
	const char* Misc;
	const char* Settings;

	/*
		Combat
	*/
	const char* Hitbox;
	const char* Triggerbot;
	const char* Criticals;
	const char* TpAura;

	/*
		Movement
	*/
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

	/*
		Misc
	*/
	const char* NoWeb;
	const char* VanillaNoFall;
	const char* Gamemode;
	const char* Instabreak;
	const char* Phase;
	const char* Scaffold;

	/*
		Settings
	*/
	const char* HitboxWidthSlider;
	const char* HitboxHeightSlider;
	const char* AirAccSlider;
	const char* PlayerSpeedSlider;
	const char* JesusSlider;
	const char* BhopSlider;
	const char* GamemodeSwitcher;
	const char* TeleportText;
	const char* TeleportButton;
	const char* TpAuraRange;
	const char* TpAuraSkips;
	const char* Theme;
	const char* ThemeSaveButton;
	const char* DrpText;
	const char* DrpSwitcher;
	const char* DrpSaveButton;
	const char* Keybinds;

	/*
		Etc
	*/
	//Gamemode names
	const char* Survival;
	const char* Creative;
	const char* Adventure;
};

Lang getEnglish() {
	Lang english = {
		/*
			Meta
		*/
		"English",
		"Language",

		/*
			Categories
		*/
		"Combat",
		"Movement",
		"Misc",
		"Settings",

		/*
			Combat
		*/
		"Hitbox",
		"Triggerbot",
		"Criticals",
		"TpAura",

		/*
			Movement
		*/
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

		/*
			Misc
		*/
		"NoWeb",
		"VanillaNoFall",
		"Gamemode",
		"Instabreak",
		"Phase",
		"Scaffold",

		/*
			Settings
		*/
		"Hitbox Width",
		"Hitbox Height",
		"Air Acceleration Speed",
		"Player Speed Modifier",
		"Jesus Boost",
		"Bhop Boost",
		"Gamemode",
		"Teleport",
		"Teleport",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Theme",
		"Save",
		"DrpText",
		"DrpSwitcher",
		"DrpSaveButton",
		"Keybinds",

		/*
			Etc
		*/
		//Gamemode names
		"Survival",
		"Creative",
		"Adventure"
	};
	return english;
}

Lang getItalian() {
	Lang italian = {
		/*
			Meta
		*/
		"Italiano",
		"Linguaggio",

		/*
			Categories
		*/
		"Combattimento",
		"Movimento",
		"Varie",
		"Impostaz.",

		/*
			Combat
		*/
		"Hitbox",
		"Triggerbot",
		"Critici",
		"TpAura",

		/*
			Movement
		*/
		"Zaino-Jet",
		"Salta Aria",
		"Accelerazione di Aria",
		"No Rallenta",
		"No KnockBack",
		"Velocita",
		"NoAcqua",
		"Gesu",
		"Salto del Coniglietto",
		"Vola",

		/*
			Misc
		*/
		"No Ragnatela",
		"Vanilla NoCad.",
		"Gamemode",
		"Instabreak",
		"Fase",
		"Impalcatura",

		/*
			Settings
		*/
		"Hitbox Width",
		"Hitbox Height",
		"Air Acceleration Speed",
		"Player Speed Modifier",
		"Jesus Boost",
		"Bhop Boost",
		"Gamemode",
		"Teleport",
		"Teleport",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Theme",
		"Save",
		"DrpText",
		"DrpSwitcher",
		"DrpSaveButton",
		"Keybinds",

		/*
			Etc
		*/
		//Gamemode names
		"Survival",
		"Creative",
		"Adventure"
	};
	return italian;
}

Lang getSpanish() {
	Lang spanish = {
		/*
			Meta
		*/
		"Espanol",
		"Idioma",

		/*
			Categories
		*/
		"Combate",
		"Movimiento",
		"Miscelaneo",
		"Config.",

		/*
			Combat
		*/
		"Hitbox",
		"Gatillo",
		"Criticos",
		"TpAura",

		/*
			Movement
		*/
		"Mochila Cohete",
		"Salto Aereo",
		"Aceleracion de Aire",
		"No Desacelerar",
		"No Bloquear",
		"Velocidad del Jugador",
		"NoAgua",
		"Jesus",
		"Saltar del Conejo",
		"Vuelo",

		/*
			Misc
		*/
		"NoTelarana",
		"VanillaNoCaerse",
		"Modo de Juego",
		"Instabreak",
		"Fase",
		"Andamio",

		/*
			Settings
		*/
		"Hitbox Width",
		"Hitbox Height",
		"Air Acceleration Speed",
		"Player Speed Modifier",
		"Jesus Boost",
		"Bhop Boost",
		"Gamemode",
		"Teleport",
		"Teleport",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Theme",
		"Save",
		"DrpText",
		"DrpSwitcher",
		"DrpSaveButton",
		"Keybinds",

		/*
			Etc
		*/
		//Gamemode names
		"Survival",
		"Creative",
		"Adventure"
	};
	return spanish;
}