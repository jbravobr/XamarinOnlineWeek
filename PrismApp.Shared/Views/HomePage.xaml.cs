using Xamarin.Forms;

namespace PrismApp.Shared.Views
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			//NavigationPage.SetHasNavigationBar(this, false);

			lstTalks.ItemSelected += (sender, e) => 
			{
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}