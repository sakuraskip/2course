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
        private string currentTheme = "White";
        public userpage(User user)
        {
            InitializeComponent();
            ourUser = user;
            DataContext = ourUser;
            
        }

        private void editProfileClick(object sender, RoutedEventArgs e)
        {
            editUserData editUserData = new editUserData(ourUser,ourUser.ProfilePicturePath);
            if(editUserData.ShowDialog() == true )
            {
                ourUser = editUserData.returnUserData();
                DataContext = ourUser;
            }
        }

        private void ChangeLanguage(object sender, RoutedEventArgs e)
        {
            ResourceDictionary newLanguageDictionary = new ResourceDictionary();
            string languageUri;

            if (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName == "ENU")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                languageUri = "dictionary/strings.ru.xaml";
            }
            else if (Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName == "RUS")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                languageUri = "dictionary/strings.en.xaml";
            }
            else
            {
                return; 
            }

            var currentLanguageDictionary = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source.ToString().Contains("strings"));

            if (currentLanguageDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentLanguageDictionary);
            }

            newLanguageDictionary.Source = new Uri(languageUri, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(newLanguageDictionary);
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            currentTheme = Funcs.ChangeTheme(currentTheme);
        }

        private void BackToCatalog(object sender, RoutedEventArgs e)
        {
            ItemsList newwindow = new ItemsList(ourUser);
            this.Hide();
            newwindow.Show();
            this.Close();
        }
    }
}
