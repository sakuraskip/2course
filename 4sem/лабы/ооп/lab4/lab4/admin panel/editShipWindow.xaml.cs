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
    /// Логика взаимодействия для editShipWindow.xaml
    /// </summary>
    public partial class editShipWindow : Window
    {
        private Ship editShip;
        public editShipWindow(Ship ship) //  сделать глобальное редактирование, с записью в файл
        {
            InitializeComponent();
            this.editShip = ship;
            NameTextBox.Text = ship.Name;
            DescriptionTextBox.Text = ship.Description;
            PriceTextBox.Text = ship.Price.ToString();

            if(!string.IsNullOrEmpty(ship.Photopath))
            {
                ShipImage.Source = new BitmapImage(new Uri(ship.Photopath, UriKind.RelativeOrAbsolute));
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            editShip.Name = NameTextBox.Text;
            editShip.Description = DescriptionTextBox.Text;

            if(int.TryParse(PriceTextBox.Text, out int price))
            {
                editShip.Price = price;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
