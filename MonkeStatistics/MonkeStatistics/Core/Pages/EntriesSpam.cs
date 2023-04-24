using MonkeStatistics.API;

namespace MonkeStatistics.Core.Pages
{
    [DisplayInMainMenu("Spam Test")]
    internal class EntriesSpam : Page
    {
        public override void OnPageOpen()
        {
            base.OnPageOpen();
            for (int i = 0; i < 35; i++)
                AddLine(i.ToString());
            SetLines();
        }
    }
}
