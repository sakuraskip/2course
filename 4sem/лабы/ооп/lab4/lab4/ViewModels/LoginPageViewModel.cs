﻿using lab4.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
        private string _login;
        private string _password;
        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
     

        private ObservableCollection<UserModel> _users;

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ClearUsernameCommand { get; }

        public Action CloseAction { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(SignIn);
            RegisterCommand = new RelayCommand(Register);
            ClearUsernameCommand = new RelayCommand(ClearUsername);
            LoadUsers();
        }
        private void Register()
        {
            var registerpage = new registerPage();
            registerpage.Show();
            CloseAction?.Invoke();
        }
        private void SignIn()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
            {
                UserModel? DbUser = _users.Where(u=>u.Login == Login).FirstOrDefault();
                if (DbUser != null)
                {
                    if (DbUser.Password == Password)
                    {
                        _user = DbUser;
                        var mainWindow = new ItemsList(_user);
                        mainWindow.Show();

                        CloseAction?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                MessageBox.Show("Поля логина и пароля не должны быть пустыми");
            }
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
                            profilepic:reader["ProfilePicture"].ToString()
                        )
                        );
                    }
                }
            }
        }

        
        private void ClearUsername()
        {
            Login = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
