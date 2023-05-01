/*
    A very bare bones example. 
*/


using MonkeStatistics.API;

namespace Template
{

    /*
        If you mod does not provide a gameplay advanage, and you want it to work offline and in all gamemodes,
        do:[DisplayInMainMenu("My Display Name", CanWorkInNoneModded = true)]
    */
    [DisplayInMainMenu("My Display Name")] // This will make this page appear in the main menu
    internal class MyPage : Page
    {
        private int Score;
        public override void OnPageOpen()
        {
            base.OnPageOpen(); // this will reset the page

            SetTitle("My Mod Name"); // sets the title field
            SetAuthor("By your name"); // sets the author field

            // every line can contain 17 characters, going above this will cause the text to overflow.

            AddText("My paragraph, I can add as much text as I want. Isn't that just amazing. Crafterbot is so sexy and hot."); // This will split the text at ever 17 characters, and add string.lengh/17 lines to the page.
            AddLine(2); // offset
            AddLine("Enable Mod", new ButtonInfo(OnPressed, 0, ButtonInfo.ButtonType.Toggle, Plugin.Enabled));
            AddLine("Add", new ButtonInfo(OnPressed, 1)); // by default this is a press button
            AddLine("Score:" + Score);

            SetLines(); // This will delete all current lines, and add the lines that you have added to the page.
        }

        private void OnPressed(object Sender, object[] Args)
        {
            int ReturnIndex = (int)Args[0]; // This is a constant number that you passed through.
            // returns: 0

            bool IsOn = (bool)Args[1]; // Is the button on // only for toggle button if the button is a press then it will always return true
            ButtonInfo.ButtonType buttonType = (ButtonInfo.ButtonType)Args[2];

            // My code

            if (ReturnIndex == 0)
            {
                Plugin.Enabled = IsOn;
            }
            else if (ReturnIndex == 1)
            {
                Score++; // adds to the score, this is just a basic clicker game
                UpdateLines(); // This will only update the text of the lines, and will not effect the buttons.
            }

            /*
                If you want to open another page, do ShowPage<PageType>().
            */
        }

        private void Reset()
        {
            TextLines = new Line[0]; // resets the stored variable
            ShowPage<MyPage>(); // redraws this page
        }
    }
}
