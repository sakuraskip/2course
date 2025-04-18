using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для userpage.xaml
    /// </summary>
    public partial class userpage : Window
    {
        private User ourUser { get; set; }
        public userpage(User user)
        {
            InitializeComponent();
            ourUser = user;
            DataContext = ourUser;
            
        }

        private void editProfileClick(object sender, RoutedEventArgs e)
        {
            editUserData editUserData = new editUserData(ourUser);
            if(editUserData.ShowDialog() == true )
            {
                ourUser = editUserData.returnUserData();
                DataContext = ourUser;
            }
        }

        private void ChangeLanguage(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName == "ENU")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("dictionary/strings.ru.xaml", UriKind.Relative)
                });



            }
            else if (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName == "RUS")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("dictionary/strings.en.xaml", UriKind.Relative)
                });

            }
            var currentWindow = Application.Current.Windows.OfType<userpage>().FirstOrDefault();
            if (currentWindow != null)
            {
                currentWindow.Close();
                var newWindow = new userpage(ourUser);
                newWindow.Show();
            }
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            //>.<
        }
    }
}
