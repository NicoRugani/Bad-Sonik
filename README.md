# Bad Sonik

## Overview
Bad Sonik is a 2D Godot infinite runner prototype where the player dodges failure by collecting falling rings while managing limited lives.

##SneakPeak
<img width="585" height="338" alt="Screenshot 2026-09-09 at 4 35 04 PM" src="https://github.com/user-attachments/assets/1ce9158d-f557-4522-946e-fd7a26d9cb34" />

<img width="585" height="338" alt="Screenshot 2026-09-09 at 4 35 19 PM" src="https://github.com/user-attachments/assets/48081414-4928-4803-947e-060f2776f692" />


## Features
- Infinite runner style gameplay loop
- Ring collection and score tracking
- Lives system with game-over transition
- Start and death menu screens

## Controls
- Move left: Left Arrow
- Move right: Right Arrow
- Jump: Up Arrow

## Technologies
- Godot 4.2 (.NET)
- C#
- .NET 6 SDK

## Project Structure
```text
Bad-Sonik/
├── FirstGodot/
│   ├── Assets/
│   │   ├── Audio/
│   │   ├── Fonts/
│   │   └── Sprites/
│   ├── Scenes/
│   ├── Scripts/
│   ├── UI/
│   ├── docs/
│   ├── BadSonik.csproj
│   ├── BadSonik.sln
│   └── project.godot
└── README.md
```

## Running the Project
1. Install Godot 4.2 .NET and the .NET 6 SDK.
2. Open Godot and import `/home/runner/work/Bad-Sonik/Bad-Sonik/FirstGodot/project.godot`.
3. Run the project (`F5`) from the editor.

Optional command line run:
```bash
cd /home/runner/work/Bad-Sonik/Bad-Sonik/FirstGodot
godot4 --path .
```

## Future Improvements
- Persistent high score system
- Difficulty scaling over time
- Pause menu
- Particle effects for feedback
