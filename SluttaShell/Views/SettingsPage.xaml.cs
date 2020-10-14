using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using SluttaShell.Services;
using System.Threading.Tasks;

namespace SluttaShell.Views
{
    [DesignTimeVisible(false)]
    public partial class SettingsPage : ContentPage
    {
        DateTime _oldSmokeQuitDateTime;
        DateTime _oldSnusQuitDateTime;

        public SettingsPage() => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var userData = new UserData { StoffList = StoffService.GetStoff() };

            _oldSmokeQuitDateTime = QuitDateTimeIfActive(userData.StoffList[0]);
            _oldSnusQuitDateTime = QuitDateTimeIfActive(userData.StoffList[1]);

            BindingContext = userData;
        }

        async void GoToInfo(object sender, EventArgs e) =>
            await Navigation.PushModalAsync(new NavigationPage(new InfoPage()));

		async void GoToPersonvern(object sender, EventArgs e) =>
			await Navigation.PushModalAsync(new NavigationPage(new PersonvernPage()));

        static DateTime QuitDateTimeIfActive(Stoff stoff) => stoff.IsActive ? stoff.QuitDateTime : DateTime.MinValue;

        static void ResetPopupIfQuitDateTimeChanged(Stoff stoff, DateTime oldQuitDateTime)
        {
			if (QuitDateTimeIfActive(stoff) != oldQuitDateTime)
            {
				stoff.HaveShownFirstDayPopup = false;
            }
        }

		async void SaveUserSettings(object sender, EventArgs e)
		{
            var userData = (UserData)BindingContext;

			// send analytics event for types of smoking given up
			if (userData.StoffList[0].IsActive && userData.StoffList[1].IsActive)
			{
				AnalyticsHelper.Send("user_royk_snus");
			}
			else if (userData.StoffList[0].IsActive)
            {
				AnalyticsHelper.Send("user_royk");
			}
			else if (userData.StoffList[1].IsActive)
            {
				AnalyticsHelper.Send("user_snus");
			}

			// send analytics event for reason of quitting
			if (userData.StoffList[0].IsActive)
            {
                switch (userData.StoffList[0].Grunn)
                {
                    case "Helse":
                        AnalyticsHelper.Send("user_royk_helse");
                        break;
                    case "Penger":
                        AnalyticsHelper.Send("user_royk_penger");
                        break;
                    case "Avhengighet":
                        AnalyticsHelper.Send("user_royk_avhengig");
                        break;
                    case "Mine nærmeste":
                        AnalyticsHelper.Send("user_royk_familie");
                        break;
                    case "Utseende":
                        AnalyticsHelper.Send("user_royk_utseende");
                        break;
                    case "Annet":
                        AnalyticsHelper.Send("user_royk_annet");
                        break;
                }
            }
			if (userData.StoffList[1].IsActive)
            {
                switch (userData.StoffList[1].Grunn)
                {
                    case "Helse":
                        AnalyticsHelper.Send("user_snus_helse");
                        break;
                    case "Penger":
                        AnalyticsHelper.Send("user_snus_penger");
                        break;
                    case "Avhengighet":
                        AnalyticsHelper.Send("user_snus_avhengig");
                        break;
                    case "Mine nærmeste":
                        AnalyticsHelper.Send("user_snus_familie");
                        break;
                    case "Utseende":
                        AnalyticsHelper.Send("user_snus_utseende");
                        break;
                    case "Annet":
                        AnalyticsHelper.Send("user_snus_annet");
                        break;
                }
            }

			ResetPopupIfQuitDateTimeChanged(userData.StoffList[0], _oldSmokeQuitDateTime);
			ResetPopupIfQuitDateTimeChanged(userData.StoffList[1], _oldSnusQuitDateTime);

			var stoffJsonString = JsonConvert.SerializeObject(userData.StoffList);
			File.WriteAllText(StoffService.StoffFilePath, stoffJsonString);

			// Force update as navigating back to the home page wont apply new
			// notifications because of the 'two day' check
			DailyNotifications.ForceUpdateEnqueuedLocalNotifications();

			// button animations
			Task scaleIn = saveAnimated.ScaleTo(1.07, 300, Easing.CubicInOut);
			Task translateIn = saveAnimated.TranslateTo(0, -1, 300, Easing.CubicInOut);
			saveAnimated.TextColor = Color.FromHex("#EF3340");

			// Animate in parallel.
			await Task.WhenAll(new List<Task> { scaleIn, translateIn });

            // Wait a little before animating back
			await Task.Delay(20);

			Task scaleOut = saveAnimated.ScaleTo(1, 300, Easing.CubicInOut);
			Task translateOut = saveAnimated.TranslateTo(0, 0, 300, Easing.CubicInOut);

			// Animate in parallel.
			await Task.WhenAll(new List<Task> { scaleOut, translateOut });
			saveAnimated.TextColor = Color.FromHex("#082329");
		}
	}
}
