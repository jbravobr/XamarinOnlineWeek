using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Modularity;
using Prism.AppModel;

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Prism.Events;

namespace PrismApp.Shared.ViewModels
{
	public class MainPageViewModel : BindableBase, IApplicationStore
	{
		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <value>The properties.</value>
		public IDictionary<string, object> Properties => Xamarin.Forms.Application.Current.Properties;

		/// <summary>
		/// The username.
		/// </summary>
		string _username;
		public string Username
		{
			get { return _username; }
			set { SetProperty(ref _username, value); }
		}

		/// <summary>
		/// The password.
		/// </summary>
		string _password;
		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		/// <summary>
		/// Gets the logon cmd.
		/// </summary>
		/// <value>The logon cmd.</value>
		public DelegateCommand LogonCmd { get; private set; }

		/// <summary>
		/// Gets the navigation service.
		/// </summary>
		/// <value>The navigation service.</value>
		INavigationService _navigationService { get; }

		/// <summary>
		/// Gets the page dialog service.
		/// </summary>
		/// <value>The page dialog service.</value>
		IPageDialogService _pageDialogService { get; }

		/// <summary>
		/// Gets the module manager.
		/// </summary>
		/// <value>The module manager.</value>
		IModuleManager _moduleManager { get; }

		/// <summary>
		/// Logins the command can execute.
		/// </summary>
		/// <returns><c>true</c>, if command can execute was logined, <c>false</c> otherwise.</returns>
		bool LoginCommandCanExecute() =>
			!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PrismApp.Shared.ViewModels.MainPageViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		/// <param name="pageDialogService">Page dialog service.</param>
		public MainPageViewModel(INavigationService navigationService,
								 IPageDialogService pageDialogService,
		                         IModuleManager moduleManager)
		{
			_navigationService = navigationService;
			_pageDialogService = pageDialogService;
			_moduleManager = moduleManager;

			if (Properties != null && Properties.Any())
				Properties.Clear();

			// CONTROLANDO EXECUÇÃO ATRAVES DE UM MÉTODO E POR OBSERVAÇÃO DE PROPRIEDADES
			LogonCmd = new DelegateCommand(Logon, LoginCommandCanExecute)
				.ObservesProperty(() => Username)
				.ObservesProperty(() => Password);
		}

		/// <summary>
		/// Gets the logon.
		/// </summary>
		/// <value>The logon.</value>
		Action Logon
		{
			get
			{
				return new Action(async () => await VerifyUserInfo());
			}
		}

		/// <summary>
		/// Verifies the user info.
		/// </summary>
		public async Task VerifyUserInfo()
		{
			try
			{
				if (Username == "admin" && Password == "admin") // ACESSO COM ADMIN LOGO IREI CARREGAR O MÓDULO DE PERMISSAO
				{
					LoadPermissionModule();

					// NAVEGAÇÃO ABSOLUTA POR URI
					await NavigateTo(new Uri("http://www.myapp.com/NavigationPage/HomePage", UriKind.Absolute));

					// NAVEGAÇÃO ABSOLUTA POR STRING -- MAGIC STRINGS --
					//await NavigateTo("app:///NavigationPage/HomePage");
				}
				else if (Username == "user" && Password == "user") // ACESSO SEM USUÁRIO ADMIN NÃO FAÇO O CARREGAMENTO
				{
					// NAVEGAÇÃO ABSOLUTA POR URI
					await NavigateTo(new Uri("http://www.myapp.com/NavigationPage/HomePage", UriKind.Absolute));

					// NAVEGAÇÃO ABSOLUTA POR STRING -- MAGIC STRINGS --
					//await NavigateTo("app:///NavigationPage/HomePage");	
				}
				else if (Username != "admin" || (Username == "admin" && Password != "admin"))
				{
					await _pageDialogService.DisplayAlertAsync("Erro", "Usuário/Senha inválido.", "OK");
				}
				else if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
				{
					await _pageDialogService.DisplayAlertAsync("Erro", "Você precisa informar seus dados.", "OK");
				}
			}
			catch (Exception ex)
			{
				await _pageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
			}
		}

		/// <summary>
		/// Loads the permission module.
		/// </summary>
		void LoadPermissionModule()
		{
			_moduleManager.LoadModule("PermissionModule");
			SavePropertiesAsync();
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <param name="page">Page.</param>
		async Task NavigateTo(string page)
		{
			try
			{
				await _navigationService.NavigateAsync(page);
			}
			catch (Exception ex)
			{
				await _pageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
			}
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="uri">URI.</param>
		async Task NavigateTo(Uri uri)
		{
			try
			{
				await _navigationService.NavigateAsync(uri);
			}
			catch (Exception ex)
			{
				await _pageDialogService.DisplayAlertAsync("Erro", ex.Message, "OK");
			}
		}

		public async Task SavePropertiesAsync()
		{
			Properties.Add("IsSampleModuleRegistered", true);
			Properties.Add("AuthenticatedUser", Username);
		}
	}
}
