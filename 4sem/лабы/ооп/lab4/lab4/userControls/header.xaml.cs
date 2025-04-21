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

namespace lab4.userControls
{
    /// <summary>
    /// Логика взаимодействия для header.xaml
    /// </summary>
    public partial class HeaderPanel : UserControl
    {
        ItemsList catalog {  get; set; }
        User user { get; set; }
        public HeaderPanel(ItemsList list,User user1)
        {
            InitializeComponent();
            catalog = list;
            user = user1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            catalog.Undo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            catalog.Redo();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            userpage newwindow = new userpage(user);
            parent.Close();
            newwindow.Show();
        }
    }
}
