using Xamarin.Forms;

namespace SluttaShell
{
    public interface IScreenshotService
    {
        byte[] Capture(View view, Rectangle size);
    }
}
