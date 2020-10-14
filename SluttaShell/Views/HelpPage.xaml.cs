using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using SluttaShell.Services;

namespace SluttaShell.Views
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage() => InitializeComponent();

        protected override void OnAppearing()
        {
            base.OnAppearing();

            HelpPageScrollView.ScrollToAsync(0, 0, true);

            var helpData = HelpDataService.GetHelp();
            BindingContext = helpData;

            // generate random tip for the page-load
            Random rnd = new Random();
            var randomTipIndex = rnd.Next(0, helpData.TipsList.Count);
            Tips_Title.Text = helpData.TipsList[randomTipIndex].Title;
            Tips_Desc.Text = helpData.TipsList[randomTipIndex].Description;
        }

        public void HelpTool_Selected(object sender, EventArgs e)
        {
            var helpItem = helpToolsCarousel.CurrentItem as Services.HelpTools;
            if (helpItem.Title == "Snakk med en venn")
            {
                AnalyticsHelper.Send("help_snakkmedvenn");
            }
            else if (helpItem.Title == "Bruk legemidler")
            {
                AnalyticsHelper.Send("help_legemidler");
            }
            else if (helpItem.Title == "Aktivitet")
            {
                AnalyticsHelper.Send("help_aktivitet");
            }
            else if (helpItem.Title == "Sprukket")
            {
                AnalyticsHelper.Send("help_sos");
            }
            Navigation.PushModalAsync(new NavigationPage(new HelpDetailPage(helpItem)) { });
        }
    }
}
