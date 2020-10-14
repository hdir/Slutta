using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using SluttaShell.Services;

namespace SluttaShell.Views
{
    [DesignTimeVisible(false)]
    public partial class ToolsPage : ContentPage
    {
        public ToolsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new UserData { StoffList = StoffService.GetStoff() };
        }

        void LaunchAvhengighet(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_avhengighetstest");
            Launcher.OpenAsync("https://www.sigarettavhengighet.no");
        }

        void LaunchRoykesluttgevinster(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_royk_helsegevinst");
            Launcher.OpenAsync("https://www.roykesluttgevinster.no");
        }

        async void GoToArkiv(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_pusharkiv");
            await Navigation.PushModalAsync(new NavigationPage(new ArkivPage()));
        }

        async void GoToChatbotPage(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_chatbot");
            await Navigation.PushModalAsync(new NavigationPage(new Chatbot()));
        }

        async void GoToSnusInnhold(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_snus_innholder");
            await Navigation.PushModalAsync(new NavigationPage(new SnusInnholdPage()));
        }

        async void GoToSnusHelsegevinster(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("tools_snus_helsegevinst");
            await Navigation.PushModalAsync(new NavigationPage(new SnusHelsegevinsterPage()));
        }
    }
}
