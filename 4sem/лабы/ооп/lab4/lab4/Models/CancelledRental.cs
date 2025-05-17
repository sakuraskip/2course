using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class CancelledRental:INotifyPropertyChanged
    {
        private int _id;
        private int _userId;
        private int _rentalId;
        private string _status;
        private string _shipName;
        private string _userName;

        public string ShipName
        {
            get => _shipName;
            set
            {
                _shipName = value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get=>_userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public int UserId
        {
            get=> _userId;
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }
        public int RentalId
        {
            get => _rentalId;
            set
            {
                _rentalId = value;
                OnPropertyChanged();
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public CancelledRental(int  id,int userid,int rentalid,string status,string username,string shipname)
        {
            Id = id;
            UserId = userid;
            RentalId = rentalid;
            Status = status;
            ShipName = shipname;
            UserName = username;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
