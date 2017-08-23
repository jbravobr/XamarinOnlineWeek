using PrismApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(BorderlessEntryEffect), "BorderlessEntryEffect")]
namespace PrismApp.iOS
{
	public class BorderlessEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			((UITextField)Control).Layer.BorderWidth = 0;
			((UITextField)Control).BorderStyle = UITextBorderStyle.None;
			((UITextField)Control).AutocapitalizationType = UITextAutocapitalizationType.None;
		}

		protected override void OnDetached()
		{
		}
	}
}
