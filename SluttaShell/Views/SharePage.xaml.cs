using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using SluttaShell.Services;

namespace SluttaShell.Views
{
    public partial class SharePage : ContentPage
    {
        static int _currentTimerId = 1;
        static BadgeInfo _badgeInfo;

        readonly string _shareTmpFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "shareFile.png");
        bool _captureCompleted;

        public SharePage()
        {
            InitializeComponent();
            _badgeInfo = BadgeService.GetBadges();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_captureCompleted)
            {
                _captureCompleted = false;
                Navigation.PopModalAsync();
                return;
            }

            var stoffList = StoffService.GetStoff();
            var userData = new UserData()
            {
                StoffList = stoffList, BadgeInfo = BadgeInfo.GetFiltered(_badgeInfo, stoffList)
            };
            BindingContext = userData;

            ScheduleCapture(userData);

            if (stoffList[0].IsActive != stoffList[1].IsActive)
            {
                ShareContentBoth.IsVisible = false;
                if (stoffList[0].IsActive) {
                    ShareContentSmoke.IsVisible = true;
                    ShareContentSnus.IsVisible = false;
                }
                else
                {
                    ShareContentSmoke.IsVisible = false;
                    ShareContentSnus.IsVisible = true;
                }
                ShareContent.HeightRequest = 200;
            }
            else
            {
                ShareContentBoth.IsVisible = true;
                ShareContentSmoke.IsVisible = false;
                ShareContentSnus.IsVisible = false;
                ShareContent.HeightRequest = 400;
            }

            WaitAndTakeScreenshot();
        }

        static void ScheduleCapture(UserData userData)
        {
            _currentTimerId += 1;
            var timersOwnId = _currentTimerId; // this variable is captured by the timer's closure

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
                });

                return true;
            });
        }

        async void WaitAndTakeScreenshot()
        {
            base.OnAppearing();

            await Task.Delay(1000);

            _captureCompleted = true;

            var screenshotData = DependencyService.Get<IScreenshotService>().Capture(ShareContent, new Rectangle(0, 0, 600, 600));

            File.WriteAllBytes(_shareTmpFilePath, screenshotData);

            await Share.RequestAsync(new ShareFileRequest()
            {
                File = new ShareFile(_shareTmpFilePath),
                Title = "Share Text"
            });
        }

        async void ReturnHome(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
