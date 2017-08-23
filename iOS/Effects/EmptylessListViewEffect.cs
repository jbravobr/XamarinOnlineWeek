using CoreGraphics;
using PrismApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(EmptylessListViewEffect), "EmptylessListViewEffect")]
namespace PrismApp.iOS
{
	public class EmptylessListViewEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			var EmptyView = new UIView(new CGRect()) { BackgroundColor = UIColor.Clear };
			((UITableView)Control).TableFooterView = EmptyView;
		}

		protected override void OnDetached()
		{
		}
	}
}