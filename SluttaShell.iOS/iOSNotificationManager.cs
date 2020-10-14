using System;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(SluttaShell.iOS.iOSNotificationManager))]
namespace SluttaShell.iOS
{
    public class iOSNotificationManager : INotificationManager
    {
        static int _messageId = -1;

        bool _hasNotificationsPermission;

        public event Action<string, string, bool> NotificationReceived;

        public void Initialize()
        {
            // request the permission to use local notifications
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) =>
            {
                _hasNotificationsPermission = approved;
            });
        }

        public void CancelPendingNotifications() =>
            UNUserNotificationCenter.Current.RemoveAllPendingNotificationRequests();

        public void Later(DateTime notifTime, string title, string body, bool sound, int badgeNumber)
        {
            // EARLY OUT: app doesn't have permissions
            if (!_hasNotificationsPermission)
            {
                return;
            }

            _messageId++;

            var content = new UNMutableNotificationContent()
                {
                    Title = title,
                    Subtitle = "",
                    Body = body,
                    Badge = badgeNumber
                };

            // Set trigger time
            var secondsFromNow = (notifTime - DateTime.Now).TotalSeconds;
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(secondsFromNow, repeats: false);

            var request = UNNotificationRequest.FromIdentifier(_messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });
        }

        public void ReceiveNotification(string title, string message, bool cameFromNotificationBar)
        {
            NotificationReceived?.Invoke(title, message, cameFromNotificationBar);
        }
    }
}
