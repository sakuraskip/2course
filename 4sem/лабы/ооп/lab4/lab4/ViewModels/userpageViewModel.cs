using lab4.userControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4.ViewModels
{
    public class UserPageViewModel:INotifyPropertyChanged
    {
        private UserModel _ourUser;
        private string _currentTheme = "White";
        public ICommand EditProfileCommand { get; }
        public ICommand ChangeLanguageCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand BackToCatalogCommand { get; }

        public ICommand CancelRentCommand { get; }

        public UserPageViewModel(UserModel user)
        {
            _ourUser = user;
            EditProfileCommand = new RelayCommand(EditProfile);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            BackToCatalogCommand = new RelayCommand(BackToCatalog);
            CancelRentCommand = new RelayCommand(CancelRent);
        }
        public UserPageViewModel()
        {
            EditProfileCommand = new RelayCommand(EditProfile);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            BackToCatalogCommand = new RelayCommand(BackToCatalog);
        }

        public UserModel OurUser
        {
            get => _ourUser;
            set
            {
                _ourUser = value;
                OnPropertyChanged();
            }
        }

        private void EditProfile()
        {
            var editUserData = new editUserData(OurUser, OurUser.ProfilePicturePath);
            editUserData.ShowDialog();
            
                OurUser = (editUserData.DataContext as  EditUserDataViewModel).ReturnUserData();
            
        }

        private void ChangeLanguage()//добавить в funcs
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

        private void ChangeTheme()
        {
            _currentTheme = Funcs.ChangeTheme(_currentTheme);
        }

        private void BackToCatalog()
        {
            ItemsList newWindow = new ItemsList(OurUser);
            Application.Current.Windows.OfType<userpage>().First().Hide();
            newWindow.Show();
            Application.Current.Windows.OfType<userpage>().First().Close();
        }

        private void CancelRent()
        {
            return;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
