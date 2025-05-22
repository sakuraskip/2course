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
            var model = new ItemsListViewModel(user);
            model.CloseAction = () => { this.Close(); };
            DataContext = model;
            Cursor customCursor = new Cursor("C:\\Users\\леха\\Desktop\\2_aero_busy.ani", true);
            this.Cursor = customCursor;
            
           
         
        }



        
        //public void OpenUserProfile(object sender, ExecutedRoutedEventArgs e)//сменить на private
        //{
        //    var userPage = new userpage((DataContext as ItemsListViewModel)._currentUser);
        //    Application.Current.Windows.OfType<ItemsList>().FirstOrDefault()?.Close();
        //    userPage.Show();
        //}
    }
}
