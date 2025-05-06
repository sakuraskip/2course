using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using lab4.admin_panel;
using lab4.ViewModels;

namespace lab4.adminViewModels
{
    public class EditUserViewModelAdmin : INotifyPropertyChanged
    {
        private UserModel _user;
        private readonly string _connectionString;

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public EditUserViewModelAdmin(UserModel user, SqlConnection connection)
        {
            User = user;
            _connectionString = connection.ConnectionString;
            SaveCommand = new RelayCommand(Save);
        }

        public EditUserViewModelAdmin()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (var command = new SqlCommand(
                                "UPDATE UserModel SET Login = @Username, Role = @Role, Password = @Password WHERE Id = @Id",
                                connection,
                                transaction))
                            {
                                command.Parameters.AddWithValue("@Username", User.Username);
                                command.Parameters.AddWithValue("@Role", User.Role);
                                command.Parameters.AddWithValue("@Password", User.Password);
                                command.Parameters.AddWithValue("@Id", User.Id);

                                command.ExecuteNonQuery();

                            }
                            transaction.Commit();
                            MessageBox.Show("Данные пользователя сохранены.");
                            CloseWindow();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка сохранения: {ex.Message}");
            }
        }

        private void CloseWindow()
        {
            Application.Current.Windows.OfType<EditUserWindow>().FirstOrDefault()?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}