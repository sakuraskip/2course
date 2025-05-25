using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Configuration;
using lab4.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace lab4.aEntity
{
    public class appDBcontext:DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Ship> Ships {  get; set; }
        public DbSet<ReviewEF> Reviews { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[2].ConnectionString);
        }
    }
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Role { get; set; } = "user";

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Login { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(1000)]
        public string ProfilePicturePath { get; set; }

        public virtual ICollection<ReviewEF> Reviews { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    [Table("Ships")]
    public class Ship : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Required, MaxLength(500)]
        public string ImagePath { get; set; }

        [Required, MaxLength(50)]
        public string ShipType { get; set; }

        [Required, MaxLength(50)]
        public string FilterType { get; set; }

        [Required]
        public int Price { get; set; }

        [Required, MaxLength(50)]
        public string Availability { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<ReviewEF> Reviews { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        public Ship()
        { }
        public Ship(string name,string description,string shortdescription,string imagepath,string shiptype,string
            filtertype,int price,string availability,double rating)
        {
            Name = name;
            Description = description; ShortDescription = shortdescription;
            ImagePath = imagepath;
            ShipType = shiptype;
                FilterType = filtertype;
            Price = price;
            Availability = availability;
            Rating = rating;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    [Table("Reviews")]
    public class ReviewEF : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShipId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [ForeignKey("ShipId")]
        public virtual Ship Ship { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ReviewEF() { } 

        public ReviewEF(int userId, string username, string comment, int rating, int shipId)
        {
            UserId = userId;
            Username = username;
            Comment = comment;
            Rating = rating;
            ShipId = shipId;
      
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    [Table("Rentals")]
    public class Rental : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShipId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required, MaxLength(500)]
        public string ImagePath { get; set; }

        [Required]
        public DateTime RentDate { get; set; }

        [Required, MaxLength(100)]
        public string ShipName { get; set; }

        [ForeignKey("ShipId")]
        public virtual Ship Ship { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Repository
    {
        private readonly appDBcontext _context;

        public Repository()
        {
            _context = new appDBcontext();
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public void AddShip(Ship ship)
        {
            _context.Ships.Add(ship);
            _context.SaveChanges();
        }

        public Ship GetShip(int id)
        {
            return _context.Ships.Find(id);
        }

        public IEnumerable<Ship> GetAllShips()
        {
            return _context.Ships.ToList();
        }

        public void UpdateShip(Ship ship)
        {
            _context.Entry(ship).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteShip(int id)
        {
            var ship = _context.Ships.Find(id);
            if (ship != null)
            {
                _context.Ships.Remove(ship);
                _context.SaveChanges();
            }
        }
        public void AddReview(ReviewEF review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();

            UpdateShipRating(review.ShipId);
        }

        public ReviewEF GetReview(int id)
        {
            return _context.Reviews.Find(id);
        }

        public IEnumerable<ReviewEF> GetReviewsForShip(int shipId)
        {
            return _context.Reviews.Where(r => r.ShipId == shipId).ToList();
        }

        public void UpdateReview(ReviewEF review)
        {
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();

            UpdateShipRating(review.ShipId);
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                int shipId = review.ShipId;
                _context.Reviews.Remove(review);
                _context.SaveChanges();

                UpdateShipRating(shipId);
            }
        }
        private void UpdateShipRating(int shipId)
        {
            var ship = _context.Ships.Find(shipId);
            if (ship != null)
            {
                ship.Rating = _context.Reviews
                    .Where(r => r.ShipId == shipId)
                    .Average(r => r.Rating);
                _context.SaveChanges();
            }
        }
        public void AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        public Rental GetRental(int id)
        {
            return _context.Rentals.Find(id);
        }

        public IEnumerable<Rental> GetUserRentals(int userId)
        {
            return _context.Rentals.Where(r => r.UserId == userId).ToList();
        }

        public void UpdateRental(Rental rental)
        {
            _context.Entry(rental).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
