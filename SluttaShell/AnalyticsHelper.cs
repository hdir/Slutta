using Xamarin.Forms;

namespace SluttaShell
{
    public static class AnalyticsHelper
    {
        public static void Send(string name) => DependencyService.Get<IEventTracker>().SendEvent(name);
    }
}
