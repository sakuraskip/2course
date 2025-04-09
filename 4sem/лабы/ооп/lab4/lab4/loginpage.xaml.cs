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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для loginpage.xaml
    /// </summary>
    public partial class loginpage : Window
    {
        User user;
        public loginpage()
        {
            InitializeComponent();
          
        }

        private void ChangeLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            string test = Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName;
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
            this.InitializeComponent();

        }

        private void login_button(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(username_text.Text) && !string.IsNullOrEmpty(password_text.Text))
            {
                user = new User(username_text.Text, password_text.Text);
                ItemsList newwindow = new ItemsList(user);
                this.Close();
                newwindow.Show();
               
            }
        }
    }
}
