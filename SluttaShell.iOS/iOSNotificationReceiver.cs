using System;
using UserNotifications;
using Xamarin.Forms;

namespace SluttaShell.iOS
{
    public class IOSNotificationReceiver : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(UNUserNotificationCenter center,
                                                     UNNotification notification,
                                                     Action<UNNotificationPresentationOptions> completionHandler)
        {
            if (iOSHelpers.AppIsInForeground)
            {
                DependencyService.Get<INotificationManager>().ReceiveNotification(notification.Request.Content.Title,
                                                                                  notification.Request.Content.Body,
                                                                                  cameFromNotificationBar: false);
                completionHandler(UNNotificationPresentationOptions.None);
            }
            else
            {
                completionHandler(UNNotificationPresentationOptions.Alert);
            }
        }

        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center,
                                                            UNNotificationResponse response,
                                                            Action completionHandler)
        {
            if (response.IsDefaultAction)
            {
                var notification = response.Notification;
                DependencyService.Get<INotificationManager>().ReceiveNotification(notification.Request.Content.Title,
                                                                                  notification.Request.Content.Body,
																				  cameFromNotificationBar: true);
            }

            // mandatory thing we have to call
            completionHandler();
        }
    }
}
