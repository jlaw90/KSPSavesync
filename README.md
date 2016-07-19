# KSPSaveSync
A simple plugin to synchronise Kerbal Space Program saves.

# Usage
Download the latest release from https://github.com/jlaw90/KSPSaveSync/releases and copy ```SaveGameSyncer.dll``` to ```<KSP>/Plugins.```
Copy ```sync.cfg.example``` to ```<KSP>/Plugins``` as well, change it so that it contains *only* the directory you want to sync your saves with and rename it to ```sync.cfg```.

# How it works
When the main menu loads, all saves will be copied from the sync directory to the KSP save directory.
Any time the game saves, all save data will be copied back from the KSP save directory to the sync directory.

This can be useful for using Google Drive, Dropbox,  MEGAsync or other programs to keep your saves in the cloud.

# Compiling
* Load the solution in Visual Studio 2013 or higher
* Add references to ```Assembly-CSharp.dll```, ```UnityEngine.dll``` and ```KSPUtil.dll``` (can be found in ```<KSP>/KSP_Data/Managed``` directory)
* Voila! It should now compile fine

Refer to usage on how to use

# Contributing
If you have any suggestions on how to make this better feel free to open an issue or create a pull request
