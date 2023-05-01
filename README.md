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
	   SetTitle("My Mod Title"); // Sets the title field
	   SetAuthor("By Crafterbot"); // Sets the author field
	   
	   AddText("my big line grouping thing idk why am I doing this, I should just quit now."); // adds text to the page, note this will be split at ever 17 characters to form a new line.
	   AddLine("My line"); // adds a new line to the page
	   AddLine("My Button Line", new ButtonInfo(MyEvent, 0); // adds a line with a button
	   AddLine(2); // adds multiple lines
	   
	   SetText(); // sets all lines of the page, note NEVER use this on button event.
        }

        private void EventMethod_handler(object Sender, object[] Args)
        {
          int ReturnId = (int)Args[0];
          bool IsOn = (bool)Args[1];
          ButtonInfo.ButtonType buttonType = (ButtonInfo.ButtonType)Args[2]; // button type

	   // To prevent feedback loops, never redraw the page when the player is touching a button. Instead
	   // Use UpdateLines(); method.
        }
    }
```
### Opening other pages
To open another page from your page, simply execute the following method. ``MonkeStatistics.Core.UIManager.Instance.ShowPage(typeof(MyPage))``. However if you are in a class that inherits ``Page`` you can simply do ``ShowPage``. It is VERY important to remember that ever page with the ``[DisplayInMainMenu("My Displayname")]`` attribute will appear in the MainMenu when the watch is opened. If you do not want it to appear so, simply remove that attribute.
### Important Notice
If you execute the ``SetText()`` method when the players hand is touching/pressing a button, it will cause a loop. Instead use the ``UpdateLines()`` method. The ``UpdateLines()`` method will only set the text, and will not effect the buttons, nor lines at all. In addition keep each line down to 14 characters long, or it will go into the button. If the button is disabled increase it to 17 characters. Remember that is you plugin cannot work in public lobbies, you must handle a custom message.
### Public lobbies
By default your page will not open if the user is in a none modded room. However you can override this feature by changing your main menu display attribute to this: ``[DisplayInMainMenu("Name", CanWorkInNoneModded = true)]``. It is important to note, if your plugin provides a gameplay advantage this is bannable.
### Overriding back button
If you decide to override the back button, you MUST reset it once you are done with it. ``SetBackButtonOverride(Type MyPage)``. This method can only be called inside of the Page class, or in a subclass of it.
### 
### Project Info
* Position : 0.0288 0.0267 -0.004
* Rotation : -26.97 94.478 -93.21101
## Credits & Legal
* This mod was inspired by [ComputerInterface](https://github.com/ToniMacaroni/ComputerInterface) and [RedBrumbler](https://github.com/RedBrumbler).
* 3D watch model by [Zulubo](http://www.zulubo.com/).
* 3D watch model was downloaded from the Unity Asset store.
* This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC. © 2021 Another Axiom LLC.
- https://www.gorillatagvr.com/fan-content-mod-policy
