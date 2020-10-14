using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class HelpDetailPage : ContentPage
    {
        public ICommand LaunchUri => new Command<string>(async (url) => {
            switch (url)
            {
                case "https://helsenorge.no/rus-og-avhengighet/snus-og-roykeslutt/hjelpemidler-ved-roykeslutt":
                    AnalyticsHelper.Send("help_legemidler_les-mer");
                    break;
                case "http://maps.google.com":
                    AnalyticsHelper.Send("help_aktivitet_kart");
                    break;
            }
            await Launcher.OpenAsync(url);
        });

        public HelpDetailPage() => InitializeComponent();

        public HelpDetailPage(Services.HelpTools helpTools)
        {
            InitializeComponent();
            BindingContext = helpTools;
        }

        async void ReturnHome(object sender, EventArgs e) => await Navigation.PopModalAsync();

        async void GoToReset(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("help_sos_nytt");
            await Navigation.PushModalAsync(new NavigationPage(new InitiateOnboardingPage()));
        }
    }
}
