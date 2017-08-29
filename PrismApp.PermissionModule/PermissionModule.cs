using Microsoft.Practices.Unity;

using Prism.Modularity;
using Prism.Unity;
using PrismApp.PermissionModule.Views;

using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismApp.PermissionModule
{
	public class PermissionModule : IModule
	{
		readonly IUnityContainer _unityContainer;
		public PermissionModule(IUnityContainer unityContainer)
		{
			_unityContainer = unityContainer;
		}

		public void Initialize()
		{
			_unityContainer.RegisterTypeForNavigation<NewTalkPage>();
		}
	}
}
