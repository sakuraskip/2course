using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            NewShip = new ShipModel(
                _shipListLength + 1,
                Name,
                Description,
                priceValue,
                "Модель в наличии",
                ImagePath,
                _shipType);

            CloseAction?.Invoke();
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
