# Enemy Drop Loot

Enemy Drop Loot rewards dungeon combat by letting every monster roll against the current map's loot table. As soon as you board any regular mission map (not the shop, tram or arena), the mod mirrors the dungeon's active loot pool and uses it whenever an enemy dies. Drops respect each map's weighted loot choices, so you'll only see items that could naturally appear in that level.

## Features

- Auto-detects dungeon rooms and ignores the shop/tram/end rooms.
- Builds a live loot pool from the map's own spawn configuration to keep drops lore-friendly.
- Spawns loot next to the corpse using the game's own spawn helpers (navmesh safe).
- Simple preference toggles for enabling the mod, adjusting drop chance, and allowing multi-drop kills.

## Configuration

All options live in `UserData/MelonPreferences.cfg` under the `EnemyDropLoot` section:

- `Enabled` – master toggle (default: `true`).
- `DropChance` – per roll probability between `0` and `1` (default: `0.1` for 10%).
- `MaxDropsPerKill` – number of rolls performed for each kill (default: `1`, clamped 0–100).

Set `DropChance` below `1` (100%) to make drops less frequent, or raise `MaxDropsPerKill` for the chance to spit out multiple scraps from a single monster.
For example, `DropChance = 1` and `MaxDropsPerKill = 5` give an expected 5 drops, while `DropChance = 0.01` and `MaxDropsPerKill = 100` give an expected 1 drop per kill.

## Requirements

- MelonLoader 0.7.1+
- [MimicAPI](https://github.com/NeoMimicry/MimicAPI)

## Installation

1. Install MelonLoader into MIMESIS.
2. Drop `EnemyDropLoot.dll` (and `MimicAPI.dll` if you don't have it yet) into `MIMESIS/Mods`.
3. Launch the game – the mod announces itself in the MelonLoader console.

## Development Notes

- Core logic lives in `Managers/LootPoolManager.cs`.
- `Patches/DungeonRoomPatches.cs` wires the manager up when a dungeon loads/unloads.
- `Patches/VMonsterPatches.cs` injects loot when monsters die.

Feel free to tweak roll logic or extend the manager for rarities, scaling, or additional filters. Contributions are welcome via pull request.
