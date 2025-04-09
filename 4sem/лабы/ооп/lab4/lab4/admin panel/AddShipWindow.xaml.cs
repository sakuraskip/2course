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
        public static readonly RoutedUICommand AddShipCommand = new RoutedUICommand("Добавить судно", "AddShipCommand", typeof(AddShipWindow));
        public static readonly RoutedUICommand SelectFileCommand = new RoutedUICommand("Добавить изображение", "SelectFileCommand", typeof(AddShipWindow));

        private static int shiplistLength;
        private static string shipType;
        public Ship newShip { get; private set; }

        public AddShipWindow(int length, string shiptype)
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(AddShipCommand, AddShipCommand_Executed));
            CommandBindings.Add(new CommandBinding(SelectFileCommand, SelectFileCommand_Executed));
            shiplistLength = length;
            shipType = shiptype;

        }

        private void AddShipCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || !int.TryParse(PriceTextBox.Text, out int price) || string.IsNullOrWhiteSpace(PhotopathTextBox.Text))
            {
                MessageBox.Show("Неверно заполнены поля");
                return;
            }
            newShip = new Ship(shiplistLength + 1, NameTextBox.Text, DescriptionTextBox.Text, price, "Модель в наличии", PhotopathTextBox.Text, shipType);
            this.DialogResult = true;
            this.Close();
        }

        private void SelectFileCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                Title = "Выбрать картинку"
            };

            if (ofd.ShowDialog() == true)
            {
                PhotopathTextBox.Text = ofd.FileName;
                ImagePreview.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
    }
}