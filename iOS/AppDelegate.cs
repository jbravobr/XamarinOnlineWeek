using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;
using Xamarin.Forms;
using PrismApp.Shared;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("PrismApp")]
namespace PrismApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			UINavigationBar.Appearance.BarTintColor = Color.FromHex("#FE4614").ToUIColor();
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });

			global::Xamarin.Forms.Forms.Init();
			ImageCircleRenderer.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}