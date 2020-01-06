#include "LocalPlayer.h"

uintptr_t Player::LocalPlayer() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x10, 0x40, 0x0 });
}

uintptr_t pointers::entityFacing() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x02FEE4B0, { 0xA8, 0x20, 0x38, 0x728, 0x0, 0x870 });
}

uintptr_t pointers::attackSwing() {
	return mem::moduleBase + 0x102460E;
}

uintptr_t pointers::playerSpeed() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x03016010, { 0x30, 0xF0, 0x410, 0x18, 0xE0, 0x8, 0x9C });
}

uintptr_t pointers::canPlaceBlock() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x03016010, { 0x30, 0x88, 0x30, 0x6E8, 0x0, 0x850 });
}

uintptr_t pointers::blockCoordX() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x03016010, { 0x30, 0x88, 0x30, 0x6E8, 0x0, 0x858 });
}

uintptr_t pointers::blockCoordY() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x03016010, { 0x30, 0x88, 0x30, 0x6E8, 0x0, 0x85C });
}

uintptr_t pointers::blockCoordZ() {
	return mem::FindAddr(mem::hProcess, mem::moduleBase + 0x03016010, { 0x30, 0x88, 0x30, 0x6E8, 0x0, 0x860 });
}

unsigned int Player::airJump = 0x178;
unsigned int Player::onGround = 0x17C;
unsigned int Player::isFlying = 0xA88;
unsigned int Player::isInWater = 0x23D;
unsigned int Player::currentGamemode = 0x1D9C;
unsigned int Player::viewCreativeItems = 0xAA0;
unsigned int Player::airAcceleration = 0x8A4;
unsigned int Player::hitboxWidth = 0x44C;
unsigned int Player::hitboxHeight = 0x450;
unsigned int Player::isFalling = 0x194;
unsigned int Player::velocityX = 0x46C;
unsigned int Player::velocityY = 0x470;
unsigned int Player::velocityZ = 0x474;
unsigned int Player::currentX1 = 0x430;
unsigned int Player::currentX2 = 0x43C;
unsigned int Player::currentY1 = 0x434;
unsigned int Player::currentY2 = 0x440;
unsigned int Player::currentZ1 = 0x438;
unsigned int Player::currentZ2 = 0x444;
unsigned int Player::currentUsername = 0x9E8;
unsigned int Player::currentPitch = 0xF0;
unsigned int Player::currentYaw = 0xF4;
unsigned int Player::stepAssist = 0x220;
unsigned int Player::dimensionID = 0xBC;