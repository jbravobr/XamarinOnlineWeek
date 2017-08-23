using System.Linq;
using System;
using System.Collections.ObjectModel;
using Prism.Services;
using Prism.Commands;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismApp.Shared.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
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
		/// Initializes a new instance of the <see cref="T:PrismApp.Shared.ViewModels.HomePageViewModel"/> class.
		/// </summary>
		/// <param name="pageDialogService">Page dialog service.</param>
		/// <param name="navigationService">Navigation service.</param>
		public HomePageViewModel(IPageDialogService pageDialogService, INavigationService navigationService)
		{
			_pageDialogService = pageDialogService;
			_navigationService = navigationService;

			ItemSelectedCmd = new DelegateCommand<Talk>(ItemSelected);
			Init();
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
	}
}
