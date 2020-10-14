using System.ComponentModel;
using SluttaShell.Controls;
using SluttaShell.Controls.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(BorderlessPickerRenderer))]
namespace SluttaShell.Controls.iOS.Renderers
{
    public class BorderlessPickerRenderer : PickerRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // we need this null check as OnElementPropertyChanged is called on Dispose of the UI element
            // and when that happens Control is already null
            if (Control != null)
            {
                Control.Layer.BorderWidth = 4;
                Control.Layer.BorderColor = UIColor.FromRGB(238, 233, 233).CGColor;
            }
        }
    }
}
