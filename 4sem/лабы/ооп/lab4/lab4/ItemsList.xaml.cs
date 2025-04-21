using lab4.userControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для ItemsList.xaml
    /// </summary>
    public partial class ItemsList : Window
    {
        public static readonly RoutedUICommand AddShipCommand = new RoutedUICommand("Добавить судно", "AddShipCommand", typeof(ItemsList));
        public static readonly RoutedUICommand AdminPanelCommand = new RoutedUICommand("Админ панель", "AdminPanelCommand", typeof(ItemsList));
        static string path = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\ships.json";

        private Stack<Ship> addedShips = new Stack<Ship>();
        private Stack<Ship> removedShips = new Stack<Ship>();

        private Stack<ActionItem> redoStack = new Stack<ActionItem>();
        private static string LastAction { get; set; }

        private User user;
        public ShipList Items {  get; set; } = new ShipList();
        public ItemsList(User user)
        {
            InitializeComponent();
            goToYachts.Visibility = Visibility.Collapsed;
            this.user = user;
            if(user.Role !="admin")
            {
                admin_addship.Visibility = Visibility.Hidden;
                admin_adminpanel.Visibility = Visibility.Hidden;
            }
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani",true);
            this.Cursor = customCursor;
            
            CommandBindings.Add(new CommandBinding(AddShipCommand, addShip_Button));
            CommandBindings.Add(new CommandBinding(AdminPanelCommand, AdminPanelButton_Click));

            Items.ships = ShipList.LoadFromJson(path);
            shipsControl.ItemsSource = Items.ships;

            HeaderPanel panel = new HeaderPanel(this,this.user);
            Grid.SetRow(panel, 0);
            Grid.SetColumnSpan(panel, 2);

            maingrid.Children.Insert(0, panel);
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            adminPanel adminpanel = new adminPanel(Items.ships);
            adminpanel.ShowDialog();

            refreshShipList(adminpanel.refreshShipList());
        }
        private  void refreshShipList(List<Ship> newlist)
        {
            shipsControl.ItemsSource = null;
            Items.ships = newlist;
            shipsControl.ItemsSource = Items.ships;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;

            if(border.DataContext!= null)
            {
                ShipDetails shipDetails = new ShipDetails(border.DataContext as Ship);
                shipDetails.ShowDialog();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)// by name
        {
            filterShips();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)// price
        {
            filterShips();
        }
        private void filterShips()
        {
            string shipname = filterName_textbox.Text.ToLower();

            int minprice = 0;
            int maxprice = int.MaxValue;
            if (int.TryParse(minPrice_textbox.Text, out int min))
            {
                minprice = min;
            }
            if (int.TryParse(maxprice_textbox.Text, out int max))
            {
                maxprice = max;
            }

            var filteredShips = Items.ships.Where(ship => ship.Name.ToLower().Contains(shipname) && ship.Price >= minprice && ship.Price <= maxprice).ToList();

            shipsControl.ItemsSource = filteredShips;
        }

        private void addShip_Button(object sender, RoutedEventArgs e)
        {
            AddShipWindow addShip = new AddShipWindow(Items.ships.Count, "тест");
            if(addShip.ShowDialog() == true)
            {
                Ship newship = addShip.newShip;
                this.Add(newship);
                shipsControl.ItemsSource = null;
                shipsControl.ItemsSource = Items.ships;
            }
        }

        private void usercabinet_button_Click(object sender, RoutedEventArgs e)
        {
            userControls.userpage page = new userControls.userpage(user);
            this.Close();
            page.Show();
        }
        public void Add(Ship ship)
        {
            Items.ships.Add(ship);
            addedShips.Push(ship);
            LastAction = "Add";
            redoStack.Clear();
        }

        public void Remove(Ship ship)
        {
            Items.ships.Remove(ship);
            removedShips.Push(ship);
            LastAction = "Remove";
            redoStack.Clear();
        }

        public void Undo()
        {
            if (LastAction != null)
            {
                switch (LastAction)
                {
                    case "Add":
                        var lastAdded = addedShips.Pop();
                        Items.ships.Remove(lastAdded);
                        redoStack.Push(new ActionItem("Add", lastAdded));
                        break;

                    case "Remove":
                        var lastRemoved = removedShips.Pop();
                        Items.ships.Add(lastRemoved);
                        redoStack.Push(new ActionItem("Remove", lastRemoved));
                        break;
                }
            }
            LastAction = null;
            refreshShipList(Items.ships);
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                ActionItem item = redoStack.Pop();
                switch (item.Action)
                {
                    case "Add":
                        Items.ships.Add(item.Ship);
                        addedShips.Push(item.Ship);
                        LastAction = "Add"; 
                        break;

                    case "Remove":
                        Items.ships.Remove(item.Ship);
                        removedShips.Push(item.Ship);
                        LastAction = "Remove"; 
                        break;
                }
            }
            refreshShipList(Items.ships);
        }
    }
}
