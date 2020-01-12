#include "languagehandler.h"

char* LanguageHandler::combatMenuItem;
char* LanguageHandler::movementMenuItem;
char* LanguageHandler::miscMenuItem;
char* LanguageHandler::settingsMenuItem;

char* LanguageHandler::hitboxBtn;
char* LanguageHandler::triggerbotBtn;
char* LanguageHandler::criticalsBtn;
char* LanguageHandler::tpauraBtn;

char* LanguageHandler::airjumpBtn;
char* LanguageHandler::airaccBtn;
char* LanguageHandler::noslowdownBtn;
char* LanguageHandler::noknockbackBtn;
char* LanguageHandler::playerspeedBtn;
char* LanguageHandler::nowaterBtn;
char* LanguageHandler::jesusBtn;
char* LanguageHandler::bhopBtn;
char* LanguageHandler::flightBtn;
char* LanguageHandler::stepAssistBtn;


char* LanguageHandler::nowebBtn;
char* LanguageHandler::nofallBtn;
char* LanguageHandler::gamemodeBtn;
char* LanguageHandler::instabreakBtn;
char* LanguageHandler::phaseBtn;
char* LanguageHandler::scaffoldBtn;
char* LanguageHandler::nopacketBtn;
char* LanguageHandler::freecamBtn;
char* LanguageHandler::servercrasherBtn;
char* LanguageHandler::coordinatesBtn;

char* LanguageHandler::hitboxWidthSlider;
char* LanguageHandler::hitboxHeightSlider;
char* LanguageHandler::airaccSlider;
char* LanguageHandler::playerSpeedSlider;
char* LanguageHandler::jesusSlider;
char* LanguageHandler::bhopSlider;
char* LanguageHandler::gamemodeSwitcher;
char* LanguageHandler::teleportText;
char* LanguageHandler::teleportBtn;
char* LanguageHandler::themeText;
char* LanguageHandler::themeSwitcher;
char* LanguageHandler::themeSaverBtn;
char* LanguageHandler::drpText;
char* LanguageHandler::drpSwitcher;
char* LanguageHandler::drpSaverBtn;
char* LanguageHandler::keybindsBtn;

LanguageHandler::LanguageHandler(int switcher) {
	switch (switcher) {
	
	case 0: //English
		
		/* Menu Items */
		LanguageHandler::combatMenuItem = (char*)"Combat";
		LanguageHandler::movementMenuItem = (char*)"Movement";
		LanguageHandler::miscMenuItem = (char*)"Misc";
		LanguageHandler::settingsMenuItem = (char*)"Settings";

		/* Combat */
		LanguageHandler::hitboxBtn = (char*)"Hitbox";
		LanguageHandler::triggerbotBtn = (char*)"Triggerbot";
		LanguageHandler::criticalsBtn = (char*)"Criticals";
		LanguageHandler::tpauraBtn = (char*)"TPAura";

		/* Movement */
		LanguageHandler::airjumpBtn = (char*)"Air Jump";
		LanguageHandler::airaccBtn = (char*)"Air Acceleration";
		LanguageHandler::noslowdownBtn = (char*)"NoSlowDown";
		LanguageHandler::noknockbackBtn = (char*)"NoKnockBack";
		LanguageHandler::playerspeedBtn = (char*)"Player Speed";
		LanguageHandler::nowaterBtn = (char*)"NoWater";
		LanguageHandler::jesusBtn = (char*)"Jesus";
		LanguageHandler::bhopBtn = (char*)"Bunny-Hop";
		LanguageHandler::flightBtn = (char*)"Flight";
		LanguageHandler::stepAssistBtn = (char*)"Step Assist";

		/* Misc */
		LanguageHandler::nowebBtn = (char*)"NoWeb";
		LanguageHandler::nofallBtn = (char*)"Vanilla NoFall";
		LanguageHandler::gamemodeBtn = (char*)"Gamemode";
		LanguageHandler::instabreakBtn = (char*)"Instabreak";
		LanguageHandler::phaseBtn = (char*)"Phase";
		LanguageHandler::scaffoldBtn = (char*)"Scaffold";
		LanguageHandler::nopacketBtn = (char*)"NoPacket";
		LanguageHandler::freecamBtn = (char*)"Freecam";
		LanguageHandler::servercrasherBtn = (char*)"Server Crasher";
		LanguageHandler::coordinatesBtn = (char*)"Coordinates";

		/* Settings */
		LanguageHandler::hitboxWidthSlider = (char*)"Hitbox: Width";
		LanguageHandler::hitboxHeightSlider = (char*)"Hitbox: Height";
		LanguageHandler::airaccSlider = (char*)"Air Acceleration";
		LanguageHandler::playerSpeedSlider = (char*)"Player Speed";
		LanguageHandler::jesusSlider = (char*)"Jesus (Y Boost)";
		LanguageHandler::bhopSlider = (char*)"BHOP (Y Boost)";
		LanguageHandler::gamemodeSwitcher = (char*)"Gamemode";
		LanguageHandler::teleportText = (char*)"Teleport:";
		LanguageHandler::teleportBtn = (char*)"Teleport";
		LanguageHandler::themeText = (char*)"Theme:";
		LanguageHandler::themeSwitcher = (char*)"Theme";
		LanguageHandler::themeSaverBtn = (char*)"Save Theme";
		LanguageHandler::drpText = (char*)"Discord Rich Presence:";
		LanguageHandler::drpSwitcher = (char*)"DRP";
		LanguageHandler::drpSaverBtn = (char*)"Save DRP";
		LanguageHandler::keybindsBtn = (char*)"Keybinds";

	break;
	
	case 1: //Espanol
		
		/* Menu Items */
		LanguageHandler::combatMenuItem = (char*)"Combate";
		LanguageHandler::movementMenuItem = (char*)"Movimiento";
		LanguageHandler::miscMenuItem = (char*)"Misc";
		LanguageHandler::settingsMenuItem = (char*)"Config";

		/* Combat */
		LanguageHandler::hitboxBtn = (char*)"Hitbox";
		LanguageHandler::triggerbotBtn = (char*)"Gatillo";
		LanguageHandler::criticalsBtn = (char*)"Criticos";
		LanguageHandler::tpauraBtn = (char*)"TPAura";

		/* Movement */
		LanguageHandler::airjumpBtn = (char*)"Salto aereo";
		LanguageHandler::airaccBtn = (char*)"Aceleracion de Aire";
		LanguageHandler::noslowdownBtn = (char*)"No Desacelerar";
		LanguageHandler::noknockbackBtn = (char*)"No Bloquear";
		LanguageHandler::playerspeedBtn = (char*)"Velocidad del Jugador";
		LanguageHandler::nowaterBtn = (char*)"NoAgua";
		LanguageHandler::jesusBtn = (char*)"Jesus";
		LanguageHandler::bhopBtn = (char*)"Salto de conejo";
		LanguageHandler::flightBtn = (char*)"Vuelo";
		LanguageHandler::stepAssistBtn = (char*)"El paso";

		/* Misc */
		LanguageHandler::nowebBtn = (char*)"NoTelarana";
		LanguageHandler::nofallBtn = (char*)"VanillaNoCaerse";
		LanguageHandler::gamemodeBtn = (char*)"Modo de juego";
		LanguageHandler::instabreakBtn = (char*)"Instabreak";
		LanguageHandler::phaseBtn = (char*)"Fase";
		LanguageHandler::scaffoldBtn = (char*)"Andamio";
		LanguageHandler::nopacketBtn = (char*)"NoPacket";
		LanguageHandler::freecamBtn = (char*)"Camlibre";
		LanguageHandler::servercrasherBtn = (char*)"Servidor estrellarse";
		LanguageHandler::coordinatesBtn = (char*)"Coordenadas";

		/* Settings */
		LanguageHandler::hitboxWidthSlider = (char*)"Hitbox: Anchura";
		LanguageHandler::hitboxHeightSlider = (char*)"Hitbox: Altura";
		LanguageHandler::airaccSlider = (char*)"Aceleracion de Aire";
		LanguageHandler::playerSpeedSlider = (char*)"Velocidad del Jugador";
		LanguageHandler::jesusSlider = (char*)"Jesus (Y Aumentar)";
		LanguageHandler::bhopSlider = (char*)"Salto de conejo (Y Aumentar)";
		LanguageHandler::gamemodeSwitcher = (char*)"Modo de juego";
		LanguageHandler::teleportText = (char*)"Teletransporte:";
		LanguageHandler::teleportBtn = (char*)"Teletransporte";
		LanguageHandler::themeText = (char*)"Fondo de pantalla:";
		LanguageHandler::themeSwitcher = (char*)"Fondo de pantalla";
		LanguageHandler::themeSaverBtn = (char*)"Guardar fondo de pantalla";
		LanguageHandler::drpText = (char*)"Discord Rich Presence:";
		LanguageHandler::drpSwitcher = (char*)"DRP";
		LanguageHandler::drpSaverBtn = (char*)"Guardar DRP";
		LanguageHandler::keybindsBtn = (char*)"Llaves";

	break;
	}
}