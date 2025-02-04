using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using GameStoreWPF.Events.Adds;
using GameStoreWPF.Events.Updates;
using GameStoreWPF.Models;
using GameStoreWPF.Services.Interfaces;
using System.Windows;

namespace GameStoreWPF.ViewModels
{
	public class ShellViewModel: Screen, 
		IHandle<VideoGameAddedEvent>,
		IHandle<AgeAddedEvent>,
		IHandle<ConsoleAddedEvent>,
		IHandle<TypeAddedEvent>,
		IHandle<YearAddedEvent>,
		IHandle<AgeUpdatedEvent>,
		IHandle<ConsoleUpdatedEvent>,
		IHandle<TypeUpdatedEvent>,
		IHandle<YearUpdatedEvent>

	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IWindowManager _windowManager;
		private readonly IVideoGameService _videoGameService;
		private readonly IAgeService _ageService;
		private readonly IConsoleService _consoleService;
		private readonly IPublicationService _publicationService;
		private readonly ITypeService _typeService;
		
		
		public BindableCollection<ConsoleVideoGame> ConsoleVideoGames { get; set; } = new();
		public BindableCollection<VideoGameAge> VideoGameAges { get; set; } = new();
		public BindableCollection<PublicationYear> PublicationYears { get; set; } = new();
		public BindableCollection<VideoGameType> VideoGameTypes { get; set; } = new();
		public BindableCollection<VideoGame> VideoGames { get; set; } = new();


		private VideoGame _selectedGame;
		public VideoGame SelectedGame
		{
			get { return _selectedGame; }
			set 
			{ 
				_selectedGame = value; 
				NotifyOfPropertyChange(() => SelectedGame);
			}
		}

		private ConsoleVideoGame _selectedConsole;
		public ConsoleVideoGame SelectedConsole
		{
			get { return _selectedConsole; }
			set 
			{ 
				_selectedConsole = value; 
				NotifyOfPropertyChange(() => SelectedConsole);
				SearchParametersChanged();
			}
		}

		private PublicationYear _selectedYear;
		public PublicationYear SelectedYear
		{
			get { return _selectedYear; }
			set 
			{ 
				_selectedYear = value;
				NotifyOfPropertyChange(() => SelectedYear);
				SearchParametersChanged();
			}
		}

		private VideoGameAge _selectedAge;
		public VideoGameAge SelectedAge
		{
			get { return _selectedAge; }
			set 
			{ 
				_selectedAge = value;
				NotifyOfPropertyChange(() => SelectedAge);
				SearchParametersChanged();
			}
		}

		private VideoGameType _selectedType;
		public VideoGameType SelectedType
		{
			get { return _selectedType; }
			set 
			{ 
				_selectedType = value; 
				NotifyOfPropertyChange(() => SelectedType);
				SearchParametersChanged();
			}
		}


		public ShellViewModel(
			IEventAggregator eventAggregator,
			IWindowManager windowManager,
			IAgeService ageService, 
			IConsoleService consoleService, 
			IPublicationService publicationService, 
			ITypeService typeService, 
			IVideoGameService gameService)
		{
			_windowManager = windowManager;
			_ageService = ageService;
			_consoleService = consoleService;
			_publicationService = publicationService;
			_typeService = typeService;
			_videoGameService = gameService;
			_eventAggregator = eventAggregator;
			_eventAggregator.SubscribeOnPublishedThread(this);
		}

		protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
		{
			await LoadConsoleVideoGamesAsync();
			await LoadPublicationYearsAsync();
			await LoadVideoGameAgesAsync();
			await LoadVideoGamesAsync();
			await LoadVideoGameTypesAsync();
		}

		//
		public async Task HandleAsync(VideoGameAddedEvent message, CancellationToken cancellationToken)
		{
			if(message?.NewVideoGame != null) VideoGames.Add(message.NewVideoGame);
		}

		public async Task HandleAsync(AgeAddedEvent message, CancellationToken cancellationToken)
		{
			if (message?.NewAge != null) VideoGameAges.Add(message.NewAge);
		}

		public async Task HandleAsync(ConsoleAddedEvent message, CancellationToken cancellationToken)
		{
			if (message?.NewConsole != null) ConsoleVideoGames.Add(message.NewConsole);
		}

		public async Task HandleAsync(TypeAddedEvent message, CancellationToken cancellationToken)
		{
			if (message?.NewType != null) VideoGameTypes.Add(message.NewType);
		}

		public async Task HandleAsync(YearAddedEvent message, CancellationToken cancellationToken)
		{
			if (message?.NewYear != null) PublicationYears.Add(message.NewYear);
		}

		public async Task HandleAsync(AgeUpdatedEvent message, CancellationToken cancellationToken)
		{
			if (message?.UpdatedAge != null)
			{
				var existingAge = VideoGameAges.FirstOrDefault(a => a.Id == message.UpdatedAge.Id);
				if (existingAge != null)
				{
					existingAge.Age = message.UpdatedAge.Age;
					NotifyOfPropertyChange(() => VideoGameAges);
				}
			}
		}

		public async Task HandleAsync(ConsoleUpdatedEvent message, CancellationToken cancellationToken)
		{
			if(message?.UpdatedConsole != null)
			{
				var existingConsole = ConsoleVideoGames.FirstOrDefault(c => c.Id == message.UpdatedConsole.Id);
				if (existingConsole != null)
				{
					existingConsole.Name = message.UpdatedConsole.Name;
					NotifyOfPropertyChange(() => ConsoleVideoGames);
				}
			}
		}

		public async Task HandleAsync(TypeUpdatedEvent message, CancellationToken cancellationToken)
		{
			if(message?.UpdatedType != null)
			{
				var existingType = VideoGameTypes.FirstOrDefault(t => t.Id == message.UpdatedType.Id);
				if(existingType != null)
				{
					existingType.Type = message.UpdatedType.Type;
					NotifyOfPropertyChange(() => VideoGameTypes);
				}
			}
		}

		public async Task HandleAsync(YearUpdatedEvent message, CancellationToken cancellationToken)
		{
			if(message?.UpdatedYear != null)
			{
				var existingYear = PublicationYears.FirstOrDefault(y => y.Id == message.UpdatedYear.Id);
				if(existingYear != null)
				{
					existingYear.Year = message.UpdatedYear.Year;
					NotifyOfPropertyChange(() => PublicationYears);
				}
			}
		}

		protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
		{
			_eventAggregator.Unsubscribe(this);
			await base.OnDeactivateAsync(close, cancellationToken);
		}

		private async Task LoadVideoGamesAsync()
		{
			var videoGames = await _videoGameService.GetVideoGamesAsync();
			VideoGames.Clear();
			VideoGames.AddRange(videoGames);
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

		public async Task AddConsole()
		{
			var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
			consoleParameterViewModel.SetAction("add");
			consoleParameterViewModel.SetTable("console");
			await _windowManager.ShowWindowAsync(consoleParameterViewModel);
		}

		public async Task UpdateConsole()
		{
			if (SelectedConsole != null)
			{
				var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
				consoleParameterViewModel.SetAction("update");
				consoleParameterViewModel.SetTable("console");
				consoleParameterViewModel.SetParameterId(SelectedConsole.Id);
				await _windowManager.ShowWindowAsync(consoleParameterViewModel);
			}
			else MessageBox.Show("One console must be selected to update.");
			
		}

		public async Task DeleteConsole()
		{
			if (SelectedConsole != null)
			{
				var result = await _consoleService.DeleteConsoleVideoGameAsync(SelectedConsole.Id);
				if (result)
				{
					ConsoleVideoGames.Remove(SelectedConsole);
					MessageBox.Show("Console deleted successfully.");
				}
				else MessageBox.Show("Failed to delete the console.");
			}
			else MessageBox.Show("One console must be selected to delete.");
		}

		public async Task AddYear()
		{
			var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
			consoleParameterViewModel.SetAction("add");
			consoleParameterViewModel.SetTable("year");
			await _windowManager.ShowWindowAsync(consoleParameterViewModel);
		}

		public async Task UpdateYear()
		{
			if (SelectedYear != null)
			{
				var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
				consoleParameterViewModel.SetAction("update");
				consoleParameterViewModel.SetTable("year");
				consoleParameterViewModel.SetParameterId(SelectedYear.Id);
				await _windowManager.ShowWindowAsync(consoleParameterViewModel);
			}
			else MessageBox.Show("One year must be selected to update.");

		}

		public async Task DeleteYear()
		{
			if (SelectedYear != null)
			{
				var result = await _publicationService.DeletePublicationYearAsync(SelectedYear.Id);
				if (result)
				{
					PublicationYears.Remove(SelectedYear);
					MessageBox.Show("Year deleted successfully.");
				}
				else MessageBox.Show("Failed to delete the year.");
			}
			else MessageBox.Show("One year must be selected to delete.");
		}

		public async Task AddType()
		{
			var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
			consoleParameterViewModel.SetAction("add");
			consoleParameterViewModel.SetTable("type");
			await _windowManager.ShowWindowAsync(consoleParameterViewModel);
		}

		public async Task UpdateType()
		{
			if (SelectedType != null)
			{
				var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
				consoleParameterViewModel.SetAction("update");
				consoleParameterViewModel.SetTable("type");
				consoleParameterViewModel.SetParameterId(SelectedType.Id);
				await _windowManager.ShowWindowAsync(consoleParameterViewModel);
			}
			else MessageBox.Show("One type must be selected to update.");

		}

		public async Task DeleteType()
		{
			if (SelectedType != null)
			{
				var result = await _typeService.DeleteVideoGameTypeAsync(SelectedType.Id);
				if (result)
				{
					VideoGameTypes.Remove(SelectedType);
					MessageBox.Show("Type deleted successfully.");
				}
				else MessageBox.Show("Failed to delete the type.");
			}
			else MessageBox.Show("One type must be selected to delete.");
		}

		public async Task AddAge()
		{
			var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
			consoleParameterViewModel.SetAction("add");
			consoleParameterViewModel.SetTable("age");
			await _windowManager.ShowWindowAsync(consoleParameterViewModel);
		}

		public async Task UpdateAge()
		{
			if (SelectedAge != null)
			{
				var consoleParameterViewModel = IoC.Get<ParametersViewModel>();
				consoleParameterViewModel.SetAction("update");
				consoleParameterViewModel.SetTable("age");
				consoleParameterViewModel.SetParameterId(SelectedAge.Id);
				await _windowManager.ShowWindowAsync(consoleParameterViewModel);
			}
			else MessageBox.Show("One age must be selected to update.");

		}

		public async Task DeleteAge()
		{
			if (SelectedAge != null)
			{
				var result = await _ageService.DeleteVideoGameAgeAsync(SelectedAge.Id);
				if (result)
				{
					VideoGameAges.Remove(SelectedAge);
					MessageBox.Show("Age deleted successfully.");
				}
				else MessageBox.Show("Failed to delete the age.");
			}
			else MessageBox.Show("One age must be selected to delete.");
		}

		public async Task AddGame()
		{
			var gameDetailsViewModel = IoC.Get<GameDetailsViewModel>();
			gameDetailsViewModel.SetAction("add");
			await _windowManager.ShowWindowAsync(gameDetailsViewModel);
		}

		public async Task UpdateGame()
		{
			if (SelectedGame != null)
			{
				var gameDetailsViewModel = IoC.Get<GameDetailsViewModel>();
				gameDetailsViewModel.SetGameId(SelectedGame.Id);
				gameDetailsViewModel.SetAction("update");
				await _windowManager.ShowDialogAsync(gameDetailsViewModel);

			}
			else MessageBox.Show("One game must be selected to update.");
		}

		public async Task DeleteGame()
		{
			if (SelectedGame != null)
			{
				var result = await _videoGameService.DeleteVideoGameAsync(SelectedGame.Id);
				if (result)
				{
					VideoGames.Remove(SelectedGame);
					MessageBox.Show("Game deleted successfully.");
				}
				else MessageBox.Show("Failed to delete the game.");
			}
			else MessageBox.Show("One game must be selected to delete.");
		}

		public async Task RefreshGames()
		{
			await LoadVideoGamesAsync();
			if(SelectedConsole != null) SelectedConsole = null;
			if(SelectedYear != null) SelectedYear = null;
			if(SelectedType != null) SelectedType = null;
			if(SelectedAge != null) SelectedAge = null;
		}

		private async Task SearchParametersChanged()
		{
			int? consoleId = SelectedConsole != null ? SelectedConsole.Id : null;
			int? yearId = SelectedYear != null ? SelectedYear.Id : null;
			int? typeId = SelectedType != null ? SelectedType.Id : null;
			int? ageId = SelectedAge != null ? SelectedAge.Id : null;

			var searchedVideoGames = await _videoGameService.GetBySearchParameters
				(consoleId, yearId, typeId, ageId);
			VideoGames.Clear();
			VideoGames.AddRange(searchedVideoGames);
		}
	}
}
