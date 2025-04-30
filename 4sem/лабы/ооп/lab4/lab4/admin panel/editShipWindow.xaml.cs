using lab4.ViewModels;
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
        public ShipModel edited => (DataContext as EditShipViewModel).EditedShip;

        public editShipWindow(ShipModel ship)
        {
            InitializeComponent();
            var model = new EditShipViewModel(ship);
            model.CloseAction = () => this.Close();
            DataContext = model;
        }
    }
}
