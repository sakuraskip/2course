using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для loginpage.xaml
    /// </summary>
    public partial class loginpage : Window
    {
        User user;
        public loginpage()
        {
            InitializeComponent();
          
        }

       

        private void login_button(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(username_text.Text) && !string.IsNullOrEmpty(password_text.Text))
            {
                user = new User(username_text.Text, password_text.Text);
                ItemsList newwindow = new ItemsList(user);
                this.Close();
                newwindow.Show();
               
            }
        }
    }
}
