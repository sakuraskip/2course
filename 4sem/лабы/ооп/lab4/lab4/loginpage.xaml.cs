using lab4.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace lab4
{
    public partial class loginpage : Window
    {
        
        public loginpage()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

       
    }
}