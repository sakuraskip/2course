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
        private readonly string _shipType;
        private string _shortDescription = " ";

        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

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
            _shipType = shipType;

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
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Description) ||
                !int.TryParse(Price, out int priceValue) ||
                string.IsNullOrWhiteSpace(ImagePath))
            {
                MessageBox.Show("Неверно заполнены поля");
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("Insert into ShipModel" +
                        " (Name, Description, Price, Availability, ImagePath, ShipType, ShortDescription)" +
                        "VALUES (@Name, @Description, @Price, @Availability, @ImagePath, @ShipType, @ShortDescription); SELECT SCOPE_IDENTITY();", connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Price", priceValue);
                        command.Parameters.AddWithValue("@Availability", "Модель в наличии");
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);
                        command.Parameters.AddWithValue("@ShipType", _shipType);
                        command.Parameters.AddWithValue("@ShortDescription", ShortDescription);

                        int newId = Convert.ToInt32(command.ExecuteScalar());

                        NewShip = new ShipModel(
                newId,
               Name,
               Description,
               priceValue,
               "Модель в наличии",
               ImagePath,
               _shipType, _shortDescription);
                        MessageBox.Show("корабль добавлен в базу данных");
                    }
                }
                CloseAction?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
