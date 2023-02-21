using DataAccess.Management;
using SalesWPFApp.Commands;
using SalesWPFApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Declare varibles

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private string  password;

        public string  Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }



        #endregion

        public LoginViewModel()
        {
            login = new RelayCommand(HandleLogin);
        }

        #region login
        private RelayCommand login;

        public RelayCommand Login
        {
            get { return login; }
            set { login = value; }
        }

        public void HandleLogin()
        {
            var member = MemberManagement.Instance.GetMember(Email, Password);
            if(member != null) 
            {
                Navigation.NavigationService.NavigateTo(new Home());
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials and try again.", "Login Failed", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        #endregion

    }
}
