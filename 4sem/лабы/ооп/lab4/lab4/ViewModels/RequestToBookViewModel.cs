using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace lab4.ViewModels
{
    public class RequestToBookViewModel:INotifyPropertyChanged
    {
        private ShipModel ship;
        private UserModel user;
        private DateTime _rentalDate = DateTime.Today;
    private string _phoneNumber;
    private string _name;
    private string _email;
    private string _buttonContent;
        public static string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        public DateTime RentalDate
    {
        get => _rentalDate;
        set
        {
            _rentalDate = value;
            OnPropertyChanged();
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public string ButtonContent
    {
        get => _buttonContent;
        set
        {
            _buttonContent = value;
            OnPropertyChanged();
        }
    }

    

    public ICommand ConfirmCommand { get; }
    public Action CloseAction { get; set; }

    public RequestToBookViewModel()
    {
        ButtonContent = (string)Application.Current.FindResource("ConfirmButton");
        ConfirmCommand = new RelayCommand(ConfirmRent);
    }
        public RequestToBookViewModel(ShipModel ship,UserModel user)
        {
            this.ship = ship;
            this.user  = user;
            ButtonContent = (string)Application.Current.FindResource("ConfirmButton");
            ConfirmCommand = new RelayCommand(ConfirmRent);
        }
        private bool CanConfirm()
    {
        return 
               !string.IsNullOrWhiteSpace(PhoneNumber) &&
               !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(Email) &&
               RentalDate >= DateTime.Today;
    }
    private async void ConfirmRent()
        {
            if(!CanConfirm())
            {
                MessageBox.Show("Заполните все поля корректно");
                return;
            }
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("select count(*) from Rental where ShipId = @ShipId and RentDate = @RentDate " +
                        "and status not in ('Отменено')",connection))
                    {
                        command.Parameters.AddWithValue("@ShipId", ship.Id);
                        command.Parameters.AddWithValue("@RentDate", RentalDate.Date);
                        int rentalAmount = (int)await command.ExecuteScalarAsync();
                        if(rentalAmount > 0)
                        {
                            MessageBox.Show("Судно уже забронировано на эту дату");
                            return;
                        }
                    }
                    using (var command = new SqlCommand(
                        "insert into Rental (ShipId,UserId,Status,Cost,ImagePath,RentDate,ShipName) " +
                        " values (@ShipId,@UserId,@Status,@Cost,@ImagePath,@RentDate,@ShipName)" +
                        " SELECT SCOPE_IDENTITY();", connection))
                    {
                        string buff;
                        if (RentalDate.Date == DateTime.Today)
                        {
                            buff = "Активно";
                        }
                        else buff = "Подтверждено";

                        command.Parameters.AddWithValue("@ShipId", ship.Id);
                        command.Parameters.AddWithValue("@UserId", user.Id);
                        command.Parameters.AddWithValue("@Status", buff);
                        command.Parameters.AddWithValue("@Cost", ship.Price);
                        command.Parameters.AddWithValue("@ImagePath", ship.ImagePath);
                        command.Parameters.AddWithValue("@RentDate", _rentalDate.Date);
                        command.Parameters.AddWithValue("@ShipName", ship.Name);


                        await command.ExecuteNonQueryAsync();

                    }
                    MessageBox.Show("Заявка успешно оформлена");
                    CloseAction?.Invoke();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error confirming rent " + ex.Message);
            }
        }
  

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
