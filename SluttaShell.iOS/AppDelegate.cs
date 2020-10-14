using Foundation;
using UIKit;
using UserNotifications;

namespace SluttaShell.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("IndicatorView_Experimental", "Brush_Experimental");
            global::Xamarin.Forms.Forms.Init();

            // Setup for local notifications
            UNUserNotificationCenter.Current.Delegate = new IOSNotificationReceiver();

            LoadApplication(new App());

            Firebase.Core.App.Configure();

            return base.FinishedLaunching(app, options);
        }
    }
}
