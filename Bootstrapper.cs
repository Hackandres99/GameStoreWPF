using System;
using System.Collections.Generic;
using Caliburn.Micro;
using GameStoreWPF.Context;
using GameStoreWPF.Services.Implementations;
using GameStoreWPF.Services.Interfaces;
using GameStoreWPF.ViewModels;
using System.Windows;

namespace GameStoreWPF
{
	public class Bootstrapper: BootstrapperBase
	{
		private readonly SimpleContainer _container = new();
		public Bootstrapper() 
		{
			Initialize();
		}

		protected override void Configure()
		{
			_container.Singleton<GameStoreContext>();
			_container.Singleton<IWindowManager,  WindowManager>();
			_container.Singleton<IEventAggregator, EventAggregator>();
			_container.Singleton<IAgeService, AgeService>();
			_container.Singleton<IConsoleService, ConsoleService>();
			_container.Singleton<IPublicationService, PublicationService>();
			_container.Singleton<ITypeService, TypeService>();
			_container.Singleton<IVideoGameService, VideoGameService>();
			_container.PerRequest<ShellViewModel>();
			_container.PerRequest<GameDetailsViewModel>();
			_container.PerRequest<ParametersViewModel>();
		}

		protected override object GetInstance(Type service, string key)
		{
			var instance = _container.GetInstance(service, key);
			if (instance != null)
			{
				return instance;
			}
			throw new InvalidOperationException($"The instance for the {service.Name} was not found.");
		}

		protected override IEnumerable<object> GetAllInstances(Type service) => 
			_container.GetAllInstances(service);

		protected override void BuildUp(object instance)
		{
			_container.BuildUp(instance);
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			DisplayRootViewForAsync<ShellViewModel>();
		}
	}
}
