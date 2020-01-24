#pragma once
static struct Lang {
	/*
		Meta
	*/
	const char* Name;
	const char* Language;
	const char* LanguageSave;

	/*
		Categories
	*/
	const char* Combat;
	const char* Movement;
	const char* Misc;
	const char* Settings;
	const char* ClickUI;
	const char* Back;

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
	const char* NoClip;
	const char* StepAssist;
	const char* AutoSprint;

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
	const char* ClickTP;
	const char* Esp;

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
	const char* GuiScale;

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
		"Save Language",

		/*
			Categories
		*/
		"Combat",
		"Movement",
		"Misc",
		"Settings",
		"ClickUI",
		"Back",

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
		"NoClip",
		"Step Assist",
		"AutoSprint",

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
		"ClickTP",
		"Esp",

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
		"Gui Scale",

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
		"Salva Linguaggio",

		/*
			Categories
		*/
		"Combattimento",
		"Movimento",
		"Varie",
		"Impostaz.",
		"ClickUI",
		"Torna",

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
		"NoClip",
		"Step Assist",
		"AutomaticoSprint",

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
		"ClickTP",
		"Esp",

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
		"Gui Scale",

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
		"Salvar Idioma",

		/*
			Categories
		*/
		"Combate",
		"Movimiento",
		"Miscelaneo",
		"Config.",
		"ClickUI",
		"Back",

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
		"NoClip",
		"Step Assist",
		"AutomaticoSprint",

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
		"ClickTP",
		"Esp",

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
		"Gui Scale",

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