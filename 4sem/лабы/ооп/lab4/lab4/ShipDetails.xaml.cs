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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для ShipDetails.xaml
    /// </summary>
    public partial class ShipDetails : Window
    {
        public ShipDetails(Ship detailship)
        {
            InitializeComponent();
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani");
            this.Cursor = customCursor;
            DataContext = detailship;
            
            price_textblock.Text += detailship.Price;
            price_textblock.Text.Append('$');
            avaliable_textblock.Text += detailship.avaliable;
        }

        private void rent_button(object sender, RoutedEventArgs e)
        {
            lab4.userControls.requestToBook reqWindow = new userControls.requestToBook();
            reqWindow.ShowDialog();
        }
    }
}
