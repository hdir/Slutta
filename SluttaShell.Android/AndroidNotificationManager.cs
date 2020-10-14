using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Xamarin.Forms;
using AndroidApp = Android.App.Application;

[assembly: Dependency(typeof(SluttaShell.Droid.AndroidNotificationManager))]
namespace SluttaShell.Droid
{
    public class AndroidNotificationManager : INotificationManager
    {
        public const string TITLE_KEY = "title";
        public const string BODY_KEY = "body";

        const string CHANNEL_ID = "default";
        const string CHANNEL_NAME = "Default";
        const string CHANNEL_DESCRIPTION = "The default channel for notifications.";

        const string ALARMS_TAG = ":alarms";

        bool _channelInitialized;
        int _messageId = -1;

        public event Action<string, string, bool> NotificationReceived;

        public void Initialize() => CreateNotificationChannel();

        public void CancelPendingNotifications() => CancelAllAlarms();

        public void Later(DateTime notifTime, string title, string body, bool sound, int badgeNumber)
        {
            if (!_channelInitialized)
            {
                CreateNotificationChannel();
            }

            _messageId++;

            var intent = new Intent(AndroidApp.Context, typeof(NotificationAlarmHandler));

            intent.PutExtra("id", _messageId);
            intent.PutExtra(TITLE_KEY, title);
            intent.PutExtra(BODY_KEY, body);
            intent.PutExtra("sound", sound);
            intent.PutExtra("channelId", CHANNEL_ID);

            var pendingIntent = PendingIntent.GetBroadcast(AndroidApp.Context, _messageId, intent, PendingIntentFlags.UpdateCurrent);

            var alarmManager = (AlarmManager)AndroidApp.Context.GetSystemService(Context.AlarmService);
            var alarmTime = Java.Util.Calendar.Instance;
            var secondsFromNow = (int)(notifTime - DateTime.Now).TotalSeconds;
            alarmTime.Add(Java.Util.CalendarField.Second, secondsFromNow);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, alarmTime.TimeInMillis, pendingIntent);
            }
            else if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                alarmManager.SetExact(AlarmType.RtcWakeup, alarmTime.TimeInMillis, pendingIntent);
            }
            else
            {
                alarmManager.Set(AlarmType.RtcWakeup, alarmTime.TimeInMillis, pendingIntent);
            }
            SaveAlarmId(_messageId);
        }

        [BroadcastReceiver]
        internal class NotificationAlarmHandler : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                var id = intent.GetIntExtra("id", 0);
                var title = intent.GetStringExtra(TITLE_KEY);
                var body = intent.GetStringExtra(BODY_KEY);
                var sound = intent.GetBooleanExtra("sound", false);
                var channelId = intent.GetStringExtra("channelId");

                if (IsApplicationInTheForeground())
                {
                    DependencyService.Get<INotificationManager>().ReceiveNotification(title, body, cameFromNotificationBar: false);
                }
                else
                {
                    var resultIntent = AndroidApp.Context.PackageManager.GetLaunchIntentForPackage(AndroidApp.Context.PackageName);
                    resultIntent.SetAction(intent.Action);
                    resultIntent.ReplaceExtras(intent.Extras);
                    resultIntent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);

                    // Create the notification.
                    var resultPendingIntent = PendingIntent.GetActivity(AndroidApp.Context, 0, resultIntent, PendingIntentFlags.UpdateCurrent);
                    var builder = new NotificationCompat.Builder(AndroidApp.Context)
                        .SetSmallIcon(Resource.Mipmap.notif)
                        .SetContentTitle(title)
                        .SetContentText(body)
                        .SetVibrate(new[] { 1000L, 1000L })
                        .SetAutoCancel(true)
                        .SetContentIntent(resultPendingIntent);

                    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    {
                        builder.SetChannelId(channelId);
                    }

                    if (sound)
                    {
                        var defaultSoundUri = Android.Media.RingtoneManager.GetDefaultUri(Android.Media.RingtoneType.Notification);
                        builder.SetSound(defaultSoundUri);
                    }

                    // Show the notification.
                    var notificationManager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);
                    var notif = builder.Build();
                    if (sound)
                    {
                        notif.Defaults |= NotificationDefaults.Sound;
                    }
                    notif.Defaults |= NotificationDefaults.Lights;
                    notif.Defaults |= NotificationDefaults.Vibrate;
                    notificationManager.Notify(id, notif);
                }
            }
        }

        public void ReceiveNotification(string title, string message, bool cameFromNotificationBar)
        {
            NotificationReceived?.Invoke(title, message, cameFromNotificationBar);
        }

        static void SaveAlarmId(int id)
        {
            var idsAlarms = GetAlarmIds();

            if (idsAlarms.Contains(id))
            {
                return;
            }

            idsAlarms.Add(id);
            SaveIdsInPreferences(idsAlarms);
        }

        static void SaveIdsInPreferences(IReadOnlyCollection<int> lstIds)
        {
            var prefs = Android.Preferences.PreferenceManager.GetDefaultSharedPreferences(AndroidApp.Context);
            var editor = prefs.Edit();
            var idsStr = lstIds == null ? "" : string.Join("|", lstIds);
            editor.PutString(AndroidApp.Context.PackageName + ALARMS_TAG, idsStr);
            editor.Apply();
        }

        static void CancelAllAlarms()
        {
            var intent = new Intent(AndroidApp.Context, typeof(NotificationAlarmHandler));
            var alarmManager = (AlarmManager)AndroidApp.Context.GetSystemService(Context.AlarmService);
            var alarmIds = GetAlarmIds();
            foreach (int notificationId in alarmIds)
            {
                var pendingIntent = PendingIntent.GetBroadcast(AndroidApp.Context, notificationId, intent, PendingIntentFlags.UpdateCurrent);
                alarmManager.Cancel(pendingIntent);
                pendingIntent.Cancel();
            }
            SaveIdsInPreferences(null);
        }

        static List<int> GetAlarmIds()
        {
            try
            {
                var prefs = Android.Preferences.PreferenceManager.GetDefaultSharedPreferences(AndroidApp.Context);
                var idsStr = prefs.GetString(AndroidApp.Context.PackageName + ALARMS_TAG, "");
                return idsStr.Split('|').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
            }
            catch (Exception e)
            {
                return new List<int>();
            }
        }

        static bool IsApplicationInTheForeground()
        {
            var myProcess = new Android.App.ActivityManager.RunningAppProcessInfo();
            ActivityManager.GetMyMemoryState(myProcess);
            return myProcess.Importance == Android.App.Importance.Foreground;
        }

        void CreateNotificationChannel()
        {
            var manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelNameJava = new Java.Lang.String(CHANNEL_NAME);
                var channel = new NotificationChannel(CHANNEL_ID, channelNameJava, NotificationImportance.Default) {
                    Description = CHANNEL_DESCRIPTION
                };
                manager.CreateNotificationChannel(channel);
            }

            _channelInitialized = true;
        }
    }
}
