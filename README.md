# KSPSaveSync
A simple plugin to synchronise Kerbal Space Program saves.

# Usage
Build the plugin and copy ```SaveGameSyncer.dll``` to ```<KSP>/Plugins.```
Finally create ```sync.cfg``` in ```<KSP>/Plugins```, have it contain *only* the directory you want to synchronise with.

# How it works
When the main menu loads, all saves will be copied from the sync directory to the KSP save directory.
Any time the game saves, all save data will be copied back from the KSP save directory to the sync directory.

This can be useful for using Google Drive, Dropbox,  MEGAsync or other programs to keep your saves in the cloud.

# Compiling
* Load the solution in Visual Studio 2013 or higher
* Add references to ```Assembly-CSharp.dll``` and ```UnityEngine.dll``` (can be found in ```<KSP>/KSP_Data/Managed``` directory)
* Voila! It should now compile fine

Refer to usage on how to use
