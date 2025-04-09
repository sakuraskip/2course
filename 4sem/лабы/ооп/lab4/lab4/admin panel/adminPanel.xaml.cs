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
    /// Логика взаимодействия для adminPanel.xaml
    /// </summary>
    public partial class adminPanel : Window
    {
        List<Ship> adminShips;
        public adminPanel(List<Ship> ships)
        {
            InitializeComponent();
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani");
            this.Cursor = customCursor;
            adminShips = ships;
            ShipList.ItemsSource = ships;
        }
        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button != null && button.DataContext != null)
            {
                editShipWindow edit = new editShipWindow(button.DataContext as Ship);
                if(edit.ShowDialog() == true)
                {
                    ShipList.ItemsSource = null;
                    ShipList.ItemsSource = adminShips;
                }
            }
        }
        public void DeleteButton_Click(object sender, RoutedEventArgs e)// cделать глобальное удаление плностью из файла
        {
            var button = sender as Button;
            if (button.DataContext != null)
            {
               adminShips.Remove(button.DataContext as Ship);
                ShipList.ItemsSource = null;
                ShipList.ItemsSource = adminShips;
            }
        }
        public List<Ship> refreshShipList()
        {
            return adminShips;
        }

    }
}
