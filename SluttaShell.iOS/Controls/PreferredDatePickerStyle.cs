using UIKit;
using Xamarin.Forms;
using SluttaShell.Controls.iOS.Renderers;

[assembly: ExportRenderer(typeof(DatePicker), typeof(DatePickerRenderer))]
namespace SluttaShell.Controls.iOS.Renderers
{
	public class DatePickerRenderer : Xamarin.Forms.Platform.iOS.DatePickerRenderer
	{
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);

			if (Control != null && UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
			{
				UIDatePicker picker = (UIDatePicker)Control.InputView;
				picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
			}
		}
	}
}
