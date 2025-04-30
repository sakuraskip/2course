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
using System.Collections.ObjectModel;


namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для adminPanel.xaml
    /// </summary>
    public partial class adminPanel : Window
    {
        public adminPanel(List<ShipModel> shipModels)
        {
            InitializeComponent();

            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani");
            this.Cursor = customCursor;

            var model = new AdminPanelViewModel(shipModels);

            DataContext = model;
        }
        public ObservableCollection<ShipModel> refreshShipList()
        {
            return (DataContext as AdminPanelViewModel).GetUpdatedShips();
        }
    }
}
