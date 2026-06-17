# Changelog

All notable changes to EnemyDropLoot are documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/), and this
project adheres to Semantic Versioning.

## [1.0.5] - 2026-06-17

### Changed
- Started maintaining a full changelog that is now published on GitHub, Thunderstore
  and Nexus. No gameplay changes compared to 1.0.4.

## [1.0.4] - 2026-06-16

### Changed
- Updated the MimicAPI dependency to 0.3.0 for full compatibility with the Mimesis
  0.3.0 game build.
- Rewrote the README to the current standard with accurate configuration, dependency
  and badge information.

## [1.0.3] - 2026-06-15

### Fixed
- Compatibility with the Mimesis 0.3.0 game update and MelonLoader 0.7.3. Enemies drop
  loot again on the new game build.

### Changed
- Reorganised the README with a table of contents, clearer feature descriptions and
  step-by-step installation and configuration guidance, including `DropChance` and
  `MaxDropsPerKill` examples.

## [1.0.2] - 2025-11-16

### Added
- Declared MimicAPI as a dependency so the mod resolves its runtime requirement
  automatically.

## [1.0.1] - 2025-11-16

### Changed
- Refreshed the README with a clearer mod description, installation steps and
  configuration options.

## [1.0.0] - 2025-11-16

### Added
- Initial release. Dungeon enemies now drop loot that matches the active map's spawn
  pool when killed.
- `DropChance` and `MaxDropsPerKill` preferences to tune how often and how much loot
  drops.
