using Microsoft.Identity.Client;
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
        private string login;
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public string Role
        {
            get => role; 
            set
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
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
        
        public UserModel(int id, string username,string login, string password, string role = "user",string profilepic = @"C:\Users\леха\Desktop\2 курс\4sem\лабы\ооп\lab4\lab4\Resources\defaultAvatar.jpg")
        {
            if (username == "admin" && password == "admin")
            {
                this.Id = id;
                this.Role = "admin";
                this.Login = login;
                this.Username = "admin";
                this.Password = "admin";
                this.ProfilePicturePath = profilepic;
            }
            else
            {
                this.Id = id;
                this.Role = role;
                this.Login = login;
                this.Username = username;
                this.Password = password;
                this.ProfilePicturePath = profilepic;
            }
        }
        public UserModel(string username, string login,string password, string role = "user")
        {
            if (username == "admin" && password == "admin")
            {
                this.Role = "admin";
                this.Login = login;
                this.Username = "admin";
                this.Password = "admin";
            }
            else
            {
                this.Login = login;
                this.Role = role;
                this.Username = username;
                this.Password = password;
            }
            
            this.profilePicturePath = @"C:\Users\леха\Desktop\2 курс\4sem\лабы\ооп\lab4\lab4\Resources\defaultAvatar.jpg";
        }
        public UserModel()
        { }
    }
}
