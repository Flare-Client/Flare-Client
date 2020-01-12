#pragma once

class LanguageHandler {
public:

	LanguageHandler(int switcher);

	static char* combatMenuItem;
	static char* movementMenuItem;
	static char* miscMenuItem;
	static char* settingsMenuItem;

	/* Combat */
	static char* hitboxBtn;
	static char* triggerbotBtn;
	static char* criticalsBtn;
	static char* tpauraBtn;

	/* Movement */
	static char* airjumpBtn;
	static char* airaccBtn;
	static char* noslowdownBtn;
	static char* noknockbackBtn;
	static char* playerspeedBtn;
	static char* nowaterBtn;
	static char* jesusBtn;
	static char* bhopBtn;
	static char* flightBtn;
	static char* stepAssistBtn;

	/* Misc */
	static char* nowebBtn;
	static char* nofallBtn;
	static char* gamemodeBtn;
	static char* instabreakBtn;
	static char* phaseBtn;
	static char* scaffoldBtn;
	static char* nopacketBtn;
	static char* freecamBtn;
	static char* servercrasherBtn;
	static char* coordinatesBtn;

	/* Settings */
	static char* hitboxWidthSlider;
	static char* hitboxHeightSlider;
	static char* airaccSlider;
	static char* playerSpeedSlider;
	static char* jesusSlider;
	static char* bhopSlider;
	static char* gamemodeSwitcher;
	static char* teleportText;
	static char* teleportBtn;
	static char* themeText;
	static char* themeSwitcher;
	static char* themeSaverBtn;
	static char* drpText;
	static char* drpSwitcher;
	static char* drpSaverBtn;
	static char* keybindsBtn;
};

