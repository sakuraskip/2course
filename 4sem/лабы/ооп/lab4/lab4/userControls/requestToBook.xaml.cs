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

namespace lab4.userControls
{
    /// <summary>
    /// Логика взаимодействия для requestToBook.xaml
    /// </summary>
    public partial class requestToBook : Window
    {
        public requestToBook(ShipModel ship,UserModel user)
        {
            InitializeComponent();
            var model = new RequestToBookViewModel(ship,user);
            model.CloseAction = () => this.Close();
            DataContext = model;
        }

        
    }
}
