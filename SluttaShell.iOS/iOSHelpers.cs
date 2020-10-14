using UIKit;

namespace SluttaShell.iOS
{
    public static class iOSHelpers
    {
        public static bool AppIsInForeground => UIApplication.SharedApplication.ApplicationState == UIApplicationState.Active;
    }
}
