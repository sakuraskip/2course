﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using lab4.adminViewModels;
namespace lab4.admin_panel
{
    /// <summary>
    /// Логика взаимодействия для EditRentalWindow.xaml
    /// </summary>
    public partial class EditRentalWindow : Window
    {
        public EditRentalWindow(Request request,SqlConnection connection)
        {
            InitializeComponent();
            DataContext = new EditRentalViewModel(request);
        }
    }
}
