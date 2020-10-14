using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SluttaShell
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            AnalyticsHelper.Send("use_active");
            InitializeComponent();
        }
    }

}
