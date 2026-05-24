# IdentiCard CC106

IdentiCard CC106 is a Unity augmented reality identity-card experience built with Vuforia Engine. The project recognizes four custom ID card image targets and displays a themed AR profile scene for each character, including 3D character models, stylized hologram-style card frames, UI panels, motion effects, particle effects, and voice playback.

![IdentiCard AR scene preview](Assets/image.png)

## Project Overview

This project demonstrates marker-based AR for interactive student identity cards. When a supported card is detected through the device camera, the matching AR content is shown on top of the physical marker. Each profile scene can include a character model, card artwork, animated UI, audio, and linked buttons.

The project is designed as a coursework AR prototype for CC106 and uses Unity 6 with the Universal Render Pipeline.

## Features

- Vuforia image-target tracking for four custom IdentiCard markers.
- Character-specific AR profile displays for Catherine, Eliza, Ashlee, and Xander.
- Imported GLB character models and 2D profile/card assets.
- Voice message playback when a tracked target appears.
- Animated AR presentation effects:
  - pop-in spawn animation
  - floating motion
  - pulse scaling
  - model rotation
  - UI fade-in
  - optional particle burst
- Button helper for opening external URLs from Unity UI.
- URP-based rendering setup for modern Unity projects.

## Technology Stack

- Unity `6000.3.6f1`
- Vuforia Engine `11.4.4`
- Universal Render Pipeline `17.3.0`
- Unity Input System
- TextMesh Pro
- glTFast for GLB model support

## Main Assets

| Area | Path |
| --- | --- |
| Main project scene | `Assets/Scenes/IdentiCard_MainScene.unity` |
| Vuforia target database | `Assets/StreamingAssets/Vuforia/IdentiCard4CardsDB.xml` |
| Card images and character assets | `Assets/Resources/` |
| Custom scripts | `Assets/Scripts/` |
| Preview screenshot | `Assets/image.png` |
| Vuforia target textures | `Assets/Editor/Vuforia/ImageTargetTextures/IdentiCard4CardsDB/` |

## Supported Image Targets

The Vuforia database contains these four image targets:

| Target Name | Character |
| --- | --- |
| `card_01_catherine` | Catherine |
| `card_02_eliza` | Eliza |
| `card_03_ashlee` | Ashlee |
| `card_04_xander` | Xander |

Each target uses a `0.09 x 0.135` meter physical size in the Vuforia database.

## Scripts

| Script | Purpose |
| --- | --- |
| `ARTargetController.cs` | Detects Vuforia tracking status, shows/hides AR content, triggers spawn effects, particles, UI fade, and voice playback. |
| `SpawnPopEffect.cs` | Animates AR content from a small scale to full size when spawned. |
| `UIFadeInEffect.cs` | Fades UI elements in through a `CanvasGroup`. |
| `FloatingEffect.cs` | Adds subtle vertical floating movement. |
| `PulseEffect.cs` | Adds pulsing scale animation. |
| `RotateModel.cs` | Slowly rotates a model around the Y axis. |
| `OpenURLButton.cs` | Opens a configured URL from a UI button. |

## Getting Started

### Requirements

Install the following before opening the project:

- Unity Hub
- Unity Editor `6000.3.6f1` or a compatible Unity 6 version
- Android Build Support if building for Android
- A webcam or Android device camera for AR testing

### Open the Project

1. Open Unity Hub.
2. Select **Add project from disk**.
3. Choose this folder:

   ```text
   IdentiCard_CC106
   ```

4. Open the project with Unity `6000.3.6f1`.
5. Allow Unity to restore packages from `Packages/manifest.json`.

### Open the Main Scene

Open:

```text
Assets/Scenes/IdentiCard_MainScene.unity
```

The repository also contains sample Vuforia/Unity scenes. For this project, use `IdentiCard_MainScene.unity` as the main working scene.

## Running in the Editor

1. Open `Assets/Scenes/IdentiCard_MainScene.unity`.
2. Make sure the Vuforia configuration is available at `Assets/Resources/VuforiaConfiguration.asset`.
3. Connect or enable a camera.
4. Press **Play** in Unity.
5. Show one of the supported IdentiCard image targets to the camera.

When a target is tracked, the assigned AR content should appear and animate above the card.

## Building for Android

1. Open **File > Build Profiles**.
2. Select **Android**.
3. Install Android Build Support if Unity prompts for it.
4. Add `Assets/Scenes/IdentiCard_MainScene.unity` to the scene list.
5. Configure player settings:
   - Enable camera permission support.
   - Set the correct package name.
   - Confirm orientation and resolution settings.
6. Build and run on an Android device with a working camera.

## Project Structure

```text
IdentiCard_CC106/
+-- Assets/
|   +-- Scenes/
|   |   +-- IdentiCard_MainScene.unity
|   +-- Scripts/
|   +-- Resources/
|   +-- StreamingAssets/
|   |   +-- Vuforia/
|   +-- Materials/
|   +-- image.png
+-- Packages/
|   +-- manifest.json
+-- ProjectSettings/
+-- README.md
```

## Notes

- `Assets/image.png` is used as the README preview image.
- Vuforia Engine is included through the local package archive `Packages/com.ptc.vuforia.engine-11.4.4.tgz`.
- The current build settings reference a Vuforia sample scene. Before making a final build, confirm that `Assets/Scenes/IdentiCard_MainScene.unity` is included in the build scene list.
- Large model and media assets are stored inside `Assets/Resources/`; avoid deleting them unless the scene references have been checked.

## Author

Created for CC106 as an augmented reality identity-card prototype.
