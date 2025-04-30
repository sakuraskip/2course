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

namespace lab4.ViewModels
{
    public class RequestToBookViewModel:INotifyPropertyChanged
    { 
    private DateTime _rentalDate = DateTime.Now;
    private string _phoneNumber;
    private string _name;
    private string _email;
    private string _buttonContent;

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

    private bool CanConfirm()
    {
        return 
               !string.IsNullOrWhiteSpace(PhoneNumber) &&
               !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(Email) &&
               RentalDate > DateTime.Now;
    }
    private async void ConfirmRent()
        {
            if(CanConfirm())
            {
                await Task.Delay(1000);
                CloseAction.Invoke();
            }
        }
  

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
