using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab4.ViewModels
{
    public class ShipDetailsModel:INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ShipModel _ship;
        private string _priceText;
        private string _availabilityText;

        public ShipModel Ship
        {
            get => _ship;
            set
            {
                _ship = value;
                OnPropertyChanged();
                UpdateDisplayTexts();
            }
        }

        public string PriceText
        {
            get => _priceText;
            set
            {
                _priceText = value;
                OnPropertyChanged();
            }
        }
        public string AvailabilityText
        {
            get => _availabilityText;
            set
            {
                _availabilityText = value;
                OnPropertyChanged();
            }
        }

        public ICommand RentCommand { get; }
        public ICommand CloseCommand { get; }

        public ShipDetailsModel(ShipModel ship)
        {
            Ship = ship;
            RentCommand = new RelayCommand(Rent);
            CloseCommand = new RelayCommand(CloseAction);
        }
        public ShipDetailsModel()
        {

        }
        private void UpdateDisplayTexts()
        {
            PriceText = $"Price: {Ship.Price}$";
            AvailabilityText = $"Availability: {Ship.Availability}";
        }

        private void Rent()
        {
            var reqWindow = new userControls.requestToBook();
            reqWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
