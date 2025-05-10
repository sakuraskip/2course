using lab4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4.ViewModels
{
    public  class AddReviewViewModel:INotifyPropertyChanged
    {
        private string _comment;
        private int _rating = 1;
        private UserModel _user;
        public Review Review = new Review();
        public bool reviewSaved = false;


        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged();
            }
        }

        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public Action CloseAction { get; set; }

        public AddReviewViewModel(UserModel  user)
        {
            this._user = user;
            CancelCommand = new RelayCommand(CloseAction);
            SubmitCommand = new RelayCommand(SaveReview);
        }
        public AddReviewViewModel()
        {
            CancelCommand = new RelayCommand(CloseAction);
            SubmitCommand = new RelayCommand(SaveReview);

        }
        private void SaveReview()
        {
            if(!string.IsNullOrWhiteSpace(Comment) && Rating!=0)
            {
                Review = new Review(_user.Id,_user.Username, Comment,Rating);
                MessageBox.Show("Отзыв сохранен!");
                CloseAction?.Invoke();
            }
        }
        public Review GetReview()
        {
            return Review;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
