using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using GameStoreWPF.Services.Interfaces;
using GameStoreWPF.Models;
using System.Windows;
using GameStoreWPF.Events.Adds;
using GameStoreWPF.Events.Updates;

namespace GameStoreWPF.ViewModels
{
	public class ParametersViewModel: Screen
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IAgeService _ageService;
		private readonly IConsoleService _consoleService;
		private readonly IPublicationService _publicationService;
		private readonly ITypeService _typeService;
		public int ParameterId { get; private set; }
		public string? Table { get; private set; }
		public string? Action {  get; private set; }

		public ParametersViewModel(
			IEventAggregator eventAggregator,
			IAgeService ageService,
			IConsoleService consoleService,
			IPublicationService publicationService,
			ITypeService typeService)
		{
			_eventAggregator = eventAggregator;
			_ageService = ageService;
			_typeService = typeService;
			_consoleService = consoleService;
			_publicationService = publicationService;
		}

		private string? _parameter;
		public string? Parameter
		{
			get { return _parameter; }
			set 
			{ 
				_parameter = value;
				NotifyOfPropertyChange(() => Parameter);
			}
		}

		protected override async Task OnActivatedAsync(CancellationToken cancellationToken)
		{
			await LoadParameterAsync();
		}

		private async Task LoadParameterAsync()
		{
			if(Action == "update")
			{
				switch (Table)
				{
					case "console":
						var console = await _consoleService.GetConsoleVideoGameAsync(ParameterId);
						Parameter = console.Name;
						break;
					case "year":
						var year = await _publicationService.GetPublicationYearAsync(ParameterId);
						Parameter = year.Year.ToString();
						break;
					case "type":
						var type = await _typeService.GetVideoGameTypeAsync(ParameterId);
						Parameter = type.Type;
						break;
					case "age":
						var age = await _ageService.GetVideoGameAgeAsync(ParameterId);
						Parameter = age.Age.ToString();
						break;
				}
			}
		}

		public void SetParameterId(int parameterId)
		{
			ParameterId = parameterId;
			NotifyOfPropertyChange(() => ParameterId);
		}

		public void SetTable(string? table)
		{
			Table = table;
			NotifyOfPropertyChange(() => Table);
		}

		public void SetAction(string? action)
		{
			Action = action;
			NotifyOfPropertyChange(() => Action);
		}

		public async Task Continue()
		{
			if(Action == "add")
			{
				switch (Table)
				{
					case "console":
						var console = new ConsoleVideoGame { Name = Parameter };
						await _consoleService.CreateConsoleVideoGameAsync(console);
						await _eventAggregator.PublishOnUIThreadAsync(new ConsoleAddedEvent(console));
						MessageBox.Show("Console added successfully.");
						break;
					case "year":
						if (int.TryParse(Parameter, out int year))
						{
							var publication = new PublicationYear { Year = year };
							await _publicationService.CreatePublicationYearAsync(publication);
							await _eventAggregator.PublishOnUIThreadAsync(new YearAddedEvent(publication));
							MessageBox.Show("Year added successfully.");
						} else MessageBox.Show("The parameter must be a number");
						break;
					case "type":
						var type = new VideoGameType { Type = Parameter };
						await _typeService.CreateVideoGameTypeAsync(type);
						await _eventAggregator.PublishOnUIThreadAsync(new TypeAddedEvent(type));
						MessageBox.Show("Type added successfully.");
						break;
					case "age":
						if(int.TryParse(Parameter, out int age))
						{
							var gameAge = new VideoGameAge { Age = age };
							await _ageService.CreateVideoGameAgeAsync(gameAge);
							await _eventAggregator.PublishOnUIThreadAsync(new AgeAddedEvent(gameAge));
							MessageBox.Show("Age added successfully.");
						} else MessageBox.Show("The parameter must be a number");
						break;
				}
				await TryCloseAsync();
			}
			else
			{
				switch (Table)
				{
					case "console":
						var console = await _consoleService.GetConsoleVideoGameAsync(ParameterId);
						console.Name = Parameter;
						await _consoleService.UpdateConsoleVideoGameAsync(console);
						await _eventAggregator.PublishOnUIThreadAsync(new ConsoleUpdatedEvent(console));
						MessageBox.Show("Console updated successfully.");
						break;
					case "year":
						if(int.TryParse(Parameter, out int year))
						{
							var publication = await _publicationService.GetPublicationYearAsync(ParameterId);
							publication.Year = year;
							await _publicationService.UpdatePublicationYearAsync(publication);
							await _eventAggregator.PublishOnUIThreadAsync(new YearUpdatedEvent(publication));
							MessageBox.Show("Year updated successfully.");
						} else MessageBox.Show("The parameter must be a number");
						break;
					case "type":
						var gameType = await _typeService.GetVideoGameTypeAsync(ParameterId);
						gameType.Type = Parameter;
						await _typeService.UpdateVideoGameTypeAsync(gameType);
						await _eventAggregator.PublishOnUIThreadAsync(new TypeUpdatedEvent(gameType));
						MessageBox.Show("Type updated successfully.");
						break;
					case "age":
						if (int.TryParse(Parameter, out int age))
						{
							var gameAge = await _ageService.GetVideoGameAgeAsync(ParameterId);
							gameAge.Age = age;
							await _ageService.UpdateVideoGameAgeAsync(gameAge);
							await _eventAggregator.PublishOnUIThreadAsync(new AgeUpdatedEvent(gameAge));
							MessageBox.Show("Age updated successfully.");
						}
						else MessageBox.Show("The parameter must be a number");
						break;
				}
			}
		}

		public async Task Cancel()
		{
			await TryCloseAsync();
		}
	}
}
