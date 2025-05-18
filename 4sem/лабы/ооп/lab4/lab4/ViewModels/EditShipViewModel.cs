using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace lab4.ViewModels
{
    public class EditShipViewModel : INotifyPropertyChanged
    {
        private ShipModel _originalShip;
        private string _name;
        private string _shortDescription;
        private string _description;
        private int _price;
        private string _shipType;
        private string _availability;
        private string _imagePath;
        private BitmapImage _shipImage;
        private string _errorMessage;
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ChangeImageCommand { get; }
        public Action CloseAction { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string ShortDescription
        {
            get => _shortDescription;
            set
            {
                _shortDescription = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public string ShipType
        {
            get => _shipType;
            set
            {
                _shipType = value;
                OnPropertyChanged();
            }
        }

        public string Availability
        {
            get => _availability;
            set
            {
                _availability = value;
                OnPropertyChanged();
            }
        }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage ShipImage
        {
            get => _shipImage;
            set
            {
                _shipImage = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public ShipModel OriginalShip
        {
            get => _originalShip;
            set
            {
                _originalShip = value;
                OnPropertyChanged();
            }
        }

        public EditShipViewModel(ShipModel ship)
        {
            _originalShip = ship;

            _name = ship.Name;
            _shortDescription = ship.ShortDescription;
            _description = ship.Description;
            _price = ship.Price;
            _shipType = ship.ShipType;
            _availability = ship.Availability;
            _imagePath = ship.ImagePath;

            if (!string.IsNullOrEmpty(_imagePath))
            {
                _shipImage = new BitmapImage(new Uri(_imagePath));
            }

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(CloseAction);
            ChangeImageCommand = new RelayCommand(ChangeImage);
        }
        public EditShipViewModel()
        { 

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(CloseAction);
            ChangeImageCommand = new RelayCommand(ChangeImage);
        }

        private bool CanSaveShip()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(ShortDescription) &&
                   !string.IsNullOrWhiteSpace(Description) &&
                   Price > 0 &&
                   !string.IsNullOrWhiteSpace(ShipType) &&
                   !string.IsNullOrWhiteSpace(Availability);
        }

        private void Save()
        {
            if (!CanSaveShip())
            {
                MessageBox.Show("Проверьте корректность введенных данных");
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE ShipModel SET 
                                Name = @Name, 
                                Description = @Description, 
                                ShortDescription = @ShortDescription,
                                Price = @Price, 
                                ShipType = @ShipType, 
                                Availability = @Availability,
                                ImagePath = @ImagePath
                                WHERE Id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@ShortDescription", ShortDescription);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@ShipType", ShipType);
                        command.Parameters.AddWithValue("@Availability", Availability);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Id", _originalShip.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные судна успешно обновлены");

                            _originalShip.Name = Name;
                            _originalShip.ShortDescription = ShortDescription;
                            _originalShip.Description = Description;
                            _originalShip.Price = Price;
                            _originalShip.ShipType = ShipType;
                            _originalShip.Availability = Availability;
                            _originalShip.ImagePath = ImagePath;
                        }
                        else
                        {
                            ErrorMessage = "Не удалось обновить данные судна";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при сохранении: {ex.Message}";
            }

            CloseAction?.Invoke();
        }

        private void ChangeImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение судна"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
                ShipImage = new BitmapImage(new Uri(ImagePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}