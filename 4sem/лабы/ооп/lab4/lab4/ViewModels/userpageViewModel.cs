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
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace lab4.ViewModels
{
    public class UserPageViewModel:INotifyPropertyChanged
    {
        private UserModel _ourUser;
        private string _currentTheme = "White";
        private ObservableCollection<Request> _rentals;
        public ICommand EditProfileCommand { get; }
        public ICommand ChangeLanguageCommand { get; }
        public ICommand ChangeThemeCommand { get; }
        public ICommand BackToCatalogCommand { get; }

        public ICommand CancelRentCommand { get; }

        private string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public UserPageViewModel(UserModel user)
        {
            _ourUser = user;
            EditProfileCommand = new RelayCommand(EditProfile);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            BackToCatalogCommand = new RelayCommand(BackToCatalog);
            CancelRentCommand = new RelayCommand<Request>(CancelRent);
            LoadRentals();
        }
        public UserPageViewModel()
        {
            EditProfileCommand = new RelayCommand(EditProfile);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            ChangeThemeCommand = new RelayCommand(ChangeTheme);
            BackToCatalogCommand = new RelayCommand(BackToCatalog);
        }
        private void LoadRentals()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select * from Rental where UserId = @UserId", connection);
                
                command.Parameters.AddWithValue("@UserId",OurUser.Id);
                using (var reader = command.ExecuteReader())
                {
                    Rentals = new ObservableCollection<Request>();
                    while (reader.Read())
                    {
                        Rentals.Add(new Request
                            (
                            id: reader.GetInt32(reader.GetOrdinal("Id")),
                            shipId:reader.GetInt32(reader.GetOrdinal("shipId")),
                            userId:reader.GetInt32(reader.GetOrdinal("userId")),
                            date:reader.GetDateTime(reader.GetOrdinal("RentDate")),
                            status: reader["Status"].ToString(),
                            cost:reader.GetInt32(reader.GetOrdinal("Cost")),
                            
                            imagePath: reader["ImagePath"].ToString(),
                            shipname: reader["ShipName"].ToString()


                            ));
                    }

                }
                

            }
        }
        public ObservableCollection<Request> Rentals
        {
            get => _rentals;
            set
            {
                _rentals = value;
                OnPropertyChanged();
            }
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

        private async void CancelRent(Request rental)
        {
            if (MessageBox.Show(
        $"Вы действительно хотите отменить аренду '{rental.shipName}'?\nДата аренды: {rental.Date.ToShortDateString()}",
        "Запрос на отмену аренды",
        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        await connection.OpenAsync();
                        using (var command = new SqlCommand(
                            "insert into CancelledRentals (userId,rentalId,status) values (@userId,@rentalId,'Ожидание отмены')",connection))
                        {
                            command.Parameters.AddWithValue("@userId", _ourUser.Id);
                            command.Parameters.AddWithValue("@rentalId", rental.Id);
                            await command.ExecuteNonQueryAsync();

                        }
                        using (var command = new SqlCommand("update Rental set status = 'Ожидание отмены' where Id = @Id",connection))
                        {
                            command.Parameters.AddWithValue("@Id", rental.Id);
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                        LoadRentals();
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cancel rent error: " + ex.Message);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
