using Prism.Unity;
using PrismApp.Shared.ViewModels;
using PrismApp.Shared.Views;
using Prism.Modularity;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System;

namespace PrismApp.Shared
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : PrismApplication
	{
		public App() { }

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

		// CONFIGURAÇÃO PARA REGISTRAR OS MÓDULOS EXISTENTES
		protected override void ConfigureModuleCatalog()
		{
			Type sampleModuleType = typeof(PrismApp.PermissionModule.PermissionModule);
			ModuleCatalog.AddModule(
			  new ModuleInfo()
			  {
				  ModuleName = sampleModuleType.Name,
				  ModuleType = sampleModuleType,
				  InitializationMode = InitializationMode.OnDemand
			  });
		}
	}
}