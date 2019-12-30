#pragma once
#include "LittleHacker.h"

class Player {
public:
	static uintptr_t LocalPlayer();

	static unsigned int airJump,
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
		currentYaw;
};

class pointers {
public:
	static uintptr_t entityFacing();
	static uintptr_t attackSwing();
	static uintptr_t playerSpeed();
};