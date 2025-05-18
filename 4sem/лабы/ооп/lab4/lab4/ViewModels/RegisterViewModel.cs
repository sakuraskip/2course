using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using lab4.userControls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;

namespace lab4.ViewModels
{
        public class RegisterViewModel : INotifyPropertyChanged
        {
        private UserModel _user;
            private string _username;
        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public string Username
            {
                get => _username;
                set { _username = value; OnPropertyChanged(); }
            }

            private string _login;
            public string Login
            {
                get => _login;
                set { _login = value; OnPropertyChanged(); }
            }

            private string _password;
            public string Password
            {
                get => _password;
                set { _password = value; OnPropertyChanged(); }
            }

            private string _confirmPassword;
            public string ConfirmPassword
            {
                get => _confirmPassword;
                set { _confirmPassword = value; OnPropertyChanged(); }
            }
        private ObservableCollection<UserModel> _users;


        public ICommand RegisterCommand { get; }
            public ICommand NavigateToLoginCommand { get; }
        public Action CloseAction { get; set; }

            public RegisterViewModel()
            {
                RegisterCommand = new RelayCommand(Register);
                NavigateToLoginCommand = new RelayCommand(NavigateToLogin);
                _ =LoadUsers();
            }

        private void Register()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Login) ||
                string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            UserModel? DbUser = _users.Where(u => u.Login == Login).FirstOrDefault();
            if (DbUser == null)
            {
                UserModel newuser = new UserModel(Username, Login, Password);
                _user = newuser;
                SaveToDb(_user);
                _users.Add(_user);
                MessageBox.Show("вы успешно зарегистрированы.");
                Task.Delay(1000);
                NavigateToLogin();
            }
            else
            {
                MessageBox.Show("пользователь с таким логином уже существует");
            }
        }

        private void NavigateToLogin()
            {
                var loginWindow = new loginpage();
                loginWindow.Show();

            CloseAction?.Invoke();
            }
        private async Task LoadUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("SELECT * FROM UserModel", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    _users = new ObservableCollection<UserModel>();

                    while (await reader.ReadAsync())
                    {
                        _users.Add(new UserModel
                        (
                            id: reader.GetInt32(reader.GetOrdinal("Id")),
                            username: reader["Username"].ToString(),
                            login: reader["Login"].ToString(),
                            password: reader["Password"].ToString(),
                            role: reader["Role"].ToString(),
                            profilepic: reader["ProfilePicture"].ToString()
                        )
                        );
                    }
                }
            }
        }
        private async Task SaveToDb(UserModel user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("INSERT INTO UserModel VALUES (@Role, @Login, @Username, @Password,@ProfilePicture)", connection);

                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@ProfilePicture", user.ProfilePicturePath);

                await command.ExecuteNonQueryAsync();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    }

