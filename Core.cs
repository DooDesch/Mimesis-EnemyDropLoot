using Boilerplate.Config;
using MelonLoader;

[assembly: MelonInfo(typeof(Boilerplate.Core), "Boilerplate", "1.0.0", "DooDesch", null)]
[assembly: MelonGame("ReLUGames", "MIMESIS")]
// Uncomment if using MimicAPI
// [assembly: MelonOptionalDependencies("MimicAPI")]

namespace Boilerplate
{
	public sealed class Core : MelonMod
	{
		public override void OnInitializeMelon()
		{
			BoilerplatePreferences.Initialize();
			HarmonyInstance.PatchAll();
			MelonLogger.Msg("Boilerplate initialized. Enabled={0}", BoilerplatePreferences.Enabled);
		}
	}
}

