using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using GameStoreWPF.Events.Adds;
using System.Windows;

namespace GameStoreWPF.ViewModels
{
	public class GameDetailsViewModel: Screen
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IVideoGameService _videoGameService;
		private readonly IAgeService _ageService;
		private readonly IConsoleService _consoleService;
		private readonly IPublicationService _publicationService;
		private readonly ITypeService _typeService;
		public int GameId { get; private set; }
		public string Action { get; private set; }

		public BindableCollection<ConsoleVideoGame> ConsoleVideoGames { get; set; } = new();
		public BindableCollection<VideoGameAge> VideoGameAges { get; set; } = new();
		public BindableCollection<PublicationYear> PublicationYears { get; set; } = new();
		public BindableCollection<VideoGameType> VideoGameTypes { get; set; } = new();

		private VideoGame _videoGameData;
		public VideoGame VideoGameData
		{
			get { return _videoGameData; }
			set 
			{ 
				_videoGameData = value;
				NotifyOfPropertyChange(() => VideoGameData);
			}
		}

		public GameDetailsViewModel(
			IEventAggregator eventAggregator,
			IAgeService ageService,
			IConsoleService consoleService,
			IPublicationService publicationService,
			ITypeService typeService, 
			IVideoGameService gameService) 
		{
			_eventAggregator = eventAggregator;
			_videoGameService = gameService;
			_ageService = ageService;
			_typeService = typeService;
			_consoleService = consoleService;
			_publicationService = publicationService;
		}

		public void SetGameId(int id)
		{
			GameId = id;
			NotifyOfPropertyChange(() => GameId);
		}

		public void SetAction(string action)
		{
			Action = action;
			NotifyOfPropertyChange(() => Action);
		}
		protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
		{
			await LoadVideoGameAsync();
			await LoadConsoleVideoGamesAsync();
			await LoadPublicationYearsAsync();
			await LoadVideoGameAgesAsync();
			await LoadVideoGameTypesAsync();
		}

		private async Task LoadVideoGameTypesAsync()
		{
			var videoGameTypes = await _typeService.GetVideoGameTypesAsync();
			VideoGameTypes.Clear();
			VideoGameTypes.AddRange(videoGameTypes);
		}

		private async Task LoadPublicationYearsAsync()
		{
			var publicationYears = await _publicationService.GetPublicationYearsAsync();
			PublicationYears.Clear();
			PublicationYears.AddRange(publicationYears);
		}

		private async Task LoadVideoGameAgesAsync()
		{
			var videoGameAges = await _ageService.GetVideoGameAgesAsync();
			VideoGameAges.Clear();
			VideoGameAges.AddRange(videoGameAges);
		}

		private async Task LoadConsoleVideoGamesAsync()
		{
			var consoleVideoGames = await _consoleService.GetConsoleVideoGamesAsync();
			ConsoleVideoGames.Clear();
			ConsoleVideoGames.AddRange(consoleVideoGames);
		}

		private async Task LoadVideoGameAsync()
		{
			if (Action == "update") VideoGameData = await _videoGameService.GetVideoGameAsync(GameId);
			else VideoGameData = new();
		}

		public async void Continue()
		{
			if(Action == "add")
			{
				await _videoGameService.CreateVideoGameAsync(VideoGameData);
				await _eventAggregator.PublishOnUIThreadAsync(new VideoGameAddedEvent(VideoGameData));
				MessageBox.Show("Game added successfully.");
				await TryCloseAsync();
			}
			else 
			{ 
				await _videoGameService.UpdateVideoGameAsync(VideoGameData);
				MessageBox.Show("Game updated successfully.");
			}
		}

		public async void Cancel()
		{
			await TryCloseAsync();
		}


	}
}
