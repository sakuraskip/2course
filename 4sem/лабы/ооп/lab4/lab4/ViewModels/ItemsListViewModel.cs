using lab4.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4.ViewModels
{
    public class ItemsListViewModel: DependencyObject,INotifyPropertyChanged
    {
        public readonly UserModel _currentUser;//сменить на private
        private ObservableCollection<ShipModel> _ships;
        private string _filterName;

        private List<ShipModel> allships =  ShipListModel.LoadFromJson(ShipListModel._filepath);

        public static readonly DependencyProperty MinPriceProperty = //удалить это после 7 лабы
           DependencyProperty.Register(
               "MinPrice",
               typeof(string),
               typeof(ItemsListViewModel),
               new FrameworkPropertyMetadata(
                   "",
                   FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                   new PropertyChangedCallback(OnFilterPropertyChanged),
                   new CoerceValueCallback(CoerceMinPrice)),
               new ValidateValueCallback(ValidatePrice));

        public static readonly DependencyProperty MaxPriceProperty =//это тоже удалить
            DependencyProperty.Register(
                "MaxPrice",
                typeof(string),
                typeof(ItemsListViewModel),
                new FrameworkPropertyMetadata(
                    "",
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnFilterPropertyChanged),
                    new CoerceValueCallback(CoerceMaxPrice)),
                new ValidateValueCallback(ValidatePrice));

        public ObservableCollection<ShipModel> Ships
        {
            get => _ships;
            set { _ships = value; OnPropertyChanged(); }
        }
        private static void OnFilterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var vm = d as ItemsListViewModel;
            vm?.FilterShips();
        }//удалить
        private static object CoerceMinPrice(DependencyObject d, object baseValue)
        {
            var vm = d as ItemsListViewModel;
            string value = baseValue as string;

            if (string.IsNullOrEmpty(value))
                return value;

            if (!int.TryParse(value, out int intValue))
                return DependencyProperty.UnsetValue;

            if (intValue < 0)
                return "0";

            return value;
        }//удалить
        private static object CoerceMaxPrice(DependencyObject d, object baseValue)
        {
            var vm = d as ItemsListViewModel;
            string value = baseValue as string;

            if (string.IsNullOrEmpty(value))
                return value;

            if (!int.TryParse(value, out int intValue))
                return DependencyProperty.UnsetValue;

            if (intValue < 0)
                return "0";

            return value;
        }//удалить
        private static bool ValidatePrice(object value)
        {
            if (value == null)
                return true;

            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                return true;

            return int.TryParse(strValue, out _);
        }//удалить

        public string FilterName
        {
            get => _filterName;
            set { _filterName = value; OnPropertyChanged(); FilterShips(); }
        }

        public string MinPrice
        {
            get => (string)GetValue(MinPriceProperty);
            set => SetValue(MinPriceProperty, value);
        }

        public string MaxPrice
        {
            get => (string)GetValue(MaxPriceProperty);
            set => SetValue(MaxPriceProperty, value);
        }
      
        
        public bool IsAdmin => _currentUser?.Role == "admin";
        public ICommand AddShipCommand { get; }
        public ICommand AdminPanelCommand { get; }
        public static  readonly RoutedUICommand UserProfileCommand = new RoutedUICommand(
            "UserProfileCommand", "UserProfileCommand", typeof(ItemsListViewModel));//изменить
        public ICommand ShipDetailsCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }

        private Stack<ShipModel> _addedShips = new Stack<ShipModel>();
        private Stack<ShipModel> _removedShips = new Stack<ShipModel>();
        private Stack<ActionItem> _redoStack = new Stack<ActionItem>();
        private string _lastAction;

        public ItemsListViewModel()
        {

        }
        public ItemsListViewModel(UserModel user)
        {
            _currentUser = user;
            Ships = new ObservableCollection<ShipModel>(ShipListModel.LoadFromJson(ShipListModel._filepath));

            AddShipCommand = new RelayCommand(AddShip);
            AdminPanelCommand = new RelayCommand(OpenAdminPanel);
            //UserProfileCommand = new RelayCommand(OpenUserProfile);
            ShipDetailsCommand = new RelayCommand<ShipModel>(OpenShipDetails);
            UndoCommand = new RelayCommand(Undo, CanUndo);
            RedoCommand = new RelayCommand(Redo, CanRedo);
        }
        private void AddShip()
        {
            var addShipWindow = new AddShipWindow(Ships.Count, "тест");
            if(addShipWindow.ShowDialog() == true)
            {
              
            }
            var newShip = (addShipWindow.DataContext as AddShipWindowViewModel).NewShip;
            Ships.Add(newShip);
            allships.Add(newShip);
            _addedShips.Push(newShip);
            _lastAction = "Add";
            _redoStack.Clear();
        }
        private void OpenAdminPanel()
        {
            var adminPanel = new adminPanel(Ships.ToList());
            if (adminPanel.ShowDialog() == true)
            {
              
            }
            Ships = new ObservableCollection<ShipModel>(adminPanel.refreshShipList());
        }
       

        //public void OpenUserProfile()//сменить на private
        //{
        //    var userPage = new userpage(_currentUser);
        //    Application.Current.Windows.OfType<ItemsList>().FirstOrDefault()?.Close();
        //    userPage.Show();
        //}

        private void OpenShipDetails(ShipModel ship)
        {
           
            if (ship != null)
            {
                var shipDetails = new ShipDetails(ship);
                shipDetails.ShowDialog();
            }

        }
        private void FilterShips()
        {
          

            int minPrice = 0;
            int maxPrice = int.MaxValue;
            if (!string.IsNullOrEmpty(MinPrice))
                int.TryParse(MinPrice, out minPrice);

            if (!string.IsNullOrEmpty(MaxPrice))
                int.TryParse(MaxPrice, out maxPrice);//вернуть проверку

            if (maxPrice <= minPrice)
            {
                maxPrice = int.MaxValue;
            }
            var filtered = allships
                .Where(s => string.IsNullOrEmpty(FilterName) || s.Name.ToLower().Contains(FilterName?.ToLower() ?? ""))
                .Where(s => s.Price >= minPrice)
                .Where(s => s.Price <= maxPrice)
                .ToList();

            Ships = new ObservableCollection<ShipModel>(filtered);
        }
        private bool CanUndo() => _lastAction != null;
        private bool CanRedo() => _redoStack.Count > 0;
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var item = _redoStack.Pop();
                switch (item.Action)
                {
                    case "Add":
                        Ships.Add(item.Ship);
                        _addedShips.Push(item.Ship);
                        _lastAction = "Add";
                        break;

                    case "Remove":
                        Ships.Remove(item.Ship);
                        _removedShips.Push(item.Ship);
                        _lastAction = "Remove";
                        break;
                }
                (UndoCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (RedoCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
        public void Undo()
        {
            if (_lastAction != null)
            {
                switch (_lastAction)
                {
                    case "Add":
                        var lastAdded = _addedShips.Pop();
                        Ships.Remove(lastAdded);
                        _redoStack.Push(new ActionItem("Add", lastAdded));
                        break;

                    case "Remove":
                        var lastRemoved = _removedShips.Pop();
                        Ships.Add(lastRemoved);
                        _redoStack.Push(new ActionItem("Remove", lastRemoved));
                        break;
                }
                _lastAction = null;
                (UndoCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (RedoCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
