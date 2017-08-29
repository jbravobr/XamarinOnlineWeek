using System.Linq;
using System;
using System.Collections.ObjectModel;
using Prism.Services;
using Prism.Commands;
using System.Threading.Tasks;
using Prism.Navigation;
using PrismApp.Domain;
using Prism.AppModel;
using System.Collections.Generic;
using Prism.Events;

namespace PrismApp.Shared.ViewModels
{
	public class HomePageViewModel : BaseViewModel, IApplicationStore
	{
		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <value>The properties.</value>
		public IDictionary<string, object> Properties => Xamarin.Forms.Application.Current.Properties;

		/// <summary>
		/// Gets the page dialog service.
		/// </summary>
		/// <value>The page dialog service.</value>
		IPageDialogService _pageDialogService { get; }

		/// <summary>
		/// Gets the navigation service.
		/// </summary>
		/// <value>The navigation service.</value>
		INavigationService _navigationService { get; }

		/// <summary>
		/// Gets the ea.
		/// </summary>
		/// <value>The ea.</value>
		IEventAggregator _ea { get; }

		/// <summary>
		/// Gets or sets the talks.
		/// </summary>
		/// <value>The talks.</value>
		public ObservableCollection<Grouping<string, Talk>> Talks { get; set; }

		/// <summary>
		/// Gets the item selected cmd.
		/// </summary>
		/// <value>The item selected cmd.</value>
		public DelegateCommand<Talk> ItemSelectedCmd { get; private set; }

		/// <summary>
		/// Gets the add cmd.
		/// </summary>
		/// <value>The add cmd.</value>
		public DelegateCommand AddCmd { get; private set; }

		/// <summary>
		/// Gets the exit cmd.
		/// </summary>
		/// <value>The exit cmd.</value>
		public DelegateCommand ExitCmd { get; private set; }

		/// <summary>
		/// Is the sample module registered.
		/// </summary>
		/// <returns><c>true</c>, if sample module registered was ised, <c>false</c> otherwise.</returns>
		bool IsSampleModuleRegistered() => Properties.ContainsKey("IsSampleModuleRegistered");

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PrismApp.Shared.ViewModels.HomePageViewModel"/> class.
		/// </summary>
		/// <param name="pageDialogService">Page dialog service.</param>
		/// <param name="navigationService">Navigation service.</param>
		public HomePageViewModel(IPageDialogService pageDialogService,
								 INavigationService navigationService,
								 IEventAggregator ea)
		{
			_pageDialogService = pageDialogService;
			_navigationService = navigationService;
			_ea = ea;
			_ea.GetEvent<BaseEvent>().Subscribe(async (msg) => await ShowMessageFromEventAggregator(msg));

			ItemSelectedCmd = new DelegateCommand<Talk>(ItemSelected);
			AddCmd = new DelegateCommand(Add, IsSampleModuleRegistered);

			Init();
		}

		/// <summary>
		/// Shows the message from event aggregator.
		/// </summary>
		/// <returns>The message from event aggregator.</returns>
		/// <param name="message">Message.</param>
		async Task ShowMessageFromEventAggregator(string message)
		{
			await _pageDialogService.DisplayAlertAsync("Aviso", message, "OK");
		}

		/// <summary>
		/// Gets the exit.
		/// </summary>
		/// <value>The exit.</value>
		Action Exit
		{
			get
			{
				return new Action(async () => await _navigationService.NavigateAsync(new Uri("http://www.myapp.com/MainPage", UriKind.Absolute)));
			}
		}

		/// <summary>
		/// Gets the add.
		/// </summary>
		/// <value>The add.</value>
		Action Add
		{
			get
			{
				return new Action(async () => await NavigateToModulePage("NewTalkPage"));
			}
		}

		/// <summary>
		/// Gets the item selected.
		/// </summary>
		/// <value>The item selected.</value>
		Action<Talk> ItemSelected
		{
			get
			{
				return new Action<Talk>(async (talk) =>
				{
					if (talk == null)
					{
						await _pageDialogService.DisplayAlertAsync("Erro", "Houve um problema com o item selecionado.", "OK");
						return;
					}

					await NavigateToDetails("TalkDetailsPage", talk);
				});
			}
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		void Init()
		{
			GetSortedTalks();
		}

		/// <summary>
		/// Gets the sorted talks.
		/// </summary>
		void GetSortedTalks()
		{
			var list = TalkHelper.GetTalks;

			var sorted = from talk in list
						 orderby talk.Time
						 group talk by talk.Day into talkGroup
						 select new Grouping<string, Talk>(talkGroup.Key, talkGroup);

			Talks = new ObservableCollection<Grouping<string, Talk>>(sorted);
		}

		/// <summary>
		/// Navigates to details.
		/// </summary>
		/// <returns>The to details.</returns>
		/// <param name="page">Page.</param>
		/// <param name="talk">Talk.</param>
		async Task NavigateToDetails(string page, Talk talk)
		{
			// CRIAÇÃO DE PARÂMETROS PARA NAVEGAÇÃO
			var navParameters = new NavigationParameters
			{
				{"Talk", talk}
			};

			await _navigationService.NavigateAsync(page, navParameters);
		}

		/// <summary>
		/// Navigates to module page.
		/// </summary>
		/// <param name="page">Page.</param>
		/// <param name="obj">Object.</param>
		async Task NavigateToModulePage(string page)
		{
			// CRIAÇÃO DE PARÂMETROS PARA NAVEGAÇÃO
			var navParameters = new NavigationParameters
			{
				{"AuthenticatedUser", (string)Properties["AuthenticatedUser"]},
				{"Title","Nova Palestra"}
			};

			await _navigationService.NavigateAsync(page, navParameters);
		}

		public Task SavePropertiesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
