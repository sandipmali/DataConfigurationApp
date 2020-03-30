using DataConfiguration.Business.Engines;
using DataConfiguration.Business.Engines.Interfaces;
using DataConfiguration.Business.Services;
using DataConfigurationApp.ViewModel;
using DataConfiuguration.Parser;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using DataConfiguration.DAL.Repository;

namespace DataConfigurationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<JsonParser>();
            services.AddScoped<IActionDataEngine, ActionDataEngine>();
            services.AddScoped<IRestClientService, RestClientService>();
            services.AddSingleton<ActionViewModel>();
            services.AddScoped<IActionRepository, ActionRepository>();

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
