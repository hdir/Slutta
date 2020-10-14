using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SluttaShell.Services;
using SluttaShell.Views;

namespace SluttaShell
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            var notifMgr = DependencyService.Get<INotificationManager>();
            notifMgr.Initialize();
            notifMgr.NotificationReceived -= OnNotif;
            notifMgr.NotificationReceived += OnNotif;

            MainPage = new AppShell();
        }

        public void OnNotif(string title, string message, bool cameFromNotifcationBar)
        {
            if (cameFromNotifcationBar)
            {
                TransitionToArkivPage();
            }
        }

        async void TransitionToArkivPage()
        {
            await ModalHelpers.PopAllModals();
            await MainPage?.Navigation?.PushModalAsync(new ArkivPage());
        }

        protected override void OnStart() => DailyNotifications.UpdateEnqueuedLocalNotifications();
    }
}
