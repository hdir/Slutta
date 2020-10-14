using System;
using System.IO;
using Xamarin.Forms;
using Newtonsoft.Json;
using SluttaShell.Services;

namespace SluttaShell.Views
{
    public partial class InitiateOnboardingPage : CarouselPage
    {
        // Because xamrin onappearing is not working as advertised
        HomePage _homePageIfComingFromThere;

        public InitiateOnboardingPage(HomePage homePageIfComingFromThere = null)
        {
            _homePageIfComingFromThere = homePageIfComingFromThere;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var stoff = StoffService.GetStoff();

            BindingContext = new UserData { StoffList = stoff };

            NextBtn.BackgroundColor = (royk_active.IsToggled || snus_active.IsToggled)
                ? Color.FromHex("#EF3340")
                : Color.FromHex("#CBCBCB");

            snus_active.Toggled -= OnSnusToggled;
            snus_active.Toggled += OnSnusToggled;

            royk_active.Toggled -= OnRoykToggled;
            royk_active.Toggled += OnRoykToggled;
        }

        void OnRoykToggled(object sender, ToggledEventArgs e)
        {
            NextBtn.BackgroundColor = e.Value
                ? Color.FromHex("#EF3340")
                : snus_active.IsToggled ? Color.FromHex("#EF3340") : Color.FromHex("#CBCBCB");
        }

        void OnSnusToggled(object sender, ToggledEventArgs e)
        {
            NextBtn.BackgroundColor = e.Value
                ? Color.FromHex("#EF3340")
                : royk_active.IsToggled ? Color.FromHex("#EF3340") : Color.FromHex("#CBCBCB");
        }

        void SaveActivePreferences(object sender, EventArgs e)
        {
            var userData = (UserData)BindingContext;

            // reset all the first have popups
            userData.StoffList[0].HaveShownFirstDayPopup = false;
            userData.StoffList[1].HaveShownFirstDayPopup = false;

            SaveSettings(userData);

            // Force update as navigating back to the home page wont apply new
            // notifications because of the 'two day' check
            DailyNotifications.ForceUpdateEnqueuedLocalNotifications();

            if (userData.StoffList[0].IsActive)
            {
                OnboardingCarousel.CurrentPage = OnboardingCarousel.Children[1];
            }
            else if (userData.StoffList[1].IsActive)
            {
                OnboardingCarousel.CurrentPage = OnboardingCarousel.Children[2];
            }
        }

        async void ProgressFromSmoking(object sender, EventArgs e)
        {
            var userData = (UserData)BindingContext;
            SaveSettings(userData);

            // Force update as navigating back to the home page wont apply new
            // notifications because of the 'two day' check
            DailyNotifications.ForceUpdateEnqueuedLocalNotifications();

            if (!userData.StoffList[1].IsActive)
            {
                AnalyticsHelper.Send("user_royk");
            }

            if (userData.StoffList[1].IsActive)
            {
                OnboardingCarousel.CurrentPage = OnboardingCarousel.Children[2];
            }
            else
            {
                // used to use PopModal but got inconsistent behavior across platforms
                await ModalHelpers.PopAllModals();
                _homePageIfComingFromThere?.ReAppear();
            }
        }

        async void ProgressFromSnus(object sender, EventArgs e)
        {
            var userData = (UserData)BindingContext;
            SaveSettings(userData);

            // Force update as navigating back to the home page wont apply new
            // notifications because of the 'two day' check
            DailyNotifications.ForceUpdateEnqueuedLocalNotifications();

            if (userData.StoffList[0].IsActive && userData.StoffList[1].IsActive)
            {
                AnalyticsHelper.Send("user_royk_snus");
            }
            else
            {
                AnalyticsHelper.Send("user_snus");
            }

            // used to use PopModal but got inconsistent behavior across platforms
            await ModalHelpers.PopAllModals();
            _homePageIfComingFromThere?.ReAppear();
        }

        void SaveSettings(UserData userData)
        {
            var stoffJsonString = JsonConvert.SerializeObject(userData.StoffList);
            File.WriteAllText(StoffService.StoffFilePath, stoffJsonString);
        }
    }
}
