# First-Godot-Project

A small 2D Godot game prototype built with **Godot 4.2 + C#**.

## Game overview

- **Start menu** (`start.tscn`): lets the player start the game or quit.
- **Main world** (`world.tscn`): spawns falling rings over time.
- **Player** (`player.tscn`): can move left/right and jump.
- **Scoring**: collect rings to increase score.
- **Lives/game over**: if rings hit non-player colliders, lives are reduced; at 0 lives the game switches to `death.tscn`.
- **Death menu** (`death.tscn`): restart the game or quit.

## Project structure

- `FirstGodot/project.godot` - Godot project file (main scene is `start.tscn`).
- `FirstGodot/world.cs` - world state and ring spawning logic.
- `FirstGodot/ring.cs` - collision handling, score/lives updates, game-over transition.
- `FirstGodot/PlayerMovement.cs` - player movement and jumping.
- `FirstGodot/start.gd` - start menu button actions.
- `FirstGodot/death.cs` - death menu button actions.

## Requirements

1. **Godot 4.2** with **.NET/C# support**.
2. **.NET SDK** compatible with Godot C# projects (recommended: .NET 8 SDK).

## How to run (Godot Editor)

1. Open Godot 4.2 (the .NET version).
2. Click **Import** and select:  
   `/home/runner/work/First-Godot-Project/First-Godot-Project/FirstGodot/project.godot`
3. Open the imported project.
4. Press **Play** (or `F5`) to run from the configured main scene (`start.tscn`).

## How to run (command line)

From the repository root:

```bash
cd FirstGodot
godot4 --path .
```

If your executable is named differently (for example `godot`), use that command instead.

## Controls

- **Move left/right**: arrow keys (`ui_left` / `ui_right`)
- **Jump**: up arrow (`ui_up`)

## Troubleshooting

- If C# scripts do not compile, verify you are using the **Godot .NET build** (not the standard build).
- If Godot cannot find the .NET SDK, install/update your SDK and restart Godot.
