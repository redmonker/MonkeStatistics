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
Now it is time to write a page. What is a page? A page is a group of lines that can be used to show information to a player. Each line can have one button. The button can ether be a toggle button, or a standard click button.
```cs
    [DisplayInMainMenu("My Displayname")] // If this attribute is here, this page will be on the main menu.
    internal class MyPage : Page
    {
        public override void OnPageOpen() // this method will execute when this page is opened through the UIManager
        {
            TextLines = new Dictionary<string, ButtonInfo>()
            {
                {"Player Name", null }, // if the button info is null, there will be no button on that line.
                { "Kills", new ButtonInfo(EventMethod_handler, 0, false, false) },
            };
            SetTitle("Gorilla Scoreboard"); // sets the title field
            SetAuthor(""); // sets the author field
            SetLines(); // sets all lines as TextLines. 
        }

        private void EventMethod_handler(object Sender, object[] Args)
        {
          int ReturnId = (int)Args[0];
          bool IsOn = (bool)Args[1];
          bool IsToggleButton = (ButtonType)Args[2]; // button type
        }
    }
```
### Project Info
* Position : 0.0288 0.0267 -0.004
* Rotation : -26.97 94.478 -93.21101
## Credits & Legal
* 3D watch model by [Zulubo](http://www.zulubo.com/).
* 3D watch model was downloaded from the Unity Asset store.
* This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC. © 2021 Another Axiom LLC.
- https://www.gorillatagvr.com/fan-content-mod-policy
