using System;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class SnusInnholdPage : ContentPage
    {
        public SnusInnholdPage() => InitializeComponent();
        async void ReturnToProfil(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}

