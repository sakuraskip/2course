using lab4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        private string _comment;
        private int _rating = 1;
        private UserModel _user;
        public Review Review = new Review();
        public bool reviewSaved = false;
        private ShipModel _currentShip;

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

        public AddReviewViewModel(UserModel  user, ShipModel currentShip)
        {
            this._user = user;
            CancelCommand = new RelayCommand(CloseWindow);
            SubmitCommand = new RelayCommand(SaveReview);
            _currentShip = currentShip;
        }
        public AddReviewViewModel()
        {
          
        }
        private void SaveReview()
        {
            if((!string.IsNullOrWhiteSpace(Comment)) && Rating!=0)
            {
                               Review = new Review(_user.Id,_user.Username, Comment,Rating,_currentShip.Id);
                if (SaveToDatabase(Review))
                {
                    MessageBox.Show("Отзыв сохранен!");
                    reviewSaved = true;
                    CloseAction?.Invoke();
                }
            }
        }
        private void CloseWindow()
        {
            reviewSaved = false;
            if(CloseAction != null)
            {
                CloseAction.Invoke();
            }
            else
            {
                MessageBox.Show("chzx");
            }
        }
        public Review? GetReview()
        {
            if(reviewSaved)
            {
                return Review;
            }
            return null;
        }
        private bool SaveToDatabase(Review review)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (var command = new SqlCommand(
                                "INSERT INTO Reviews (ShipId, UserId, Username, Comment, Rating) VALUES (@ShipId, @UserId, @Username, @Comment, @Rating)",
                                connection,
                                transaction))
                            {
                                command.Parameters.AddWithValue("@ShipId", review.ShipId);
                                command.Parameters.AddWithValue("@UserId", review.UserId);
                                command.Parameters.AddWithValue("@Username", review.Username);
                                command.Parameters.AddWithValue("@Comment", review.Comment);
                                command.Parameters.AddWithValue("@Rating", review.Rating);

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка при сохранении отзыва: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ошибка save(): {ex.Message}");
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
