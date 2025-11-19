# MIMESIS - EnemyDropLoot

Reward dungeon combat by letting enemies drop the same loot that would spawn naturally in the current mission.

EnemyDropLoot inspects the map's spawn table, mirrors it into an on-kill pool, and uses the game's own helpers to place rewards safely on the navmesh. Every fight now feeds progression instead of just draining resources.

![Version](https://img.shields.io/badge/version-1.0.2-blue)
![Game](https://img.shields.io/badge/game-MIMESIS-purple)
![MelonLoader](https://img.shields.io/badge/MelonLoader-0.7.1+-green)
![Status](https://img.shields.io/badge/status-working-brightgreen)

## Features

- Detects real missions automatically (shop, tram, arena remain untouched)
- Mirrors the active dungeon's spawn table so drops stay lore-friendly
- Places loot with the native spawn helpers for reliable positions
- Configurable drop chance and rolls per enemy in MelonPreferences

## Installation

1. Install the mod via Thunderstore Mod Manager or manually.
2. Ensure MelonLoader 0.7.1+ is present in your game folder.
3. Copy `EnemyDropLoot.dll` **and** `MimicAPI.dll` into `MIMESIS/Mods` (or let your manager do it).
4. Launch the game once so the config section is generated.

## Configuration

The mod adds an `EnemyDropLoot` block to `UserData/MelonPreferences.cfg`:

- `Enabled` — master toggle (default: `true`)
- `DropChance` — probability per kill, 0–1 (default: `0.1`)
- `MaxDropsPerKill` — rolls granted for each enemy (default: `1`)

Fine-tune the values to match how generous you want dungeons to feel, then enjoy actually getting rewarded for taking risks.

