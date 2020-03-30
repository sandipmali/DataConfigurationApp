using DataConfiguration.Business.Engines.Interfaces;
using DataConfigurationApp.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace DataConfigurationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IActionDataEngine _actionDataEngine;
        private readonly ActionViewModel _actionViewModel;

        public MainWindow(IActionDataEngine actionDataEngine,
            ActionViewModel actionViewModel)
        {
            InitializeComponent();
            DataContext = actionViewModel;
            _actionDataEngine = actionDataEngine;
            _actionViewModel = actionViewModel;

            IsEnable(true);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IsEnable(false);

            await Task.Run(() =>
             {
                 try
                 {
                     _actionDataEngine.ExecuteAction("Refresh data");
                 }
                 catch (Exception ex)
                 {
                     //_logger.LogError(ex, ex.Message, ex.StackTrace);
                 }
             });

            IsEnable(true);
        }

        private void IsEnable(bool isEnabled)
        {
            _actionViewModel.IsEnabled = isEnabled;

        }
    }
}
