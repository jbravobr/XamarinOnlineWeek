using Prism.Mvvm;
using Prism.Navigation;

namespace PrismApp.Shared.ViewModels
{
	public class BaseViewModel : BindableBase, INavigationAware
	{
		public BaseViewModel()
		{
		}

		/// <summary>
		/// Ons the navigated from.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		/// <summary>
		/// Ons the navigated to.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatedTo(NavigationParameters parameters)
		{

		}

		/// <summary>
		/// Ons the navigating to.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public virtual void OnNavigatingTo(NavigationParameters parameters)
		{

		}
	}
}