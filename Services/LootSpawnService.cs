using MelonLoader;
using ReluProtocol;
using ReluProtocol.Enum;
using UnityEngine;

namespace EnemyDropLoot.Services
{
	internal static class LootSpawnService
	{
		private const float DropScatterRadius = 2f;

		internal static bool TrySpawnLoot(VMonster monster, int itemMasterId)
		{
			ItemElement? itemElement = monster.VRoom.GetNewItemElement(itemMasterId, isFake: false);
			if (itemElement == null)
			{
				return false;
			}

			Vector3 spawnPos = monster.PositionVector;
			if (DropScatterRadius > 0f)
			{
				Vector2 offset2D = UnityEngine.Random.insideUnitCircle * DropScatterRadius;
				spawnPos += new Vector3(offset2D.x, 0f, offset2D.y);
			}

			float searchRadius = Mathf.Max(1.5f, DropScatterRadius);
			if (!monster.VRoom.FindNearestPoly(spawnPos, out Vector3 nearestPos, searchRadius))
			{
				nearestPos = spawnPos;
			}

			PosWithRot dropPos = monster.Position.Clone();
			dropPos.x = nearestPos.x;
			dropPos.y = nearestPos.y;
			dropPos.z = nearestPos.z;

			int spawnResult = monster.VRoom.SpawnLootingObject(itemElement, dropPos, monster.IsIndoor, ReasonOfSpawn.ActorDying);
			if (spawnResult == 0)
			{
				MelonLogger.Warning($"EnemyDropLoot: Failed to spawn loot item {itemMasterId} for monster {monster.MasterID}.");
				return false;
			}

			return true;
		}
	}
}

