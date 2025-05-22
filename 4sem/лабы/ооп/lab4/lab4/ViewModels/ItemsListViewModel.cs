using lab4.Models;
using lab4.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        private List<ShipModel> allships;
        private string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private ObservableCollection<Review> _reviews;
        private string _selectedFilterType = "Все";
        public string SelectedFilterType
        {
            get => _selectedFilterType;
            set
            {
                _selectedFilterType = value;
                OnPropertyChanged();
                ApplyFilters(); 
            }
        }
        public IEnumerable<string> FilterTypes => new[]
 {
    (string)Application.Current.FindResource("FilterAll"),
    (string)Application.Current.FindResource("FilterBoats"),
    (string)Application.Current.FindResource("FilterYachts")
};



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
            vm?.ApplyFilters();
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
            set { _filterName = value; OnPropertyChanged(); ApplyFilters(); }
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
        public ICommand UserProfileCommand { get; }
        public ICommand ShipDetailsCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand ShowAllYachtsCommand { get; }
        public ICommand LogoutCommand { get; }

        private Stack<ShipModel> _addedShips = new Stack<ShipModel>();
        private Stack<ShipModel> _removedShips = new Stack<ShipModel>();
        private Stack<ActionItem> _redoStack = new Stack<ActionItem>();
        private string _lastAction;

        public Action CloseAction { get; set; }

        public ItemsListViewModel()
        {

        }
        public ItemsListViewModel(UserModel user)
        {
            _currentUser = user;
           
            AddShipCommand = new RelayCommand(AddShip);
            AdminPanelCommand = new RelayCommand(OpenAdminPanel);
            UserProfileCommand = new RelayCommand(OpenUserProfile);
            ShipDetailsCommand = new RelayCommand<ShipModel>(OpenShipDetails);
            UndoCommand = new RelayCommand(Undo, CanUndo);
            RedoCommand = new RelayCommand(Redo, CanRedo);
            LogoutCommand = new RelayCommand(Logout);
            LoadAllShips(); 
            LoadReviews();
            

        }
        private void Logout()
        {

            
            var loginWindow = new loginpage(); 
            loginWindow.Show();
            CloseAction?.Invoke();

        }
        private async void LoadAllShips()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand("SELECT * FROM ShipModel", connection))
                        {
                            var ships = new List<ShipModel>();
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    ships.Add(new ShipModel(
                                   id: reader.GetInt32(reader.GetOrdinal("Id")),
                                   name: reader["Name"].ToString(),
                                   description: reader["Description"].ToString(),
                                   price: reader.GetInt32(reader.GetOrdinal("Price")),
                                   availability: reader["Availability"].ToString(),
                                   imagePath: reader["ImagePath"].ToString(),
                                   shipType: reader["ShipType"].ToString(),
                                   shortdesc: reader["ShortDescription"].ToString(),
                                   filterType: reader["FilterType"].ToString(),
                                    rating: reader.GetDouble(reader.GetOrdinal("Rating"))));
                                }
                            }
                                allships = ships;
                            Ships = new ObservableCollection<ShipModel>(ships);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки судов: {ex.Message}");
            }
        }
        private void LoadReviews()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM Reviews", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var reviews = new ObservableCollection<Review>();
                            while (reader.Read())
                            {
                                reviews.Add(new Review(
                                    id: reader.GetInt32(reader.GetOrdinal("Id")),
                                    userId: reader.GetInt32(reader.GetOrdinal("UserId")),
                                    username: reader["Username"].ToString(),
                                    shipId: reader.GetInt32(reader.GetOrdinal("ShipId")),
                                    comment: reader["Comment"].ToString(),
                                    rating: reader.GetInt32(reader.GetOrdinal("Rating"))));
                            }
                            _reviews = reviews;
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
       

        private void AddShip()
        {
            var addShipWindow = new AddShipWindow(Ships.Count, "уникальный");
            if(addShipWindow.ShowDialog() == true)
            {
              
            }
            var newShip = (addShipWindow.DataContext as AddShipWindowViewModel).NewShip;
            if (newShip != null)
            {
                Ships.Add(newShip);
                allships.Add(newShip);
                _addedShips.Push(newShip);
                _lastAction = "Add";
                _redoStack.Clear();
            }
           
        }
        private void OpenAdminPanel()
        {
            var adminPanel = new adminPanel(Ships.ToList());
            adminPanel.ShowDialog();
            
            Ships = new ObservableCollection<ShipModel>(adminPanel.refreshShipList());
        }
       

        private void OpenUserProfile()//сменить на private
        {
            var userPage = new userpage(_currentUser);
            Application.Current.Windows.OfType<ItemsList>().FirstOrDefault()?.Close();
             userPage.Show();
        }

        private void OpenShipDetails(ShipModel ship)
        {
           
            if (ship != null)
            {
                var shipDetails = new ShipDetails(ship,_currentUser,_reviews);
                shipDetails.ShowDialog();
            }

        }
        private void ApplyFilters()
        {
            if (allships == null) return;

            var filtered = allships.AsEnumerable();

            if (SelectedFilterType == "Катера" || SelectedFilterType == "Boats")
                filtered = filtered.Where(s => s.FilterType == "Катер");
            else if (SelectedFilterType == "Яхты" || SelectedFilterType == "Yachts")
                filtered = filtered.Where(s => s.FilterType == "Яхта");

            if (!string.IsNullOrEmpty(MinPrice) && int.TryParse(MinPrice, out int minPrice))
                filtered = filtered.Where(s => s.Price >= minPrice);

            if (!string.IsNullOrEmpty(MaxPrice) && int.TryParse(MaxPrice, out int maxPrice))
                filtered = filtered.Where(s => s.Price <= maxPrice);

            if (!string.IsNullOrEmpty(FilterName))
                filtered = filtered.Where(s => s.Name.Contains(FilterName, StringComparison.OrdinalIgnoreCase));

            Ships = new ObservableCollection<ShipModel>(filtered.ToList());
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
