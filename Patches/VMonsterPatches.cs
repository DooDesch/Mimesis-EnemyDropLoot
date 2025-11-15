using EnemyDropLoot.Managers;
using HarmonyLib;

namespace EnemyDropLoot.Patches
{
	[HarmonyPatch(typeof(VMonster), nameof(VMonster.OnDead))]
	internal static class VMonsterOnDeadPatch
	{
		private static void Prefix(VMonster __instance)
		{
			LootPoolManager.TryHandleMonsterDeath(__instance);
		}
	}
}

