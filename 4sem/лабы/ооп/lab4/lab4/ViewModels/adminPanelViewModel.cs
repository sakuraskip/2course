using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using lab4.admin_panel;

namespace lab4.ViewModels
{
    public class AdminPanelViewModel : INotifyPropertyChanged
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private ObservableCollection<ShipModel> _Ships;
        private ObservableCollection<UserModel> _Users;
        private ObservableCollection<Request> _Requests;
        private ShipModel _selectedShip;

        public ObservableCollection<ShipModel> Ships
        {
            get => _Ships;
            set
            {
                _Ships = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get => _Users;
            set
            {
                _Users = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Request> Requests
        {
            get => _Requests;
            set
            {
                _Requests = value;
                OnPropertyChanged();
            }
        }

        public ShipModel SelectedShip
        {
            get => _selectedShip;
            set
            {
                _selectedShip = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public RelayCommand<UserModel> EditUserCommand { get; }
        public RelayCommand<UserModel> DeleteUserCommand { get; }
        public RelayCommand<Request> EditRentalCommand { get; }
        public RelayCommand<Request> DeleteRentalCommand { get; }

        public AdminPanelViewModel(ShipListModel ships)
        {
            Ships = new ObservableCollection<ShipModel>();
            Users = new ObservableCollection<UserModel>();
            Requests = new ObservableCollection<Request>();

            EditCommand = new RelayCommand<ShipModel>(EditShip);
            DeleteCommand = new RelayCommand<ShipModel>(DeleteShip);
            EditUserCommand = new RelayCommand<UserModel>(OpenEditUserWindow);
            EditRentalCommand = new RelayCommand<Request>(OpenEditRentaiWindow);
            _ = LoadData();
        }

        public AdminPanelViewModel()
        {
            Ships = new ObservableCollection<ShipModel>();
            Users = new ObservableCollection<UserModel>();
            Requests = new ObservableCollection<Request>();

            EditCommand = new RelayCommand<ShipModel>(EditShip);
            DeleteCommand = new RelayCommand<ShipModel>(DeleteShip);
            EditUserCommand = new RelayCommand<UserModel>(OpenEditUserWindow);
            EditRentalCommand = new RelayCommand<Request>(OpenEditRentaiWindow);
            _ = LoadData();
        }

        

        private async Task LoadData()
        {
            try
            {
                await LoadShips();
                await LoadUsers();
                await LoadRentals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private async Task LoadShips()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM ShipModel", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var ships = new ObservableCollection<ShipModel>();
                            while (await reader.ReadAsync())
                            {
                                ships.Add(new ShipModel(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    name: reader["Name"].ToString(),
                                    description: reader["Description"].ToString(),
                                    price: reader.GetInt32(reader.GetOrdinal("Price")),
                                    availability: reader["Availability"].ToString(),
                                    imagePath: reader["ImagePath"].ToString(),
                                    shipType: reader["ShipType"].ToString()));
                            }
                            Ships = ships;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ships: {ex.Message}");
                throw;
            }
        }

        private async Task LoadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM UserModel", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var users = new ObservableCollection<UserModel>();
                            while (await reader.ReadAsync())
                            {
                                users.Add(new UserModel(
                                    id: (int)reader["Id"],
                                    username: reader["Login"].ToString(),
                                    role: reader["Role"].ToString(),
                                    password: reader["password"].ToString()));
                            }
                            Users = users;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
                throw;
            }
        }

        private async Task LoadRentals()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT * FROM Rental", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var requests = new ObservableCollection<Request>();
                            while (await reader.ReadAsync())
                            {
                                requests.Add(new Request(
                                    id: (int)reader["Id"],
                                    shipId: (int)reader["ShipId"],
                                    userId: (int)reader["UserId"],
                                    startDate: (DateTime)reader["StartDate"],
                                    endDate: (DateTime)reader["EndDate"],
                                    status: reader["Status"].ToString(),
                                    cost: (int)reader["Cost"]));
                            }
                            Requests = requests;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rentals: {ex.Message}");
                throw;
            }
        }

        private void OpenEditUserWindow(UserModel user)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var window = new EditUserWindow(user, connection);
                    window.ShowDialog();
                    _ = LoadUsers(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening user editor: {ex.Message}");
            }
        }

        private void OpenEditRentaiWindow(Request rental)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var window = new EditRentalWindow(rental, connection);
                    window.ShowDialog();
                    _ = LoadRentals(); // Refresh rentals after editing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening rental editor: {ex.Message}");
            }
        }

        private void EditShip(ShipModel ship)
        {
            if (ship == null) return;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var editWindow = new editShipWindow(ship);
                    if (editWindow.ShowDialog() == true)
                    {
                        _ = LoadShips(); // Refresh ship list after editing
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing ship: {ex.Message}");
            }
        }

        private void DeleteShip(ShipModel ship)
        {
            if (ship == null) return;

            if (MessageBox.Show(
                $"Вы уверены, что хотите удалить {ship.Name}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand("DELETE FROM ShipModel WHERE Id = @Id", connection))
                        {
                            command.Parameters.AddWithValue("@Id", ship.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                    _ = LoadShips(); // Refresh ship list after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting ship: {ex.Message}");
                }
            }
        }

        public ObservableCollection<ShipModel> GetUpdatedShips()
        {
            _ = LoadShips(); // Simply reload from database
            return Ships;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}