using Microsoft.Win32;
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
    /// Логика взаимодействия для editUserData.xaml
    /// </summary>
    public partial class editUserData : Window
    {
        public editUserData(UserModel user,string profilepic)
        {
            InitializeComponent();

            EditUserDataViewModel model = new EditUserDataViewModel(user,profilepic);
            if(model.CloseAction==null)
            {
                model.CloseAction = new Action(() => this.Close());
            }
            DataContext = model;
        }
        private void PasswordBox_PassChanged(object sender, RoutedEventArgs e)
        {
            if(this.DataContext!=null)
            {
                ((EditUserDataViewModel)this.DataContext).PasswordBuffer = ((PasswordBox)sender).Password;
            }
        }
    }

   
}



