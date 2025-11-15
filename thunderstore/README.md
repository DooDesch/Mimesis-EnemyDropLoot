# Enemy Drop Loot

Adds loot drops to dungeon enemies by mirroring the current map's loot pool. Monsters no longer feel pointless – every kill can spit out credits, scrap, consumables, or whatever that level normally spawns on the ground.

## Features

- Auto-detects real missions (ignores shop, tram, arena).
- Builds a loot pool straight from the dungeon's spawn table so drops stay lore-friendly.
- Uses the game's own spawn helpers to place loot safely on the navmesh.
- Preference sliders for drop chance and number of rolls per kill.

## Configuration

All options are under `EnemyDropLoot` in `UserData/MelonPreferences.cfg`:

- `Enabled`
- `DropChance` (0–1)
- `MaxDropsPerKill`

## Installation

1. Install MelonLoader 0.7.1+.
2. Copy `EnemyDropLoot.dll` **and** `MimicAPI.dll` into `MIMESIS/Mods`.
3. Launch the game via MelonLoader.

Enjoy actually getting rewarded for taking risks in dungeons!

