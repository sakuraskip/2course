using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class Review:INotifyPropertyChanged
    {
        private int _shipId;
        private int _id;
        private int _userId;
        private string _username;
        private string _comment;
        private int _rating;
       
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public int ShipId
        {
            get => _shipId;
            set
            {
                if (_shipId != value)
                {
                    _shipId = value;
                    OnPropertyChanged(nameof(ShipId));
                }
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Rating
        {
            get => _rating;
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged();
                }
            }
        }
        public Review( int userId, string username, string comment, int rating,int shipId)
        {
            UserId = userId;
            Username = username;
            Comment = comment;
            Rating = rating;
            ShipId = shipId;
        }
        public Review(int id,int userId, string username, string comment, int rating, int shipId)
        {
            Id = id;
            UserId = userId;
            Username = username;
            Comment = comment;
            Rating = rating;
            ShipId = shipId;
        }
        public Review( int userId, string username, string comment, int rating)
        {
            UserId = userId;
            Username = username;
            Comment = comment;
            Rating = rating;

        }
        public Review()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
