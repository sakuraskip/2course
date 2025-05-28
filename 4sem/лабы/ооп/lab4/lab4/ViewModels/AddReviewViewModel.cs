using lab4.aEntity;
using lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab4.ViewModels
{
    public class AddReviewViewModel : INotifyPropertyChanged
    {
        private string _comment;
        private int _rating = 1;
        private readonly UserModel _user;
        private readonly ShipModel _currentShip;
        private readonly appDBcontext _context = new appDBcontext();
        private Repository Repository = new Repository();
        public ReviewEF ReviewEFm { get; set; }
        public bool ReviewSaved { get; private set; }

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

        public AddReviewViewModel(UserModel user, ShipModel currentShip)
        {
            _user = user;
            _currentShip = currentShip;
            SubmitCommand = new RelayCommand(async () => await SaveReviewAsync());
            CancelCommand = new RelayCommand(CloseWindow);
        }

        public AddReviewViewModel()
        {
            SubmitCommand = new RelayCommand(async () => await SaveReviewAsync());
            CancelCommand = new RelayCommand(CloseWindow);
        }

        private async Task SaveReviewAsync()
        {
            if (string.IsNullOrWhiteSpace(Comment) || Rating <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var reviewEF = new ReviewEF
                    {
                        UserId = _user.Id - 13,
                        Username = _user.Username,
                        Comment = Comment,
                        Rating = Rating,
                        ShipId = _currentShip.Id + 3
                    };
                    ReviewEFm = reviewEF;
                    Repository.AddReview(reviewEF);
                    await UpdateShipRatingAsync(_currentShip.Id);

                    await transaction.CommitAsync();

                    MessageBox.Show("Отзыв успешно сохранён!");
                    ReviewSaved = true;
                    CloseAction?.Invoke();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    MessageBox.Show($"Ошибка при сохранении отзыва: {ex.Message}");
                }
            }
        }

        private async Task UpdateShipRatingAsync(int shipId)
        {
            try
            {
                var ship = Repository.GetShip(shipId);
                if (ship != null)
                {
                    ship.Rating = await _context.Reviews
                        .Where(r => r.ShipId == shipId)
                        .AverageAsync(r => r.Rating);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении рейтинга: {ex.Message}");
                throw; 
            }
        }

        private void CloseWindow()
        {
            ReviewSaved = false;
            CloseAction?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}