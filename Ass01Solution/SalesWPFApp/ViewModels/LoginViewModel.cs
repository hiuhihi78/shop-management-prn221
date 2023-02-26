using DataAccess.Management;
using SalesWPFApp.Commands;
using SalesWPFApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Extensions.Options;
using DataAccess.Models;
using System.Windows.Controls;
using System.Text.RegularExpressions;

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

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }



        #endregion

        public LoginViewModel()
        {
            login = new RelayCommand(HandleLogin);
            passwordChangedCommand = new RelayCommand<object>(HandleGetPassword, (object param) => true);
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

            Regex regex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            if (!regex.IsMatch(Email)){
                MessageBox.Show("Email must be follow format!");
                return;
            }else if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Email or Password can not be empty!");
                return;
            }

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var adminEmail = configuration.GetSection("AppSettings").GetSection("email").Value;
            var adminPassword = configuration.GetSection("AppSettings").GetSection("password").Value;

            var member = MemberManagement.Instance.GetMember(Email, Password);

            if (member != null)
            {
                NavigationParameters.Parameters.Add("isAdmin", false);
                NavigationParameters.Parameters.Add("member", member);
                Navigation.NavigationService.NavigateTo(new Home());
            }
            else if (Email == adminEmail && Password == adminPassword)
            {
                NavigationParameters.Parameters.Add("isAdmin", true);
                Navigation.NavigationService.NavigateTo(new Home());
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials and try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region PasswordChangedCommand 
        private RelayCommand<object> passwordChangedCommand;

        public RelayCommand<object> PasswordChangedCommand
        {
            get { return passwordChangedCommand; }
            set { passwordChangedCommand = value; }
        }

        private void HandleGetPassword(object passwordBox)
        {
            Password = ((PasswordBox)passwordBox).Password;
        }

        #endregion


    }
}
