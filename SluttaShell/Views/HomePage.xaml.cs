using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Newtonsoft.Json;
using SluttaShell.Services;

using System.Globalization;

namespace SluttaShell.Views
{
    public partial class HomePage : ContentPage
    {
        static int _currentTimerId = 1; // helper val so timers know when to stop themselves
        static BadgeInfo _badgeInfo;

        readonly PanGestureRecognizer _panGesture = new PanGestureRecognizer();
        bool _panGestureInitialized;
        bool _collapseDropdownHasRun;
        int _lastCenterIndex;

        public HomePage()
        {
            InitializeComponent();
            _badgeInfo = BadgeService.GetBadges();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var stoffList = StoffService.GetStoff();
            var userData = new UserData
            {
                StoffList = stoffList,
                BadgeInfo = BadgeInfo.GetFiltered(_badgeInfo, stoffList)
            };
            BindingContext = userData;

            timerCarousel.Scrolled -= OnCarouselViewScrolled;
            timerCarousel.Scrolled += OnCarouselViewScrolled;
            savingsCarousel.Scrolled -= OnCarouselViewScrolled;
            savingsCarousel.Scrolled += OnCarouselViewScrolled;
            _lastCenterIndex = timerCarousel.Position;

            // show zero day notif
            MaybeShowFirstDayNotif(userData);

            // navigate to onboarding
            if (!stoffList[0].IsActive && !stoffList[1].IsActive)
            {
                // Horrible hacks for the onboarding modals:
                // We used to check the modal stack depth to avoid an issue on iOS, however on android the
                // first InitiateOnboardingPage bugs out and is a black page, it also triggers OnAppearing
                // on this page for a second time, and that time the PushModal works. What a horrible
                // mess.
                // We allow it to make this mess and then use ModalHelpers.PopAllModals to get out of it
                // when you fix this make sure you test on iOS and Android in parallel as it's a sneaky one.
                Navigation.PushModalAsync(new InitiateOnboardingPage(this));
            }

            UpdateToggleButtonState();
            UpdateCarouselAndBadgeListState(stoffList);

            CollapseDropdown();
            InitializeDropdownRecognisers();

            ScheduleUiUpdateTimer(userData, stoffList);

            // random tip for the pageload
            int randomTipIndex = new Random().Next(1, 4);
            PanicButton.Source = $"panicbutton{randomTipIndex}";
        }

        static void ScheduleUiUpdateTimer(UserData userData, List<Stoff> stoffList)
        {
            _currentTimerId += 1;
            var timersOwnId = _currentTimerId; // this variable is captured by the closure
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (timersOwnId != _currentTimerId)
                {
                    return false;
                }

                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var stoffElem in userData.StoffList)
                    {
                        stoffElem.NotifyUiShouldChange();
                    }

                    // check to see if badges need updating, we can use length as a indicator of change
                    // as badges are sequential in time
                    var newBadgeInfo = BadgeInfo.GetFiltered(_badgeInfo, stoffList);
                    if (newBadgeInfo.BadgeInfoRoyk.Count != userData.BadgeInfo.BadgeInfoRoyk.Count ||
                        newBadgeInfo.BadgeInfoSnus.Count != userData.BadgeInfo.BadgeInfoSnus.Count)
                    {
                        userData.BadgeInfo = newBadgeInfo;
                    }
                });

                return true;
            });
        }

        void UpdateCarouselAndBadgeListState(IReadOnlyList<Stoff> stoffList)
        {
            if (stoffList[0].IsActive != stoffList[1].IsActive)
            {
                CarouselButtons1.IsVisible = false;
                var pos = stoffList[0].IsActive ? 0 : 1;
                timerCarousel.Position = pos;
                savingsCarousel.Position = pos;
                if (stoffList[0].IsActive)
                {
                    BadgeListRoyk.IsVisible = true;
                    BadgeListSnus.IsVisible = false;
                }
                else
                {
                    BadgeListSnus.IsVisible = true;
                    BadgeListRoyk.IsVisible = false;
                }
            }
            else
            {
                CarouselButtons1.IsVisible = true;
                if (timerCarousel.Position == 0)
                {
                    BadgeListRoyk.IsVisible = true;
                    BadgeListSnus.IsVisible = false;
                }
                else
                {
                    BadgeListSnus.IsVisible = true;
                    BadgeListRoyk.IsVisible = false;
                }
            }
        }

        void UpdateToggleButtonState()
        {
            if (timerCarousel.Position == 0)
            {
                ToggleToRoyk.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToRoyk.TextColor = Color.FromHex("#4B4B4B");
                ToggleToSnus.BackgroundColor = Color.Transparent;
                ToggleToSnus.TextColor = Color.FromHex("#707070");
            }
            else
            {
                ToggleToRoyk.BackgroundColor = Color.Transparent;
                ToggleToRoyk.TextColor = Color.FromHex("#707070");
                ToggleToSnus.BackgroundColor = Color.FromHex("#FFFFFF");
                ToggleToSnus.TextColor = Color.FromHex("#4B4B4B");
            }
        }

        public void ReAppear() => OnAppearing();

        async void Share_Progress(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("share_fremdrift");
            await Navigation.PushModalAsync(new NavigationPage(new SharePage()));
        }

        void Close_Popup(object sender, EventArgs e)
        {
            Popup.IsVisible = false;
        }

        void ToggleCarouselToSnus(object sender, EventArgs e)
        {
            timerCarousel.Position = 1;
            savingsCarousel.Position = 1;
        }

        void SetCarouselToSnus()
        {
            AnalyticsHelper.Send("use_switch_timer");

            ToggleToSnus.BackgroundColor = Color.FromHex("#FFFFFF");
            ToggleToSnus.TextColor = Color.FromHex("#4B4B4B");

            ToggleToRoyk.BackgroundColor = Color.Transparent;
            ToggleToRoyk.TextColor = Color.FromHex("#707070");

            BadgeListSnus.IsVisible = true;
            BadgeListRoyk.IsVisible = false;
        }

        void ToggleCarouselButtonsToRoyk(object sender, EventArgs e)
        {
            timerCarousel.Position = 0;
            savingsCarousel.Position = 0;
        }

        void SetCarouselButtonsToRoyk()
        {
            AnalyticsHelper.Send("use_switch_timer");

            ToggleToRoyk.BackgroundColor = Color.FromHex("#FFFFFF");
            ToggleToRoyk.TextColor = Color.FromHex("#4B4B4B");

            ToggleToSnus.BackgroundColor = Color.Transparent;
            ToggleToSnus.TextColor = Color.FromHex("#707070");

            BadgeListRoyk.IsVisible = true;
            BadgeListSnus.IsVisible = false;
        }

        void SetButtonsByCarousel(int position)
        {
            switch (position)
            {
                case 0:
                    SetCarouselButtonsToRoyk();
                    break;
                case 1:
                    SetCarouselToSnus();
                    break;
            }
        }

        void OnCarouselViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (sender is CarouselView carousel)
            {
                var pos = carousel.Position;
                if (_lastCenterIndex != pos)
                {
                    _lastCenterIndex = pos;
                    SetButtonsByCarousel(pos);
                    if (sender == timerCarousel)
                    {
                        savingsCarousel.Position = pos;
                    }
                    else if (sender == savingsCarousel)
                    {
                        timerCarousel.Position = pos;
                    }
                }
            }
        }

        async void GoToHelp(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("help_bigbutton");
            await Shell.Current.GoToAsync("//help");
        }

        async void GoToSettings(object sender, EventArgs e) => await Shell.Current.GoToAsync("//profile");

        async void GoToBadges(object sender, EventArgs e)
        {
            AnalyticsHelper.Send("badges_viewed");
            await Navigation.PushModalAsync(new NavigationPage(new BadgePage()));
        }

        public void Badge_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                if (e.CurrentSelection.First() is Badge badge && badge.IsActive)
                {
                    Navigation.PushModalAsync(new NavigationPage(new BadgePage(badge))
                    {
                        BarBackgroundColor = Color.FromHex(badge.backgroundcolor)
                    });
                }
                var collection = (CollectionView)sender;
                collection.SelectedItem = null;
            }
        }

        bool TheyQuitThisToday(Stoff stoff) => stoff.IsActive && (stoff.QuitDate == DateTime.Now.Date);

        void MaybeShowFirstDayNotif(UserData userData)
        {
            const string snusAndSmokeMsg = "Hei! Det at du har valgt å slutte vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil vi fortelle deg litt om i meldingene du mottar på mobilen din i tiden fremover. Lykke til!";
            const string smokeMsg = "Hei! Det at du har valgt å slutte å røyke, vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil du få vite mer om i meldingene du mottar på din mobil fremover. Lykke til! Å slutte å røyke er det viktigste du gjør for helsen din.";
            const string snusMsg = "Hei! Det at du har valgt å slutte å snuse vil påvirke kroppen din og livet ditt positivt på flere måter enn du tror. Dette vil vi fortelle deg litt om i meldingene du mottar på mobilen din i tiden fremover. Lykke til!";

            var smokeStoff = userData.StoffList[0];
            var snusStoff = userData.StoffList[1];
            var theyQuitSmokingToday = TheyQuitThisToday(smokeStoff);
            var theyQuitSnusToday = TheyQuitThisToday(snusStoff);

            if (theyQuitSmokingToday && theyQuitSnusToday)
            {
                string msg;
                if (smokeStoff.HaveShownFirstDayPopup && snusStoff.HaveShownFirstDayPopup)
                {
                    return;
                }
                if (!smokeStoff.HaveShownFirstDayPopup && !snusStoff.HaveShownFirstDayPopup)
                {
                    msg = snusAndSmokeMsg;
                }
                else if (!smokeStoff.HaveShownFirstDayPopup)
                {
                    msg = smokeMsg;
                }
                else
                {
                    msg = snusMsg;
                }
                Popup.IsVisible = true;
                PopupMsg.Text = msg;
                smokeStoff.HaveShownFirstDayPopup = true;
                snusStoff.HaveShownFirstDayPopup = true;
                SaveStoffFromUserData(userData);
            }
            else if (theyQuitSmokingToday)
            {
                if (!smokeStoff.HaveShownFirstDayPopup)
                {
                    Popup.IsVisible = true;
                    PopupMsg.Text = smokeMsg;
                    smokeStoff.HaveShownFirstDayPopup = true;
                    SaveStoffFromUserData(userData);
                }
            }
            else if (theyQuitSnusToday)
            {
                if (!snusStoff.HaveShownFirstDayPopup)
                {
                    Popup.IsVisible = true;
                    PopupMsg.Text = snusMsg;
                    snusStoff.HaveShownFirstDayPopup = true;
                    SaveStoffFromUserData(userData);
                }
            }
        }

        void SaveStoffFromUserData(UserData userData)
        {
            var stoffJsonString = JsonConvert.SerializeObject(userData.StoffList);
            File.WriteAllText(StoffService.StoffFilePath, stoffJsonString);
        }

        void CollapseDropdown()
        {
            if (!_collapseDropdownHasRun)
            {
                _collapseDropdownHasRun = true;
                QuickMenuPullLayout.TranslationY = -109;
            }
        }

        void InitializeDropdownRecognisers()
        {
            if (!_panGestureInitialized)
            {
                _panGestureInitialized = true;
                _panGesture.PanUpdated -= CheckQuickMenuPullOutGesture;
                _panGesture.PanUpdated += CheckQuickMenuPullOutGesture;

                QuickMenuInnerLayout.GestureRecognizers.Add(_panGesture);
                QuickMenuBaseLayout.GestureRecognizers.Add(_panGesture);
            }
        }

        void CheckQuickMenuPullOutGesture(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    QuickMenuPullLayout.TranslationY =
                        Clamp(QuickMenuPullLayout.TranslationY + e.TotalY, min: -109, max: 100);
                    break;

                case GestureStatus.Completed:
                    var y = QuickMenuPullLayout.TranslationY;
                    if (y != -109 && y != 100)
                    {
                        var halfway = -109 + ((100 - -109) * 0.5);
                        if (y > halfway)
                        {
                            QuickMenuPullLayout.TranslateTo(0, 100);
                        }
                        else
                        {
                            QuickMenuPullLayout.TranslateTo(0, -109);
                        }

                    }
                    AnalyticsHelper.Send("use_dragdown");
                    break;
                case GestureStatus.Canceled:
                    break;
            }
        }

        static double Clamp(double value, double min, double max) => Math.Min(Math.Max(min, value), max);
    }
}
