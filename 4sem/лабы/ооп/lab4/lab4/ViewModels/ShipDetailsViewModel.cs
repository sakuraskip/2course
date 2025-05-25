using lab4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using lab4.userControls;
using lab4.aEntity;
namespace lab4.ViewModels
{
    public class ShipDetailsModel:INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ShipModel _ship;
        private string _priceText;
        private string _availabilityText;
        private ObservableCollection<Review> _reviews;
        private double _averageRating;
        private UserModel _user;



        public ShipModel Ship
        {
            get => _ship;
            set
            {
                _ship = value;
                OnPropertyChanged();
                UpdateDisplayTexts();
            }
        }

        public string PriceText
        {
            get => _priceText;
            set
            {
                _priceText = value;
                OnPropertyChanged();
            }
        }
        public string AvailabilityText
        {
            get => _availabilityText;
            set
            {
                _availabilityText = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged();
                CalculateAverageRating();
            }
        }
        public double AverageRating
        {
            get => _averageRating;
            set
            {
                _averageRating = value;
                OnPropertyChanged();
            }
        }
        public ICommand RentCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand OpenAddReviewCommand { get; }

        public ShipDetailsModel(ShipModel ship,UserModel user,ObservableCollection<Review> reviews)
        {
            Ship = ship;
            _user = user;
            RentCommand = new RelayCommand(Rent);
            CloseCommand = new RelayCommand(CloseAction);
            Reviews = new ObservableCollection<Review>();
            OpenAddReviewCommand = new RelayCommand(AddReview);
            LoadReviews(reviews);
          
        }
        public ShipDetailsModel()
        {
            Reviews = new ObservableCollection<Review>();
        }
        private void UpdateDisplayTexts()   
        {
            PriceText = $"Price: {Ship.Price} BYN";
            AvailabilityText = Ship.Availability;
        }
        private void CalculateAverageRating()
        {
            if (Reviews == null || !Reviews.Any())
            {
                AverageRating = 0;
                return;
            }

            AverageRating = Reviews.Average(r => r.Rating);
        }
        private void LoadReviews(ObservableCollection<Review>  reviews)
        {
            var filteredReviews = reviews.Where(r => r.ShipId == _ship.Id);
            Reviews = new ObservableCollection<Review>(filteredReviews);

            CalculateAverageRating();
        }
        private void AddReview()
        {
           
            var addReviewWindow = new AddReviewWindow(_user,Ship);
            addReviewWindow.ShowDialog();
            
                ReviewEF? newReview = (addReviewWindow.DataContext as AddReviewViewModel).ReviewEFm;
            var newReview1 = new Review
            {
                UserId = _user.Id,
                Username = _user.Username,
                Comment = newReview.Comment,
                Rating = newReview.Rating,
                ShipId = _ship.Id
            };
            if(newReview!=null)
            {
                newReview1.Id = Reviews.Count + 1;
                newReview1.ShipId = _ship.Id;
                Reviews.Add(newReview1);
                CalculateAverageRating();
            }
                
            
        }
        private void Rent()
        {
            var reqWindow = new userControls.requestToBook(Ship,_user);
            reqWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
