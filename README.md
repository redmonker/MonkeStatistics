# MonkeStatistics
A simple player statistic tracker for Gorilla Tag.
## Installation
To install this mod, drag and drop the contents of the ZIP file into your Gorilla Tag folder.
## For Developer
Please note this mod is mainly designed for showing statistics the buttons are suppose to be a secondary feature. But lets begin.
### Settings up
To start your project, add MonkeStatistics as a BepInEx dependencies. ``[BepInDependency("Crafterbot.MonkeStatistics")]`` Then add
MonkeStatistics as a dependencies in Visual Studios(or your preferred IDE). To ensure it is added correctly, in your main file reference it at ``using MonkeStatistics.API``. If there is a red line under that statement, trouble shoot or something.
### Getting started
To register your plugin to MonkeStatistics, execute the following method. ``MonkeStatistics.API.Registry.AddAssembly();`` This method must be execute before the ``GorillaLocomotion.Player.instance`` is defined. So I would recommend executing it on your projects ``Awake`` method.
### Writing a basic page

### Project Info
* Position : 0.0288 0.0267 -0.004
* Rotation : -26.97 94.478 -93.21101
## Credits & Legal
* 3D watch model by [Zulubo](http://www.zulubo.com/).
* 3D watch model was downloaded from the Unity Asset store.
