# MIMESIS - EnemyDropLoot

Enemy Drop Loot rewards dungeon combat by letting every monster roll against the current map's loot table. As soon as you board any regular mission map (not the shop, tram or arena), the mod mirrors the dungeon's active loot pool and uses it whenever an enemy dies. Drops respect each map's weighted loot choices, so you'll only see items that could naturally appear in that level.

![Version](https://img.shields.io/badge/version-1.0.2-blue)
![Game](https://img.shields.io/badge/game-MIMESIS-purple)
![MelonLoader](https://img.shields.io/badge/MelonLoader-0.7.1+-green)
![Status](https://img.shields.io/badge/status-working-brightgreen)

---

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Configuration](#configuration)
- [How It Works](#how-it-works)
- [Development](#development)
- [License](#license)

---

## Features

- **Auto-detects dungeon rooms** and ignores the shop/tram/end rooms
- **Builds a live loot pool** from the map's own spawn configuration to keep drops lore-friendly
- **Spawns loot next to the corpse** using the game's own spawn helpers (navmesh safe)
- **Simple preference toggles** for enabling the mod, adjusting drop chance, and allowing multi-drop kills

---

## Requirements

| Component | Version |
|-----------|---------|
| **Mimesis** | Latest Steam build |
| **MelonLoader** | 0.7.1 or higher |
| **MimicAPI** | [Required](https://github.com/NeoMimicry/MimicAPI) |

---

## Installation

1. Download the latest `EnemyDropLoot.dll` release from the [releases page](../../releases)
2. Ensure you have [MimicAPI](https://github.com/NeoMimicry/MimicAPI) installed
3. Place the file into your Mimesis mods directory:
   ```
   MIMESIS/MelonLoader/Mods/EnemyDropLoot.dll
   ```
4. Launch the game – the mod announces itself in the MelonLoader console

> **Note:** The configuration file will be created automatically on first launch at `UserData/MelonPreferences.cfg`

---

## Configuration

All options live in `UserData/MelonPreferences.cfg` under the `EnemyDropLoot` section.

### Available Options

| Option | Description | Default | Range |
|--------|-------------|---------|-------|
| `Enabled` | Master toggle | `true` | `true` / `false` |
| `DropChance` | Per roll probability | `0.1` (10%) | `0` - `1` |
| `MaxDropsPerKill` | Number of rolls performed for each kill | `1` | `0` - `100` |

### Configuration Examples

| Scenario | `DropChance` | `MaxDropsPerKill` | Expected Result |
|----------|--------------|-------------------|-----------------|
| Guaranteed multiple drops | `1.0` | `5` | ~5 drops per kill |
| Rare but possible multiple | `0.01` | `100` | ~1 drop per kill |
| Standard 10% chance | `0.1` | `1` | 10% chance per kill |

> **Note:** Set `DropChance` below `1` (100%) to make drops less frequent, or raise `MaxDropsPerKill` for the chance to spit out multiple scraps from a single monster.

---

## How It Works

Enemy Drop Loot integrates with the game's dungeon system to provide contextual loot drops:

1. **Detects dungeon rooms** when you enter a regular mission map
2. **Mirrors the active loot pool** from the map's spawn configuration
3. **Intercepts enemy death events** to trigger loot rolls
4. **Spawns loot safely** using the game's navmesh-aware spawn helpers

The mod ensures that:
- Only items that could naturally appear in that level will drop
- Loot respects each map's weighted loot choices
- Drops are placed safely near the corpse using proper spawn mechanics

---

## Development

### Project Structure

```
EnemyDropLoot/
├── Core.cs                          # Main entry point
├── Managers/
│   └── LootPoolManager.cs           # Core loot pool logic
└── Patches/
    ├── DungeonRoomPatches.cs        # Wires manager on dungeon load/unload
    └── VMonsterPatches.cs           # Injects loot when monsters die
```

### Key Files

- **`Core.cs`** - Core entry point and mod initialization
- **`Managers/LootPoolManager.cs`** - Core logic for managing loot pools and drops
- **`Patches/DungeonRoomPatches.cs`** - Handles dungeon room detection and loot pool setup
- **`Patches/VMonsterPatches.cs`** - Intercepts monster death events to trigger loot drops

### Extending the Mod

Feel free to tweak roll logic or extend the manager for:
- Rarity-based drops
- Scaling with difficulty
- Additional filters (enemy type, room type, etc.)

Contributions are welcome via pull request.

---

## License

This project is provided as-is under the **MIT License**. Contributions are welcome via pull requests.

---
