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
    /// Логика взаимодействия для requestToBook.xaml
    /// </summary>
    public partial class requestToBook : Window
    {
        public static readonly RoutedUICommand ConfirmCommand = new RoutedUICommand("Подтвердить", "ConfirmCommand", typeof(requestToBook));
        public requestToBook()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ConfirmCommand, ConfirmButton_Executed));
        }

        private async void ConfirmButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Валидация полей
            confirmbutton.Content = "Обработка...";
            await Task.Delay(2000);
            MessageBox.Show("Заявка принята");
            this.Close();
        }
    }
}
