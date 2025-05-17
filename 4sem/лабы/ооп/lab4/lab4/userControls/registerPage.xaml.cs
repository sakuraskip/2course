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
    /// Логика взаимодействия для registerPage.xaml
    /// </summary>
    public partial class registerPage : Window
    {
        public registerPage()
        {
            InitializeComponent();
            var model = new RegisterViewModel();
            model.CloseAction = () => { this.Close(); };
            DataContext = model;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((RegisterViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;

        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            ((RegisterViewModel)this.DataContext).ConfirmPassword = ((PasswordBox)sender).Password;

        }
    }
}
