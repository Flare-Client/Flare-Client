#pragma once
#include "LittleHacker.h"

class Player {
public:
	static uintptr_t LocalPlayer();

	static unsigned int dimensionID,
		airJump,
		onGround,
		isFlying,
		isInWater,
		currentGamemode,
		viewCreativeItems,
		airAcceleration,
		hitboxWidth,
		hitboxHeight,
		isFalling,
		velocityX,
		velocityY,
		velocityZ,
		currentX1,
		currentX2,
		currentY1,
		currentY2,
		currentZ1,
		currentZ2,
		currentUsername,
		currentPitch,
		currentYaw,
		stepAssist;
};

class pointers {
public:
	static uintptr_t UI();
	static uintptr_t entityFacing();
	static uintptr_t attackSwing();
	static uintptr_t playerSpeed();
	static uintptr_t canPlaceBlock();
	static uintptr_t blockCoordX();
	static uintptr_t blockCoordY();
	static uintptr_t blockCoordZ();
	static uintptr_t serverCrashPacket();
};