using System;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class SnusHelsegevinsterPage : ContentPage
    {
        public SnusHelsegevinsterPage() => InitializeComponent();
        async void ReturnToProfil(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}
