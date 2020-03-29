using DataConfiguration.Business.Engines.Interfaces;
using DataConfigurationApp.Model;
using DataConfigurationApp.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataConfigurationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IActionDataEngine actionDataEngine;
        private readonly ActionViewModel actionViewModel;
        private readonly ILogger<MainWindow> logger;

        public MainWindow(IActionDataEngine actionDataEngine,
            ActionViewModel actionViewModel,
            ILogger<MainWindow> logger)
        {
            InitializeComponent();
            DataContext = actionViewModel;
            this.actionDataEngine = actionDataEngine;
            this.actionViewModel = actionViewModel;
            this.logger = logger;
            IsEnable(true);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IsEnable(false);

            await Task.Run(() =>
             {
                 try
                 {
                     actionDataEngine.ExecuteAction("Refresh data");
                 }
                 catch (Exception ex)
                 {
                     logger.LogError(ex, ex.Message, ex.StackTrace);
                 }
             });

            IsEnable(true);
        }

        private void IsEnable(bool isEnabled)
        {
            actionViewModel.IsEnabled = isEnabled;

        }
    }
}
