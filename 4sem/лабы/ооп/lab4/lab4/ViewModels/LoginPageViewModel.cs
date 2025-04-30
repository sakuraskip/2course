using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4.ViewModels
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private UserModel _user;
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand ClearUsernameCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            ClearUsernameCommand = new RelayCommand(ClearUsername);
        }
        private void Login()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                _user = new UserModel(Username, Password);
                var mainWindow = new ItemsList(_user);
                mainWindow.Show();

                Application.Current.Windows[0]?.Close();
            }
            else
            {
                MessageBox.Show("Please enter both username and password");
            }
        }

        private void ClearUsername()
        {
            Username = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
