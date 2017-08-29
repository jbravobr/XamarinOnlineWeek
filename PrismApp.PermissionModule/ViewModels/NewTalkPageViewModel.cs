using System;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismApp.PermissionModule.ViewModels
{
	public class NewTalkPageViewModel : BindableBase, INavigationAware
	{
		/// <summary>
		/// The title.
		/// </summary>
		string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		/// <summary>
		/// The user authenticated.
		/// </summary>
		string _authenticatedUser;
		public string AuthenticatedUser
		{
			get { return _authenticatedUser; }
			set { SetProperty(ref _authenticatedUser, value); }
		}

		/// <summary>
		/// Gets the page dialog service.
		/// </summary>
		/// <value>The page dialog service.</value>
		IPageDialogService _pageDialogService { get; }

		/// <summary>
		/// The image source.
		/// </summary>
		string imgSource;
		public string ImgSource
		{
			get
			{
				if (string.IsNullOrEmpty(imgSource))
					return "unknow.png";
				else
					return imgSource;
			}
			set { SetProperty(ref imgSource, value); }
		}

		/// <summary>
		/// The name of the speaker.
		/// </summary>
		string _speakerName;
		public string SpeakerName
		{
			get { return _speakerName; }
			set { SetProperty(ref _speakerName, value); }
		}

		/// <summary>
		/// The talk title.
		/// </summary>
		string _talkTitle;
		public string TalkTitle
		{
			get { return _talkTitle; }
			set { SetProperty(ref _talkTitle, value); }
		}

		/// <summary>
		/// The talk description.
		/// </summary>
		string _talkDescription;
		public string TalkDescription
		{
			get { return _talkDescription; }
			set { SetProperty(ref _talkDescription, value); }
		}

		/// <summary>
		/// Gets the image select cmd.
		/// </summary>
		/// <value>The image select cmd.</value>
		public DelegateCommand ImageSelectCmd { get; private set; }

		/// <summary>
		/// Gets the save cmd.
		/// </summary>
		/// <value>The save cmd.</value>
		public DelegateCommand SaveCmd { get; private set; }

		/// <summary>
		/// Ises the data filled.
		/// </summary>
		/// <returns><c>true</c>, if data filled was ised, <c>false</c> otherwise.</returns>
		bool IsDataFilled() => !string.IsNullOrWhiteSpace(SpeakerName) && !string.IsNullOrWhiteSpace(TalkTitle)
									  && !string.IsNullOrWhiteSpace(TalkDescription);

		/// <summary>
		/// Initializes a new instance of the <see cref="T:PrismApp.PermissionModule.ViewModels.NewTalkPageViewModel"/> class.
		/// </summary>
		public NewTalkPageViewModel(IPageDialogService pageDialogService)
		{
			_pageDialogService = pageDialogService;

			ImageSelectCmd = new DelegateCommand(ImageSelect);
			SaveCmd = new DelegateCommand(Save, IsDataFilled)
				.ObservesProperty(() => SpeakerName)
				.ObservesProperty(() => TalkTitle)
				.ObservesProperty(() => TalkDescription);
		}

		/// <summary>
		/// Gets the save.
		/// </summary>
		/// <value>The save.</value>
		Action Save
		{
			get
			{
				return new Action(async () =>
				{
					await _pageDialogService.DisplayAlertAsync("Aviso", "Palestra salva com sucesso", "OK");
				});
			}
		}

		/// <summary>
		/// Gets the image select.
		/// </summary>
		/// <value>The image select.</value>
		Action ImageSelect
		{
			get
			{
				return new Action(async () =>
				{
					await _pageDialogService.DisplayAlertAsync("Aviso", "Ação de selecionar imagem", "OK");
				});
			}
		}

		/// <summary>
		/// Ons the navigated from.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		/// <summary>
		/// Ons the navigated to.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("AuthenticatedUser"))
			{
				AuthenticatedUser = (string)parameters["AuthenticatedUser"];
				_pageDialogService.DisplayAlertAsync("Aviso", $"Acesso garantido ao usuário {AuthenticatedUser.ToUpper()}", "OK");
			}

			if (parameters.ContainsKey("Title"))
				Title = (string)parameters["Title"].ToString().Trim();
		}

		/// <summary>
		/// Ons the navigating to.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}

