using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace HelloPrism1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Hello Prism";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isEnabled = false;

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private string _updateText = "";
        public string UpdateText
        {
            get => _updateText;
            set => SetProperty(ref _updateText, value);
        }

        public DelegateCommand<int?> MyAwesomeCommand
        {
            get;
            private set;
        }

        public MainWindowViewModel()
        {
            MyAwesomeCommand = 
                new DelegateCommand<int?>(Execute)
                    .ObservesCanExecute(() => IsEnabled);
        }

        private void Execute(int? parameter)
        {
            if (parameter.HasValue)
            {
                UpdateText = $"Received parameter: {parameter}";
            }
        }
    }
}
