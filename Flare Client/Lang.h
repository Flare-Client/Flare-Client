#pragma once
struct Lang {
	const char* Combat;
	const char* Movement;
	const char* Misc;
	const char* Settings;
};

Lang getEnglish() {
	Lang english = {
		"Combat",
		"Movement",
		"Misc",
		"Settings"
	};
	return english;
}

Lang getItalian() {
	Lang italian = {
		"Combattimento",
		"Movimento",
		"Varie",
		"Impostaz."
	};
	return italian;
}