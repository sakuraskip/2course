using lab4.userControls;
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
    public class HeaderViewModel:INotifyPropertyChanged
    {
        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand NavigateToUserPageCommand { get; }
        private UserModel _user;

        public HeaderViewModel(ItemsListViewModel itemsListViewModel, UserModel user)
        {
            _user = user;
            UndoCommand = itemsListViewModel.UndoCommand;
            RedoCommand = itemsListViewModel.RedoCommand;
            CloseCommand = new RelayCommand(Close);
            NavigateToUserPageCommand = new RelayCommand(NavigateToUserPage);
        }
        private void NavigateToUserPage()
        {
            var newWindow = new userpage(_user);
            Application.Current.Windows.OfType<Window>().First().Close();
            newWindow.Show();
        }
        private void Close()
        {
            Application.Current.Windows.OfType<Window>().First().Close();
            return;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
