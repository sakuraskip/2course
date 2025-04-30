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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4.userControls
{
    /// <summary>
    /// Логика взаимодействия для header.xaml
    /// </summary>
    public partial class HeaderPanel : UserControl
    {
        public static readonly RoutedEvent CustomButtonClickEvent =
            EventManager.RegisterRoutedEvent("CustomButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HeaderPanel));//удалить
        public event RoutedEventHandler CustomButtonClick
        {
            add { AddHandler(CustomButtonClickEvent, value); }
            remove { RemoveHandler(CustomButtonClickEvent, value); }
        }//удалить
        private void OnCustomButtonClick()
        {
            RoutedEventArgs args = new RoutedEventArgs(CustomButtonClickEvent);
            RaiseEvent(args);
        }//удалить
        public static readonly RoutedEvent CustomButtonTunnelEvent =
    EventManager.RegisterRoutedEvent("CustomButtonTunnel", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(HeaderPanel));

        public event RoutedEventHandler CustomButtonTunnel
        {
            add { AddHandler(CustomButtonTunnelEvent, value); }
            remove { RemoveHandler(CustomButtonTunnelEvent, value); }
        }

        // Вызов туннелируемого события
        private void OnCustomButtonTunnel()
        {
            RoutedEventArgs args = new RoutedEventArgs(CustomButtonTunnelEvent);
            RaiseEvent(args); // Туннелирование события
        }
        private void CustomButton_Click(object sender, RoutedEventArgs e)
        {
            OnCustomButtonClick();
            OnCustomButtonTunnel();
        }//удадить
        public HeaderPanel(ItemsListViewModel list,UserModel user1)
        {
            InitializeComponent();
            var model = new HeaderViewModel(list, user1);
            DataContext = model;
        }
        public HeaderPanel() { }

        
    }
}
