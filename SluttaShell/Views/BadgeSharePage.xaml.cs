using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace SluttaShell.Views
{
    public partial class BadgeSharePage : ContentPage
    {
        readonly string _shareTmpFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "shareFile.png");
        bool _captureCompleted;

        public BadgeSharePage() => InitializeComponent();

        public BadgeSharePage(Services.Badge badge)
        {
            InitializeComponent();
            BindingContext = badge;
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
            WaitAndTakeScreenshot();
        }

        async void WaitAndTakeScreenshot()
        {
            base.OnAppearing();

            await Task.Delay(1000);

            _captureCompleted = true;

            var testView = ShareContent;
            var screenshotData = DependencyService.Get<IScreenshotService>().Capture(testView, new Rectangle(0, 0, 380, 520));

            File.WriteAllBytes(_shareTmpFilePath, screenshotData);

            await Share.RequestAsync(new ShareFileRequest()
            {
                File = new ShareFile(_shareTmpFilePath),
                Title = "Share Text"
            });
        }

        async void ReturnHome(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}
