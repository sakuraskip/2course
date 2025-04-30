using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace lab4.ViewModels
{
    public class AdminPanelViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<ShipModel> _ships;
        private ShipModel _selectedShip;

        public ObservableCollection<ShipModel> Ships
        {
            get => _ships;
            set
            {
                _ships = value;
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

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public AdminPanelViewModel(List<ShipModel> ships)
        {
            Ships = new ObservableCollection<ShipModel>(ships);

            EditCommand = new RelayCommand<ShipModel>(EditShip);
            DeleteCommand = new RelayCommand<ShipModel>(DeleteShip);
        }
        public AdminPanelViewModel()
        {
            EditCommand = new RelayCommand<ShipModel>(EditShip);
            DeleteCommand = new RelayCommand<ShipModel>(DeleteShip);
        }

        private void EditShip(ShipModel ship)
        {
            if (ship == null) return;

            var editWindow = new editShipWindow(ship);
            if (editWindow.ShowDialog() == true)
            {
               
               
            }
            int index = Ships.IndexOf(ship);
            if (index >= 0)
            {
                Ships[index] = (editWindow.DataContext as EditShipViewModel).EditedShip;
            }
            Ships = GetUpdatedShips();

        }

        private void DeleteShip(ShipModel ship)
        {
            if (ship == null) return;

            if (MessageBox.Show(
                $"Вы уверены, что хотите удалить {ship.Name}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Ships.Remove(ship);
            }
            Ships = GetUpdatedShips();
        }

        public ObservableCollection<ShipModel> GetUpdatedShips()
        {
            return new ObservableCollection<ShipModel>(Ships);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
