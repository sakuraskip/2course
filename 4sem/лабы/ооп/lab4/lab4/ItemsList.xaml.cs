using lab4.userControls;
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
using System.Diagnostics;
using lab4.Events;


namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для ItemsList.xaml
    /// </summary>
    public partial class ItemsList : Window
    {
        public ItemsList(UserModel user)
        {
            InitializeComponent();
            DataContext = new ItemsListViewModel(user);
            HeaderPanel panel = new HeaderPanel(DataContext as ItemsListViewModel,user);
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani", true);
            this.Cursor = customCursor;
            Grid.SetColumn(panel, 0);
            Grid.SetColumnSpan(panel, 2);
            panel.CustomButtonClick += HeaderPanel_CustomButtonClick;
            panel.CustomButtonTunnel += HeaderPanel_CustomButtonTunnel;
           
            CommandBindings.Add(new CommandBinding(ItemsListViewModel.UserProfileCommand, OpenUserProfile));
         
        }



        private void HeaderPanel_CustomButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Custom button clicked! direct");
        }
        private void HeaderPanel_CustomButtonTunnel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tunneling event sender: " + sender);
        }
        public void OpenUserProfile(object sender, ExecutedRoutedEventArgs e)//сменить на private
        {
            var userPage = new userpage((DataContext as ItemsListViewModel)._currentUser);
            Application.Current.Windows.OfType<ItemsList>().FirstOrDefault()?.Close();
            userPage.Show();
        }
    }
}
