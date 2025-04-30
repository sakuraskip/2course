using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using lab4.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace lab4.ViewModels
{
    public class EditUserDataViewModel:INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private UserModel _user;
        private string _errorMessage;
        private string _profilePicBuffer;
        private BitmapImage _profileImage;
        private string _passwordBuffer;
        private string _username;

        public event Action<UserModel> UserChanged;
        
        public string PasswordBuffer
        {
            get => _passwordBuffer;
            set { _passwordBuffer = value; OnPropertyChanged(); }
        }
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public string ProfilePicBuffer
        {
            get => _profilePicBuffer;
            set
            {
                _profilePicBuffer = value;
                OnPropertyChanged();
            }
        }

        public BitmapImage ProfileImage
        {
            get => _profileImage;
            set
            {
                _profileImage = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeProfileImageCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand CloseCommand { get; }

        public EditUserDataViewModel(UserModel user, string profilePic)
        {
            User = user;
            ProfilePicBuffer = profilePic;

            if (!string.IsNullOrEmpty(profilePic))
            {
                ProfileImage = new BitmapImage(new Uri(profilePic));
            }

            ChangeProfileImageCommand = new RelayCommand(ChangeProfileImage);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(CloseAction);
        }
        public EditUserDataViewModel()
        {
            ChangeProfileImageCommand = new RelayCommand(ChangeProfileImage);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(CloseAction);
        }
        private void ChangeProfileImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите изображение",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ProfilePicBuffer = openFileDialog.FileName;
                ProfileImage = new BitmapImage(new Uri(ProfilePicBuffer));
            }
        }

        private void Save()
        {
            ErrorMessage = "";

            if (string.IsNullOrEmpty(User.Username))
            {
                ErrorMessage = "Заполните логин корректно";
                return;
            }
            if(PasswordBuffer!= User.Password)
            {
                ErrorMessage = "Введен неверный пароль";
                return;
            }
            User.Username = Username;
            User.ProfilePicturePath = ProfilePicBuffer;

            CloseAction?.Invoke();
           
        }
        
        public UserModel ReturnUserData()
        {

            return this.User;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

