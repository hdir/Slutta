using System;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class BadgePage : ContentPage
    {
        public BadgePage()
        {
            InitializeComponent();
        }

        public BadgePage(Services.Badge badge)
        {
            InitializeComponent();
            BindingContext = badge;
        }

        async void ReturnHome(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async void Share_stats(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("share_badge");
            await Navigation.PushModalAsync(new NavigationPage(new BadgeSharePage((Services.Badge)BindingContext)));
        }
    }
}
