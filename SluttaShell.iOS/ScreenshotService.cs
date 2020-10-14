using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(SluttaShell.iOS.ScreenshotService))]
namespace SluttaShell.iOS
{
    public class ScreenshotService : IScreenshotService
    {
        public byte[] Capture(View view, Rectangle rect)
        {
            var (nativeView, nativeRect) = GetUiViewFromXamarinView(view, rect);
            return UiViewToPng(nativeView, nativeRect.Size);
        }

        static (UIView, CGRect) GetUiViewFromXamarinView(Xamarin.Forms.View view, Rectangle size)
        {
            var renderer = Platform.CreateRenderer(view);
            var rect = new CGRect(size.X, size.Y, size.Width, size.Height);
            renderer.NativeView.Frame = rect;

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout(size);

            var nativeView = renderer.NativeView;

            nativeView.SetNeedsLayout();

            return (nativeView, rect);
        }

        static byte[] UiViewToPng(UIView view, CGSize size)
        {
            UIGraphics.BeginImageContext(size);
            view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            var viewImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            var data = viewImage.AsPNG();
            return data.ToArray();
        }
    }
}
