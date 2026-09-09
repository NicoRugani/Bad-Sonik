# Bad Sonik

## Overview
Bad Sonik is a 2D infinite runner built in Godot using C#. Players collect falling rings to increase their score, catching as many as they can without letting them hit the ground. Miss too many and it's game over, so you gotta go fast ;). 

The project was originally developed as a side project when I was teaching myself Godot. The goal was to teach myself how to use Godot while incorporating the C# skills I was learning in class at the time to create a game I could show off at our end of the year party. It has now since been refactored to improve the code quality and preserve this step (gem xD) in my programming journey. PLEASE ENJOY! :)

## SneakPeak
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
1. Install Godot 4.7 .NET and the .NET 6 SDK.
2. Clone this repository.
3. Open Godot and import 'FirstGodot/Project.godot'.
4. Press **F5** or the arrow button in the top right to run the project 


## Future Improvements
- Persistent high score system
- Difficulty scaling over time
- Pause menu
- Particle effects for feedback
