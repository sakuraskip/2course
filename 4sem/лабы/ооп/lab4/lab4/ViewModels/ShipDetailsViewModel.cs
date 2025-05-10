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

        public ShipDetailsModel(ShipModel ship,UserModel user)
        {
            Ship = ship;
            _user = user;
            RentCommand = new RelayCommand(Rent);
            CloseCommand = new RelayCommand(CloseAction);
            Reviews = new ObservableCollection<Review>();
            OpenAddReviewCommand = new RelayCommand(AddReview);
            LoadReviews();
          
        }
        public ShipDetailsModel()
        {
            Reviews = new ObservableCollection<Review>();
        }
        private void UpdateDisplayTexts()   
        {
            PriceText = $"Price: {Ship.Price}$";
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
        private void LoadReviews()
        {
          
            Reviews.Add(new Review
            {
                Id = 1,
                UserId = 101,
                Username = "Alex Johnson",
                Comment = "Great ship with amazing facilities! The crew was very professional.",
                Rating = 5,
                
            });

            Reviews.Add(new Review
            {
                Id = 2,
                UserId = 102,
                Username = "Maria Smith",
                Comment = "Good experience overall, but the food could be better.",
                Rating = 4,
            });

            CalculateAverageRating();
        }
        private void AddReview()
        {
           
            var addReviewWindow = new userControls.AddReviewWindow(_user);
            addReviewWindow.ShowDialog();
            
                Review newReview = (addReviewWindow.DataContext as AddReviewViewModel).GetReview();
                newReview.Id = Reviews.Count + 1;
                newReview.ShipId = _ship.Id;
               Reviews.Add(newReview);
                CalculateAverageRating();
            
        }
        private void Rent()
        {
            var reqWindow = new userControls.requestToBook();
            reqWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
