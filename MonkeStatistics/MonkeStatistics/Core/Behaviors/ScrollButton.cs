namespace MonkeStatistics.Core.Behaviors
{
    internal class ScrollButton : PreConfiguredButton
    {
        public bool IsUp;
        public override void ButtonActivation()
        {
            StartCoroutine(ButtonDelay());
            if (IsUp)
            {
                UIManager.CurrentPage.CurrentScene--;
                UIManager.CurrentPage.OnPageOpen();
            }
            else
            {
                UIManager.CurrentPage.CurrentScene++;
                UIManager.CurrentPage.OnPageOpen();
            }
        }
    }
}
