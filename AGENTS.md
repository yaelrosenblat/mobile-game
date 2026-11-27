# Little Grocery Shop

## Project Overview
Little Grocery Shop is a 2D supermarket simulation game for Android devices, designed for portrait orientation.

## Project Structure
- `Assets/Scripts/Game/` — Gameplay systems, UI, customer spawning, pooling, and level management.
- `Assets/Scripts/Logic/` — Customer movement and supporting gameplay logic. These scripts compile into the Game assembly.
- `Assets/Scripts/Service/` — Service interfaces and implementations.
- `Assets/Prefab/` — Reusable game prefabs.
- `Assets/Scenes/` — Unity scenes, including Bootstrap and Home.

## Architecture
The project uses two assemblies:
- **Game** — Contains gameplay and logic scripts. References Services.
- **Services** — Contains service interfaces and implementations. Must never reference Game.

Bootstrap is the entry point. It initializes services before loading the Home scene.

## Services
- `ISaveService` — Provides integer save/load operations.
- `ISettingsService` — Provides persistent settings, including the SoundOn setting.
- `PlayerPrefsSaveService` and `PlayerPrefsSettingsService` — Unity PlayerPrefs-based implementations.
- Gameplay scripts access services through the static `Services` class. Gameplay code must not access PlayerPrefs directly.

## Coding Rules
- Initialize services in Bootstrap before loading Home.
- Keep service interfaces independent of gameplay code.
- Do not introduce circular assembly references.
- Keep the Unity Console free of errors.
- Preserve Android portrait compatibility.
- Use descriptive class and method names.
- Avoid duplicate scripts and obsolete class names.