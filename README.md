# AutoRestart

Automatically restart your Muse Dash gameplay with specific conditions.

---

AutoRestart can be configured to automatically restart your gameplay from two conditions:
1. When ALL PERFECT is lost (ie. greats, misses, damage taken from enemies, missed blue notes / hearts)
2. When FULL COMBO is lost (ie. misses, damage taken from enemies, missed blue notes / hearts)

Toggle AutoRestart by pressing the `backspace` key, and toggle between AP and FC modes by pressing the `delete` key.
(These keybinds can be configured. See [Configuration](#Configuration)).

## Installation

- Install [MelonLoader v.0.6.1](https://github.com/LavaGang/MelonLoader) into Muse Dash.
- Download the [latest release](https://github.com/Miriitode/AutoRestart/releases) and drop the file into your `mods` folder.

## Configuration

Configure the mod's settings in `Muse Dash/UserData/MelonPreferences.cfg`.

`Enable AutoRestart`: Enables or disables autorestart (default value: `true`)

`Toggle Enable Key`: Key to use to toggle AutoRestart (default value: `"Backspace"`)

`Restart Mode`: AutoRestart Mode. Valid values are "AP", "FC" (default value: `"FC"`)

`Toggle Mode Key`: Key to use to toggle between restart modes (default value: `"Delete"`)

## Acknowledgements

This is my first time creating a mod for Muse Dash (and it's honestly been a while since I've used C#), so I took inspiration from the following mods:

- Ashton's [QuickRestart mod](https://github.com/MDMods/QuickRestart)
- Flustix's [AccDisplay mod](https://github.com/flustix/AccDisplay) and [Playlists mod](https://github.com/MDMods/Playlists)
