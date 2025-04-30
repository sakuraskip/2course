using lab4.ViewModels;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace lab4
{
    public partial class AddShipWindow : Window
    {
       public AddShipWindow(int length, string shipType)
        {
            InitializeComponent();
            var model = new AddShipWindowViewModel(length, shipType);
            model.CloseAction = () => this.Close();
            DataContext  = model;
        }
    }
}