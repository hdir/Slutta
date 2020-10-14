using UIKit;
using Xamarin.Forms;
using SluttaShell.Controls.iOS.Renderers;

[assembly: ExportRenderer(typeof(TimePicker), typeof(TimePickerRenderer))]
namespace SluttaShell.Controls.iOS.Renderers
{
	public class TimePickerRenderer : Xamarin.Forms.Platform.iOS.TimePickerRenderer
	{
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<TimePicker> e)
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
