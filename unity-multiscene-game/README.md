# Unity Multiscene Learning Game

A 2D level-based Unity course project built with C#. The game uses multiple scenes themed around programming and mathematics topics, with interactive level mechanics, scoring, achievements, timers, and audio/settings management.

## Highlights

- Multi-scene level progression using Unity `SceneManager`
- 2D player movement, jumping, collision, traps, enemies, and moving platforms
- Score tracking across levels with persistent manager objects
- Timed gameplay and level-completion logic
- Achievement and grade/result UI flows
- Drag-and-drop and object interaction mechanics
- BGM / sound-effect control and persistent settings
- UI built with Unity UI and TextMesh Pro

## Tech Stack

- **Engine:** Unity 2022.3.26f1
- **Language:** C#
- **Core Unity features:** 2D Physics, Scene Management, Animator, UI, TextMesh Pro, Audio

## Main Project Structure

```text
Assets/
├── Scenes/          # Game scenes and level flow
├── Scripts/         # Gameplay, UI, score, audio, timer, and interaction logic
├── prefab/          # Reusable game objects
├── image/           # Visual assets used by the course project
├── Audio/           # Audio assets
└── Resources/       # Runtime-loaded resources
Packages/            # Unity package dependencies
ProjectSettings/     # Unity project configuration
```

## Example Systems

Some of the central scripts include:

- `playerControler.cs` — 2D player movement and jumping
- `ScoreManager.cs` / `LevelManager.cs` — cross-level score tracking
- `Timer.cs` — countdown and level-completion flow
- `AudioManager.cs` — persistent BGM and sound-effect management
- `AchievementsManager.cs` — achievement UI handling
- `DragObject.cs` and related scripts — interactive drag-and-drop mechanics
- `ChangeScene.cs` and scene-controller scripts — scene transitions and progression

## Running the Project

1. Install **Unity 2022.3.26f1** (or a compatible 2022.3 LTS release).
2. Clone or download this repository.
3. Open the project folder in Unity Hub.
4. Open `Assets/Scenes/Start.unity` or use the scenes configured in **Build Settings**.
5. Press **Play** in the Unity Editor.

## Repository Cleanup

This portfolio copy keeps the Unity source project while excluding generated cache/build folders. The unused third-party **Flower** sample package and TextMesh Pro example/demo content were removed so the repository focuses on the actual course project.

## Notes on Assets

This repository originated from a university programming course project. Some visual, font, or audio assets may have separate third-party licenses or attribution requirements. Before redistributing those assets outside a portfolio/educational context, verify their original licenses. No blanket open-source license is granted for bundled media assets.
