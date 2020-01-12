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
		//
	break;
	}
}