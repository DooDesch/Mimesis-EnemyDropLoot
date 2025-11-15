using System;
using System.Collections.Generic;
using EnemyDropLoot.Config;
using MelonLoader;
using MimicAPI.GameAPI;
using ReluProtocol;
using ReluProtocol.Enum;
using UnityEngine;

namespace EnemyDropLoot.Managers
{
	internal static class LootPoolManager
	{
		private static readonly List<RandomSpawnedItemActorData> LootSources = new();
		private static readonly List<int> FallbackItemIds = new();

		private static IVroom _activeRoom = null!;
		private static bool _hasActiveRoom;

		internal static void Reset()
		{
			LootSources.Clear();
			FallbackItemIds.Clear();
			_hasActiveRoom = false;
		}

		internal static void ConfigureForDungeon(DungeonRoom room)
		{
			Reset();
			_activeRoom = room;
			_hasActiveRoom = true;

			try
			{
				var spawnDict = ReflectionHelper.GetFieldValue<Dictionary<int, SpawnedActorData>>(room, "_spawnedActorDatas");
				if (spawnDict == null)
				{
					MelonLogger.Warning("EnemyDropLoot: Unable to fetch spawn data for current dungeon.");
					return;
				}

				foreach (var data in spawnDict.Values)
				{
					if (data == null || data.MarkerType != MapMarkerType.LootingObject)
					{
						continue;
					}

					if (data is RandomSpawnedItemActorData randomData)
					{
						LootSources.Add(randomData);
						foreach (var candidate in randomData.Candidates)
						{
							if (!FallbackItemIds.Contains(candidate.Key))
							{
								FallbackItemIds.Add(candidate.Key);
							}
						}
					}
				}

				MelonLogger.Msg("EnemyDropLoot: Loaded {0} loot spawn bundles with {1} unique items.", LootSources.Count, FallbackItemIds.Count);
			}
			catch (Exception ex)
			{
				MelonLogger.Error($"EnemyDropLoot: Failed to read dungeon loot pool. {ex}");
			}
		}

		internal static void TryHandleMonsterDeath(VMonster monster)
		{
			if (!EnemyDropLootPreferences.Enabled || LootSources.Count == 0)
			{
				return;
			}

			if (!_hasActiveRoom || monster.VRoom != _activeRoom)
			{
				return;
			}

			int dropCount = EnemyDropLootPreferences.RollDropCount();
			if (dropCount <= 0)
			{
				return;
			}

			for (int i = 0; i < dropCount; i++)
			{
				TrySpawnLoot(monster);
			}
		}

		private static void TrySpawnLoot(VMonster monster)
		{
			if (!TryPickItem(out int itemMasterId))
			{
				return;
			}

			ItemElement? itemElement = monster.VRoom.GetNewItemElement(itemMasterId, isFake: false);
			if (itemElement == null)
			{
				// Item info might be missing. Nothing we can do.
				return;
			}

			Vector3 spawnPos = monster.PositionVector;
			if (!monster.VRoom.FindNearestPoly(spawnPos, out Vector3 nearestPos, 2f))
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
			}
		}

		private static bool TryPickItem(out int itemMasterId)
		{
			itemMasterId = 0;

			if (LootSources.Count == 0)
			{
				return false;
			}

			RandomSpawnedItemActorData source = LootSources[UnityEngine.Random.Range(0, LootSources.Count)];
			int pickedItem = source.GetPickedItemValue();
			if (pickedItem == 0 && FallbackItemIds.Count > 0)
			{
				pickedItem = FallbackItemIds[UnityEngine.Random.Range(0, FallbackItemIds.Count)];
			}

			if (pickedItem == 0)
			{
				return false;
			}

			itemMasterId = pickedItem;
			return true;
		}
	}
}

