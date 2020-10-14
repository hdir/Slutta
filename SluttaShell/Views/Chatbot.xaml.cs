using System;
using Xamarin.Forms;

namespace SluttaShell.Views
{
    public partial class Chatbot : ContentPage
    {
        public Chatbot() => InitializeComponent();
        async void ReturnToProfil(object sender, EventArgs e) => await Navigation.PopModalAsync();
    }
}
