#pragma once
static struct Lang {
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
	const char* NoPacket;
	const char* Freecam;
	const char* ServerCrasher;
	const char* Coordinates;

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

static Lang getEnglish() {
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
		"Air Acceleration",
		"NoSlowDown",
		"No KnockBack",
		"Player Speed",
		"NoWater",
		"Jesus",
		"Bunny-Hop",
		"Flight",

		/*
			Misc
		*/
		"NoWeb",
		"Vanilla NoFall",
		"Gamemode",
		"Instabreak",
		"Phase",
		"Scaffold",
		"No Packet",
		"Freecam",
		"Server Crasher",
		"Coordinates",

		/*
			Settings
		*/
		"Hitbox Width",
		"Hitbox Height",
		"Air Acceleration",
		"Player Speed",
		"Jesus Boost",
		"Bhop Boost",
		"Gamemode",
		"Teleport",
		"Teleport",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Theme",
		"Save Theme",
		"DRP",
		"Save DRP",
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

static Lang getItalian() {
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
		"Modalita di gioco",
		"Instabreak",
		"Fase",
		"Impalcatura",
		"NoPacket",
		"Cam gratis",
		"Server schianto",
		"Coordinate",

		/*
			Settings
		*/
		"Hitbox Larghezza",
		"Hitbox Altezza",
		"Accelerazione dell'aria",
		"Velocita del giocatore",
		"Jesus Incremento",
		"Bhop Incremento",
		"modalita di gioco",
		"Teletrasporto",
		"Teletrasporto",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Tema",
		"Salva Tema",
		"DRP",
		"Salva DRP",
		"Keybinds",

		/*
			Etc
		*/
		//Gamemode names
		"Sopravvivenza",
		"Creativo",
		"Avventura"
	};
	return italian;
}

static Lang getSpanish() {
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
		"NoPacket",
		"Camara gratis",
		"Estrellarse servidor",
		"Coordinates",

		/*
			Settings
		*/
		"Hitbox Anchura",
		"Hitbox Altura",
		"Aceleracion de aire",
		"Velocidad del jugador",
		"Jesus Aumentar",
		"Bhop Aumentar",
		"Modo de juego",
		"Teletransportarse",
		"Teletransportarse",
		"TP Aura: Range",
		"TP Aura: Skips",
		"Tema",
		"Salvar Tema",
		"DRP",
		"Salvar DRP",
		"Keybinds",

		/*
			Etc
		*/
		//Gamemode names
		"Supervivencia",
		"Creativo",
		"Aventuras"
	};
	return spanish;
}