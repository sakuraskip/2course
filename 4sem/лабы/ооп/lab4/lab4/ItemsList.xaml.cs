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
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani");
            this.Cursor = customCursor;
            CommandBindings.Add(new CommandBinding(AddShipCommand, addShip_Button));
            CommandBindings.Add(new CommandBinding(AdminPanelCommand, AdminPanelButton_Click));
            Items.ships = ShipList.LoadFromJson(path);
            shipsControl.ItemsSource = Items.ships;
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
                Items.ships.Add(newship);
                shipsControl.ItemsSource = null;
                shipsControl.ItemsSource = Items.ships;
            }
        }
    }
}
