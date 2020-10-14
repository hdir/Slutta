using System.IO;
using Android.Graphics;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SluttaShell.Droid
{
    public class ScreenshotService : IScreenshotService
    {
        static (Android.Views.View, Size, float) ConvertFormsToNative(Xamarin.Forms.View view)
        {
            var size = view.Bounds.Size;
            var width = (int)size.Width;
            var height = (int)size.Height;
            var density = Android.App.Application.Context.Resources.DisplayMetrics.Density;

            var vRenderer = Platform.CreateRendererWithContext(view, Android.App.Application.Context);
            var aview = vRenderer.View;

            aview.LayoutParameters = new ViewGroup.LayoutParams(width, height);
            vRenderer.Tracker.UpdateLayout();
            view.Layout(new Rectangle(0, 0, width, height));
            aview.Layout(0, 0, width, height);
            vRenderer.Tracker.UpdateLayout();

            return (aview, size, density);
        }

        public byte[] Capture(Xamarin.Forms.View view, Rectangle size)
        {
            var (aview, actualSize, density) = ConvertFormsToNative(view);
            var scaledActualSize = actualSize * density;

            // I'm damn sure there is a better way of doing this but my brain
            // refuses to cooperate so we have this :|
            var finalWidth = actualSize.Width;
            var finalHeight = actualSize.Height;
            finalHeight *= (size.Width / finalWidth);
            finalWidth = size.Width;
            finalWidth *= (size.Height / finalHeight);
            finalHeight = size.Height;

            using (var screenshot = Bitmap.CreateBitmap(
                                    (int)scaledActualSize.Width,
                                    (int)scaledActualSize.Height,
                                    Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);
                canvas.DrawColor(Android.Graphics.Color.White);
                aview.Draw(canvas);

                using (var stream = new MemoryStream())
                {
                    var scaledBitmap = Bitmap.CreateScaledBitmap(screenshot, (int)finalWidth, (int)finalHeight, filter: true);
                    scaledBitmap.Compress(Bitmap.CompressFormat.Png, 90, stream);
                    var bytes = stream.ToArray();
                    return bytes;
                }
            }
        }
    }
}
