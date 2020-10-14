using System;
using System.Collections.Generic;
using SluttaShell.Services;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class ArkivPage : ContentPage
    {
        public List<UxNotifs> PastSmokeNotifs => DailyNotifications.PastSmokeNotifs;
        public List<UxNotifs> PastSnusNotifs => DailyNotifications.PastSnusNotifs;

        public ArkivPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DailyNotifications.UpdatePastNotifs();
            BindingContext = this;

            var stoffList = StoffService.GetStoff();

            AnalyticsHelper.Send("tools_pusharkiv");

            // show toggle area or not
            if (stoffList[0].IsActive != stoffList[1].IsActive)
            {
                NotifToggle.IsVisible = false;
            }
            else
            {
                NotifToggle.IsVisible = true;
                if (stoffList[0].IsActive)
                {
                    SmokeNotifs.IsVisible = true;
                    SnusNotifs.IsVisible = false;
                }
                else
                {
                    SmokeNotifs.IsVisible = false;
                    SnusNotifs.IsVisible = true;
                }
            }

            // decide which list to show first
            if (stoffList[0].IsActive)
            {
                SmokeNotifs.IsVisible = true;
                SnusNotifs.IsVisible = false;

                ToggleToRoyk.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToRoyk.TextColor = Color.FromHex("#4B4B4B");
                ToggleToSnus.BackgroundColor = Color.Transparent;
                ToggleToSnus.TextColor = Color.FromHex("#707070");
            }
            else
            {
                SmokeNotifs.IsVisible = false;
                SnusNotifs.IsVisible = true;

                ToggleToRoyk.BackgroundColor = Color.Transparent;
                ToggleToRoyk.TextColor = Color.FromHex("#707070");
                ToggleToSnus.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToSnus.TextColor = Color.FromHex("#4B4B4B");
            }
        }

        async void ReturnToProfil(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void ToggleArkivToSnus(object sender, EventArgs e)
        {
            var b = (Button)sender;

            if (b.BackgroundColor == Color.FromHex("#FFFFFF"))
            {
                b.BackgroundColor = Color.Transparent;
                b.TextColor = Color.FromHex("#707070");
            }
            else
            {
                b.BackgroundColor = Color.FromHex("#FFFFFF");
                b.TextColor = Color.FromHex("#4B4B4B");
            }

            if (ToggleToRoyk.BackgroundColor == Color.FromHex("#FFFFFF"))
            {
                ToggleToRoyk.BackgroundColor = Color.Transparent;
                ToggleToRoyk.TextColor = Color.FromHex("#707070");
            }
            else
            {
                ToggleToRoyk.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToRoyk.TextColor = Color.FromHex("#4B4B4B");
            }

            SmokeNotifs.IsVisible = false;
            SnusNotifs.IsVisible = true;
        }

        void ToggleArkivToRoyk(object sender, EventArgs e)
        {
            var b = (Button)sender;

            if (b.BackgroundColor == Color.FromHex("#FFFFFF"))
            {
                b.BackgroundColor = Color.Transparent;
                b.TextColor = Color.FromHex("#707070");
            }
            else
            {
                b.BackgroundColor = Color.FromHex("#FFFFFF");
                b.TextColor = Color.FromHex("#4B4B4B");
            }

            if (ToggleToSnus.BackgroundColor == Color.FromHex("#FFFFFF"))
            {
                ToggleToSnus.BackgroundColor = Color.Transparent;
                ToggleToSnus.TextColor = Color.FromHex("#707070");
            }
            else
            {
                ToggleToSnus.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToSnus.TextColor = Color.FromHex("#4B4B4B");
            }
            SmokeNotifs.IsVisible = true;
            SnusNotifs.IsVisible = false;
        }

    }
}
