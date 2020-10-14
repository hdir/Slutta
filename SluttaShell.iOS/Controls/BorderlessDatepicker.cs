using System.ComponentModel;
using SluttaShell.Controls;
using SluttaShell.Controls.iOS.Renderers;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRenderer))]
namespace SluttaShell.Controls.iOS.Renderers
{
    public class BorderlessDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 4;
                Control.Layer.BorderColor = UIColor.FromRGB(238, 233, 233).CGColor;
            }
        }
    }
}
