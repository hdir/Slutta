using Android.Content;
using SluttaShell.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(MyShellRenderer))]
namespace SluttaShell.Droid.Controls
{
    public class MyShellRenderer : ShellRenderer
    {
        public MyShellRenderer(Context context) : base(context) {}

        protected override IShellTabLayoutAppearanceTracker CreateTabLayoutAppearanceTracker(ShellSection shellSection) =>
            new MyTabLayoutAppearanceTracker(this);
    }
}
