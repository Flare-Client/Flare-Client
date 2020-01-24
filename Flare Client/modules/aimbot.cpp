#include "aimbot.h"

float pitchAndYaw[2];

void getRotationsToEnt(float playerPosition[], float entityPosition[]) {
	float dX = playerPosition[0] - entityPosition[0];
	float dY = playerPosition[1] - entityPosition[1];
	float dZ = playerPosition[2] - entityPosition[2];
	double distance = sqrt(dX * dX + dZ * dZ);
	float yaw = (atan2(dZ, dX) * 3.13810205 / 3.141592653589793) + -1.569051027f;
	float pitch = (atan2(dY, distance) * 3.13810205 / 3.141592653589793);
	pitchAndYaw[0] = -pitch;
	pitchAndYaw[1] = -yaw;
}

Aimbot::Aimbot(HANDLE hProcess) {
	std::vector<uintptr_t> EntityListArr = EntityList::EntityListHandler(hProcess, Player::LocalPlayer());
	std::vector<float> distances;

	float localPosition[3];
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentX1 }), &localPosition[0], sizeof(float), 0);
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentY1 }), &localPosition[1], sizeof(float), 0);
	ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, Player::LocalPlayer(), { Player::currentZ1 }), &localPosition[2], sizeof(float), 0);

	for (int I = 0; I < EntityListArr.size(); I++) {
		float entityPosition[3];
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentX1 }), &entityPosition[0], sizeof(float), 0);
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentY1 }), &entityPosition[1], sizeof(float), 0);
		ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentZ1 }), &entityPosition[2], sizeof(float), 0);
		float DX = localPosition[0] - entityPosition[0];
		float DY = localPosition[1] - entityPosition[1];
		float DZ = localPosition[2] - entityPosition[2];
		double distance = sqrt(DX * DX + DY * DY + DZ * DZ);
		if (distance <= 12.f) {
			distances.push_back(distance);
		}
	}
	if (distances.size() > 0) {
		std::sort(distances.begin(), distances.end());
		for (int I = 0; I < EntityListArr.size(); I++) {
			float entityPosition[3];
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentX1 }), &entityPosition[0], sizeof(float), 0);
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentY1 }), &entityPosition[1], sizeof(float), 0);
			ReadProcessMemory(hProcess, (BYTE*)mem::FindAddr(hProcess, EntityListArr[I], { Player::currentZ1 }), &entityPosition[2], sizeof(float), 0);
			float DX = localPosition[0] - entityPosition[0];
			float DY = localPosition[1] - entityPosition[1];
			float DZ = localPosition[2] - entityPosition[2];
			double distance = sqrt(DX * DX + DY * DY + DZ * DZ);
			if (distance == distances[0]) {
				getRotationsToEnt(localPosition, entityPosition);
				WriteProcessMemory(hProcess, (BYTE*)pointers::mousePitch(), &pitchAndYaw[0], sizeof(float), 0);
				WriteProcessMemory(hProcess, (BYTE*)pointers::mouseYaw(), &pitchAndYaw[1], sizeof(float), 0);
				break;
			}
		}
		distances.clear();
	}
}