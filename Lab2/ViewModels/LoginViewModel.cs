namespace Lab2.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        public string Email {
            get
            {
                return email;
            }

            set
            {
                if (email != value)
                {
                    email = value;
                    //OnPropertyChanged(password);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if(password != value)
                {
                    password = value;
                    //OnPropertyChanged(password);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }

            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    //SetValue(ref isRunning, value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isRunning)));
                }
            }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(isEnabled)));
                }
                // SetValue(ref isEnabled, value);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            IsRemembered = true;
            IsEnabled = true;

            Email = "test@test.com";
            Password = "1234";
        }

        private async void Login()
        {
            if(string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            if(Email != "test@test.com" || Password != "1234")
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password are incorrect",
                    "Accept");
                Password = string.Empty;
                return;
            }

            IsRunning = false;
            IsEnabled = true;
            Email = string.Empty;
            Password = string.Empty;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            return;
        }

        
    }
}
