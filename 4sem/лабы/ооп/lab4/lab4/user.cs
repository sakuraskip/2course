using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
  public  class User:INotifyPropertyChanged
    {
        public string Role { get => Role; set { Role = value; OnPropertyChanged(nameof(Role)); } }
        public string username { get => username; set { username = value; OnPropertyChanged(nameof(username)); } }
        public string password { get => password; set { password = value; OnPropertyChanged(nameof(password)); } }

        public string profilePicturePath { get => profilePicturePath; set { profilePicturePath = value; OnPropertyChanged(nameof(profilePicturePath)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public User(string username,string password)
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

            this.profilePicturePath = "/Resources/defaultAvatar.jpg";
        }
    }
}
