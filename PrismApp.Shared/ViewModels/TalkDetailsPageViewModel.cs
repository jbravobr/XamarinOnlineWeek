using System.Threading.Tasks;
using Prism.Events;
using Prism.Services;
using PrismApp.Domain;

namespace PrismApp.Shared.ViewModels
{
	public class TalkDetailsPageViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets the ea.
		/// </summary>
		/// <value>The ea.</value>
		IEventAggregator _ea { get; }

		/// <summary>
		/// Gets the page dialog service.
		/// </summary>
		/// <value>The page dialog service.</value>
		IPageDialogService _pageDialogService { get; }

		/// <summary>
		/// The talk.
		/// </summary>
		Talk _talk;
		public Talk Talk
		{
			get { return _talk; }
			set { SetProperty(ref _talk, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PrismApp.Shared.ViewModels.TalkDetailsPageViewModel"/> class.
		/// </summary>
		/// <param name="ea">Ea.</param>
		/// <param name="pageDialogeService">Page dialoge service.</param>
		public TalkDetailsPageViewModel(IEventAggregator ea,
										IPageDialogService pageDialogeService)
		{
			_ea = ea;
			_pageDialogService = pageDialogeService;
			_ea.GetEvent<BaseEvent>().Publish($"Não esqueça de se inscrever no site http://xoweek.online !");
		}

		/// <summary>
		/// Ons the navigating to.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public override void OnNavigatingTo(Prism.Navigation.NavigationParameters parameters)
		{
			if (parameters.ContainsKey("Talk"))
				Talk = parameters["Talk"] as Talk;
		}
	}
}
