using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class PersonvernPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public PersonvernPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void ReturnToProfil(object sender, EventArgs e) => await Navigation.PopModalAsync();

        public void SendEmail() => SendEmail("SUBJECT", "", "kontaktslutta@helsedir.no");

        async Task SendEmail(string subject, string body, string recipient)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = new List<string>() { recipient },
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}
