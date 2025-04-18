using Microsoft.Win32;
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
    /// Логика взаимодействия для editUserData.xaml
    /// </summary>
    public partial class editUserData : Window
    {
        private User ourUser {  get; set; }
        public string profilePicBuffer { get; set; }
        public editUserData(User user)
        {
            InitializeComponent();
            ourUser = user;
            DataContext = ourUser;
        }

        private void ProfileImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                string sourcePath = openFileDialog.FileName;
                profilePicBuffer = sourcePath;
                ProfileImage.Source = new BitmapImage(new Uri(sourcePath));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Error_TextBlock.Text = "";
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                Error_TextBlock.Text = "Заполните логин корректно";
                return;
            }
            if (PasswordBox.Password != ourUser.password)
            {
                Error_TextBlock.Text = "Неверный пароль";
                return;
            }
            ourUser.username = NameTextBox.Text;
           ourUser.profilePicturePath = profilePicBuffer;
            
        }
        public User returnUserData()
        {
            return ourUser;
        }
    }
}
