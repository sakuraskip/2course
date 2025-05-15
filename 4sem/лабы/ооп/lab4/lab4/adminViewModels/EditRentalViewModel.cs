using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using lab4.admin_panel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace lab4.adminViewModels
{
    public class EditRentalViewModel : INotifyPropertyChanged
    {
        private Request _rental;
        private readonly string _connectionString;

        public Request Rental
        {
            get => _rental;
            set
            {
                _rental = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CloseCommand { get; }

        public EditRentalViewModel(Request rental, SqlConnection connection)
        {
            Rental = rental;
            _connectionString = connection.ConnectionString;
            SaveCommand = new RelayCommand(Save);
            CloseCommand = new RelayCommand(CloseWindow);
        }

        public EditRentalViewModel(Request rental)
        {
            Rental = rental;
            _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SaveCommand = new RelayCommand(Save);
            CloseCommand = new RelayCommand(CloseWindow);
        }
        public EditRentalViewModel()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SaveCommand = new RelayCommand(Save);
            CloseCommand = new RelayCommand(CloseWindow);
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
                                "UPDATE Rental SET ShipId = @ShipId,UserId = @UserId, RentDate = @RentDate, Status = @Status, Cost = @Cost WHERE Id = @Id",
                                connection,
                                transaction))
                            {
                                command.Parameters.AddWithValue("@ShipId", Rental.ShipId);
                                command.Parameters.AddWithValue("@UserId", Rental.UserId);
                                command.Parameters.AddWithValue("@RentDate", Rental.Date);
                                command.Parameters.AddWithValue("@Status", Rental.Status);
                                command.Parameters.AddWithValue("@Cost", Rental.Cost);
                                command.Parameters.AddWithValue("@Id", Rental.Id);

                               command.ExecuteNonQuery();

                                
                            }
                            transaction.Commit();
                            MessageBox.Show("Данные аренды успешно сохранены.");
                            CloseWindow();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при сохранении аренды: {ex.Message}");
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка save(): {ex.Message}");
            }
        }

        private void CloseWindow()
        {
            Application.Current.Windows.OfType<EditRentalWindow>().FirstOrDefault()?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}