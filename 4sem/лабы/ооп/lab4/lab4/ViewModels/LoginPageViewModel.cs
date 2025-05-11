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

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(SignIn);
            RegisterCommand = new RelayCommand(Register);
            ClearUsernameCommand = new RelayCommand(ClearUsername);
            LoadUsers();
        }
        private void Register()
        {
            if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
            {
                UserModel? DbUser = _users.Where(u => u.Login == Login).FirstOrDefault();
                if (DbUser == null)
                {
                    UserModel newuser = new UserModel(Login,Login, Password);
                    _user = newuser;
                    SaveToDb();
                    _users.Add(_user);

                    MessageBox.Show("Аккаунт успешно зарегистрирован.  Введите данные и нажмите кнопку Войти");
                }
                else MessageBox.Show("Пользователь с таким логином уже существует");

            }
            else
            {
                MessageBox.Show("Поля логина и пароля не должны быть пустыми");
            }

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

                        Application.Current.Windows[0]?.Close();
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
        private void LoadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM UserModel", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var users = new ObservableCollection<UserModel>();
                            while (reader.Read())
                            {
                                users.Add(new UserModel(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    username: reader["Username"].ToString(),
                                    login: reader["Login"].ToString(),
                                    password: reader["Password"].ToString(),
                                    role: reader["Role"].ToString(),
                                    profilepic: reader["ProfilePicture"].ToString()));
                            }
                            _users = users;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}");
                throw;
            }
        }
        private void SaveToDb()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("Insert into UserModel values (@Role,@Login,@Username,@Password,@ProfilePicture)", connection))
                    {
                        command.Parameters.AddWithValue("@Role", _user.Role);
                        command.Parameters.AddWithValue("@Login", _user.Login);
                        command.Parameters.AddWithValue("@Username", _user.Username);
                        command.Parameters.AddWithValue("@Password", _user.Password);
                        command.Parameters.AddWithValue("@ProfilePicture", _user.ProfilePicturePath);

                        command.ExecuteNonQuery();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("error saving account to db: " + ex.Message);
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
