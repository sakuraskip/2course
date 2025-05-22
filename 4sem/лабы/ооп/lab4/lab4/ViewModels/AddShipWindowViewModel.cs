using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace lab4.ViewModels
{
    public class AddShipWindowViewModel:INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private string _price;
        private string _imagePath;
        private BitmapImage _imagePreview;
        private readonly int _shipListLength;
        private string _shipType;
        private string _shortDescription = " ";
        public bool IsNameValid { get; set; } = true;
        public bool IsPriceValid { get; set; } = true;
        public bool IsDescValid { get; set; } = true;
        public bool IsImageValid { get; set; } = true;

        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public string ShipType
        {
            get => _shipType;
            set { _shipType = value; OnPropertyChanged(); }
        }
        public string ShortDescription
        {
            get => _shortDescription;
            set { _shortDescription = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        public string Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(); }
        }

        public BitmapImage ImagePreview
        {
            get => _imagePreview;
            set { _imagePreview = value; OnPropertyChanged(); }
        }
        public ShipModel NewShip { get; private set; }
        public ICommand AddShipCommand { get; }
        public ICommand SelectFileCommand { get; }

        public Action CloseAction { get; set; }

        public AddShipWindowViewModel(int shipListLength, string shipType)
        {
            _shipListLength = shipListLength;

            AddShipCommand = new RelayCommand(AddShip);
            SelectFileCommand = new RelayCommand(SelectFile);
        }
        public AddShipWindowViewModel()
        {
            AddShipCommand = new RelayCommand(AddShip);
            SelectFileCommand = new RelayCommand(SelectFile);
        }
        private void AddShip()
        {
            ResetValidation();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Name))
            {
                IsNameValid = false;
                isValid = false;
            }

            if (!int.TryParse(Price, out int price) || price <= 0)
            {
                IsPriceValid = false;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                IsDescValid = false;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(ImagePath))
            {
                IsImageValid = false;
                isValid = false;
            }
            if (!isValid)
            {
                OnPropertyChanged(nameof(IsNameValid));
                OnPropertyChanged(nameof(IsPriceValid));
                OnPropertyChanged(nameof(IsDescValid));
                OnPropertyChanged(nameof(IsImageValid));
                MessageBox.Show("Заполните все поля корректно");
                return;
            }



            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("Insert into ShipModel" +
                        " (Name, Description, Price, Availability, ImagePath, ShipType, ShortDescription,FilterType,Rating)" +
                        "VALUES (@Name, @Description, @Price, @Availability, @ImagePath, @ShipType, @ShortDescription,@FilterType,@Rating); SELECT SCOPE_IDENTITY();", connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Availability", "Модель в наличии");
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        command.Parameters.AddWithValue("@ShipType", _shipType);
                        command.Parameters.AddWithValue("@ShortDescription", ShortDescription);
                        command.Parameters.AddWithValue("@FilterType", ShipType);
                        command.Parameters.AddWithValue("@Rating", 4.64);

                        int newId = Convert.ToInt32(command.ExecuteScalar());

                        NewShip = new ShipModel(
                newId,
               Name,
               Description,
               price,
               "Модель в наличии",
               ImagePath,
               _shipType, _shortDescription,ShipType,4);
                        MessageBox.Show("судно добавлено в базу данных");
                    }
                }
                CloseAction?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ResetValidation()
        {
            IsNameValid = true;
            IsPriceValid = true;
            IsDescValid = true;
            IsImageValid = true;
        }
        private void SelectFile()
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Выбрать картинку"
            };

            if (ofd.ShowDialog() == true)
            {
                ImagePath = ofd.FileName;
                ImagePreview = new BitmapImage(new Uri(ofd.FileName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
