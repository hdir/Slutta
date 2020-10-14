using SluttaShell;
using SluttaShell.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppShell), typeof(ShellTitleOverride))]
namespace SluttaShell.iOS
{
    public class ShellTitleOverride : ShellRenderer
    {
        protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
        {
            return new CustomShellNavBarAppearanceTracker();
        }
    }

    public class CustomShellNavBarAppearanceTracker : IShellNavBarAppearanceTracker
    {
        public void Dispose() {}

        public void ResetAppearance(UINavigationController controller) =>
            controller.NavigationBar.PrefersLargeTitles = true;

        public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
        {
            var myColor =  Color.FromHex("#f0f0f0").ToUIColor();
            var navBar = controller.NavigationBar;

            navBar.Layer.BackgroundColor = myColor.CGColor;
        }

        public void SetHasShadow(UINavigationController controller, bool hasShadow)
        {
            var navigationBar = controller.NavigationBar;

            if (hasShadow)
            {
                navigationBar.Layer.ShadowColor = UIColor.Black.CGColor;
                navigationBar.Layer.ShadowOpacity = 0.0f;
            }
            else
            {
                navigationBar.Layer.ShadowColor = UIColor.Red.CGColor;
                navigationBar.Layer.ShadowOpacity = 0;
            }
        }

        public void UpdateLayout(UINavigationController controller) {}
    }
}
