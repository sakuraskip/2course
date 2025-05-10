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
using lab4.ViewModels;
namespace lab4.userControls
{
    /// <summary>
    /// Логика взаимодействия для AddReviewWindow.xaml
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        public AddReviewWindow(UserModel user)
        {
            InitializeComponent();
            var model = new ViewModels.AddReviewViewModel(user);
            model.CloseAction = new Action(() => this.Close());
            DataContext = model;
        }
    }
}
