using Prism.Unity;
using PrismApp.Shared.ViewModels;
using PrismApp.Shared.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;

namespace PrismApp.Shared
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : PrismApplication
	{
		public App(){}

		protected override void OnInitialized()
		{
			InitializeComponent();

			// INICIANDO NAVEGAÇÃO POR URI
			NavigationService.NavigateAsync(new Uri("http://www.myapp.com/MainPage", UriKind.Absolute));

			// INICIANDO NAVEGAÇÃO POR STRING -- MAGIC STRINGS --
			//NavigationService.NavigateAsync("MainPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
			Container.RegisterTypeForNavigation<HomePage, HomePageViewModel>();
			Container.RegisterTypeForNavigation<TalkDetailsPage, TalkDetailsPageViewModel>();
			Container.RegisterTypeForNavigation<NavigationPage>();
		}
	}
}