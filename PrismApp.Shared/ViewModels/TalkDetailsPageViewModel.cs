namespace PrismApp.Shared.ViewModels
{
	public class TalkDetailsPageViewModel : BaseViewModel
	{
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
		public TalkDetailsPageViewModel()
		{
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
