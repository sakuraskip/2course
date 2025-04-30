using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
  public  class UserModel:INotifyPropertyChanged
    {
        private string role;
        private string username;
        private string password;
        private string profilePicturePath;

        public string Role
        {
            get => role; 
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public string Username
        {
            get => username; 
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => password; 
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ProfilePicturePath
        {
            get => profilePicturePath; 
            set
            {
                profilePicturePath = value;
                OnPropertyChanged(nameof(ProfilePicturePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public UserModel(string username,string password)
        {
            if (username == "admin" && password == "admin")
            {
                this.Role = "admin";
                this.username = "admin";
                this.password = "admin";
            }
            else
            {
                this.Role = "user";
                this.username = username;
                this.password = password;
            }

            this.profilePicturePath = @"C:\Users\леха\Desktop\2 курс\4sem\лабы\ооп\lab4\lab4\Resources\defaultAvatar.jpg";
        }
    }
}
