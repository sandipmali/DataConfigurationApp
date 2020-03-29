using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataConfigurationApp.ViewModel
{
    public class ActionViewModel : INotifyPropertyChanged
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                OnPropertyChange(nameof(IsEnabled));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
