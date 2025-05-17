using lab4.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace lab4
{
    public partial class loginpage : Window
    {
        
        public loginpage()
        {
            InitializeComponent();
            var model = new LoginViewModel();
            model.CloseAction = () => { this.Close(); };
            DataContext = model;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((LoginViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}