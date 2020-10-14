using System;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage() => InitializeComponent();
        async void ReturnToProfil(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}
