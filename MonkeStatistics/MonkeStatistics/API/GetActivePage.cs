using MonkeStatistics.Core;

namespace MonkeStatistics.API
{
    public class GetActivePage
    {
        public static Page GetPage()
        {
            return UIManager.CurrentPage;
        }
    }
}
