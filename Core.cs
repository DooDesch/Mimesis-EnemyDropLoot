using EnemyDropLoot.Config;
using MelonLoader;

[assembly: MelonInfo(typeof(EnemyDropLoot.Core), "EnemyDropLoot", "1.0.0", "DooDesch", null)]
[assembly: MelonGame("ReLUGames", "MIMESIS")]
[assembly: MelonOptionalDependencies("MimicAPI")]

namespace EnemyDropLoot
{
	public sealed class Core : MelonMod
	{
		public override void OnInitializeMelon()
		{
			EnemyDropLootPreferences.Initialize();
			HarmonyInstance.PatchAll();
			MelonLogger.Msg(
				$"EnemyDropLoot initialized. Enabled={EnemyDropLootPreferences.Enabled}, DropChance={EnemyDropLootPreferences.DropChance:P0}, MaxDropsPerKill={EnemyDropLootPreferences.MaxDropsPerKill}");
		}
	}
}

