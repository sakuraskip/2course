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
        static string path = "C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\ships.json";
        public ShipList Items {  get; set; } = new ShipList();
        public ItemsList()
        {
            InitializeComponent();
            Items.ships = ShipList.LoadFromJson(path);
            shipsControl.ItemsSource = Items.ships;
        }
        
        
    }
}
