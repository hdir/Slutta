using Android.Graphics;
using Android.OS;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using XColor = Xamarin.Forms.Color;

namespace SluttaShell.Droid.Controls
{
    public class MyTabLayoutAppearanceTracker : ShellTabLayoutAppearanceTracker
    {
        public MyTabLayoutAppearanceTracker(IShellContext shellContext) : base(shellContext) {}

        protected override void SetColors(TabLayout tabLayout, XColor foreground, XColor background, XColor title, XColor unselected)
        {
            base.SetColors(tabLayout, foreground, background, title, unselected);

            tabLayout.SetPadding(0, 0, 0, 0);
            tabLayout.SetMinimumHeight(300);
        }
    }
}
