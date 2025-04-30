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
    public class EditShipViewModel:INotifyPropertyChanged
    {
        private ShipModel _originalShip;
        private string _name;
        private string _description;
        private string _price;
        private BitmapImage _shipImage;

        public ShipModel EditedShip { get; private set; }
        public ICommand SaveCommand { get; }
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

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
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
        public EditShipViewModel(ShipModel ship)
        {
            _originalShip = ship;
            Name = ship.Name;
            Description = ship.Description;
            Price = ship.Price.ToString();
            if (!string.IsNullOrEmpty(ship.ImagePath))
            {
                ShipImage = new BitmapImage(new Uri(ship.ImagePath, UriKind.RelativeOrAbsolute));
            }
            SaveCommand = new RelayCommand(Save);
        }
        public EditShipViewModel()
        {
            SaveCommand = new RelayCommand(Save);
        }
        private void Save()
        {
            if (!int.TryParse(Price, out int priceValue))
            {
                MessageBox.Show("Некорректное значение цены");
                return;
            }

            EditedShip = new ShipModel(
                _originalShip.Id,
                Name,
                Description,
                priceValue,
                _originalShip.Availability,
                _originalShip.ImagePath,
                _originalShip.ShipType);

            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
