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
using lab4.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace lab4.ViewModels
{
    public class AdminPanelViewModel : INotifyPropertyChanged
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private ObservableCollection<ShipModel> _Ships;
        private ObservableCollection<UserModel> _Users;
        private ObservableCollection<Request> _Requests;
        private ObservableCollection<CancelledRental> _CancelledRentals;

        public SeriesCollection RentDistributionSeries { get; set; }

        private ShipModel _selectedShip;

        private decimal _totalRevenue;
        private int _totalRentals;
        private string _mostPopularShip;

        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set
            {
                _totalRevenue = value;
                OnPropertyChanged();
            }
        }

        public int TotalRentals
        {
            get => _totalRentals;
            set
            {
                _totalRentals = value;
                OnPropertyChanged();
            }
        }

        public string MostPopularShip
        {
            get => _mostPopularShip;
            set
            {
                _mostPopularShip = value;
                OnPropertyChanged();
            }
        }

       
        public ObservableCollection<ShipModel> Ships
        {
            get => _Ships;
            set
            {
                _Ships = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CancelledRental> CancelledRentals
        {
            get => _CancelledRentals;
            set
            {
                _CancelledRentals = value;
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
        public ICommand ConfirmCancelRentCommand { get; }
        public ICommand CancelCancelRentCommand { get; }


        public AdminPanelViewModel(ShipListModel ships)
        {
            Ships = new ObservableCollection<ShipModel>();
            Users = new ObservableCollection<UserModel>();
            Requests = new ObservableCollection<Request>();

            EditCommand = new RelayCommand<ShipModel>(EditShip);
            DeleteCommand = new RelayCommand<ShipModel>(DeleteShip);
            EditUserCommand = new RelayCommand<UserModel>(OpenEditUserWindow);
            EditRentalCommand = new RelayCommand<Request>(OpenEditRentaiWindow);
            ConfirmCancelRentCommand = new RelayCommand<CancelledRental>(ConfirmCancelledRental);
            CancelCancelRentCommand = new RelayCommand<CancelledRental>(CancelCancelledRental);
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
            ConfirmCancelRentCommand = new RelayCommand<CancelledRental>(ConfirmCancelledRental);
            CancelCancelRentCommand = new RelayCommand<CancelledRental>(CancelCancelledRental);
            _ = LoadData();
        }

        
        
        private async Task LoadData()
        {
            try
            {
                await LoadShips();
                await LoadUsers();
                await LoadRentals();
                await LoadCancelledRentals();
                await LoadStatistics(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }
        private async Task LoadRentDistributionData(SqlConnection connection)
        {
            var shipRentals = new Dictionary<string, int>();
            int totalRentals = 0;

            using (var cmd = new SqlCommand(
                @"SELECT s.Name, COUNT(r.Id) as RentCount
              FROM Rental r
              JOIN ShipModel s ON r.ShipId = s.Id
              GROUP BY s.Name
              ORDER BY RentCount DESC", connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var shipName = reader["Name"].ToString();
                        var count = Convert.ToInt32(reader["RentCount"]);
                        shipRentals.Add(shipName, count);
                        totalRentals += count;
                    }
                }
            }

            RentDistributionSeries = new SeriesCollection();

            var colors = new[]
            {
            "#FF5722", "#2196F3", "#4CAF50", "#FFC107",
            "#9C27B0", "#009688", "#3F51B5", "#FF9800"
        };

            int colorIndex = 0;
            foreach (var item in shipRentals)
            {
                var percentage = totalRentals > 0 ? (item.Value * 100.0 / totalRentals) : 0;

                RentDistributionSeries.Add(new PieSeries
                {
                    Title = $"{item.Key} ({percentage:F1}%)",
                    Values = new ChartValues<int> { item.Value },
                    DataLabels = true,
                    LabelPoint = point => $"{point.Y} ({point.Participation:P1})",
                    Fill = (Brush)new BrushConverter().ConvertFrom(colors[colorIndex % colors.Length])
                });

                colorIndex++;
            }

            OnPropertyChanged(nameof(RentDistributionSeries));
        }
        private async Task LoadStatistics()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand(
                        "SELECT SUM(Cost) FROM Rental", connection))
                    {
                        var result = await command.ExecuteScalarAsync();
                        TotalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }

                    using (var command = new SqlCommand(
                        "SELECT COUNT(*) FROM Rental", connection))
                    {
                        TotalRentals = (int)await command.ExecuteScalarAsync();
                    }

                    using (var command = new SqlCommand(
                        @"SELECT TOP 1 s.Name, COUNT(r.Id) as RentalCount 
                      FROM Rental r
                      JOIN ShipModel s ON r.ShipId = s.Id
                      GROUP BY s.Name
                      ORDER BY RentalCount DESC", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                MostPopularShip = $"{reader["Name"]} ({reader["RentalCount"]} rentals)";
                            }
                            else
                            {
                                MostPopularShip = "No data";
                            }
                        }
                    }

                    await LoadRentDistributionData(connection);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}");
            }
        }
        private async Task LoadCancelledRentals()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("SELECT cr.*, u.Username, r.ShipName FROM CancelledRentals cr " +
                                                         "JOIN UserModel u ON cr.userId = u.Id " +
                                                         "JOIN Rental r ON cr.rentalId = r.Id", connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            var cancelledRentals = new ObservableCollection<CancelledRental>();
                            while (await reader.ReadAsync())
                            {
                                cancelledRentals.Add(new CancelledRental(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    userid: reader.GetInt32(reader.GetOrdinal("userId")),
                                    rentalid: reader.GetInt32(reader.GetOrdinal("rentalId")),
                                    status: reader["status"].ToString(),
                                    username: reader["Username"].ToString(),
                                    shipname: reader["ShipName"].ToString()));
                            }
                            CancelledRentals = cancelledRentals;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancelled rentals: {ex.Message}");
                throw;
            }
        }
        private void ConfirmCancelledRental(CancelledRental rental)
        {
            if (rental != null)
            {
                if (MessageBox.Show(
                $"Подтвердить отмену аренды {rental.ShipName} пользователя {rental.UserName}?",
                "Подтверждение отмены аренды",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (var command = new SqlCommand("update rental set status = 'Отменено' where Id = @rentalId", connection))
                            {
                                command.Parameters.AddWithValue("@rentalId", rental.RentalId);
                                command.ExecuteNonQuery();
                            }
                            using (var command = new SqlCommand("delete from CancelledRentals where Id = @Id", connection))
                            {
                                command.Parameters.AddWithValue("@Id", rental.Id); command.ExecuteNonQuery();
                            }
                        }
                        _ = LoadRentals();
                        _ = LoadCancelledRentals();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void CancelCancelledRental(CancelledRental rental)
        {
            if (rental != null)
            {
                if (MessageBox.Show(
                 $"Отклонить заявку на отмену аренды {rental.ShipName} пользователем {rental.UserName}?",
                 "Отклонение отмены аренды",
                 MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (var command = new SqlCommand("delete from CancelledRentals where Id = @Id", connection))
                            {
                                command.Parameters.AddWithValue("@Id", rental.Id); command.ExecuteNonQuery();
                            }
                        }
                        _ = LoadCancelledRentals();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error cancelling rental: " + ex.Message);
                    }
                }
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
                                    username: reader["Username"].ToString(),
                                    login: reader["Login"].ToString(),
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
                                    date: reader.GetDateTime(reader.GetOrdinal("RentDate")),
                                    status: reader["Status"].ToString(),
                                    imagePath: reader["ImagePath"].ToString(),
                                    shipname: reader["ShipName"].ToString(),
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
                    _ = LoadRentals(); 
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
                        _ = LoadShips(); 
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
                    _ = LoadShips(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting ship: {ex.Message}");
                }
            }
        }

        public ObservableCollection<ShipModel> GetUpdatedShips()
        {
            _ = LoadShips(); 
            return Ships;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}