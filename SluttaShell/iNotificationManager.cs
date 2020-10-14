using System;

namespace SluttaShell
{
    public interface INotificationManager
    {
        event Action<string, string, bool> NotificationReceived;

        void Initialize();

        void CancelPendingNotifications();

        void Later(DateTime notifTime, string title, string body, bool sound, int badgeNumber);

        void ReceiveNotification(string title, string message, bool cameFromNotificationBar);
    }
}
