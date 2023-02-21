using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using SalesWPFApp.Commands;
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
    public class PopupUpdateCreateMemberViewModel : INotifyPropertyChanged
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

        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; OnPropertyChanged(); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged();}
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }


        private MemberDTO _member;
        private bool isCreate;

        #endregion

        public PopupUpdateCreateMemberViewModel(MemberDTO member)
        {
            _member = member;
            if(member != null) 
            {
                Email = member.Email;
                CompanyName = member.CompanyName;
                City = member.City;
                Country = member.Country;
                Password= member.Password;  
                isCreate= false;
                
            }
            else
            {
                isCreate= true;
            }

            submitCommand = new RelayCommand<object>(ExecuteHandleSubmit,(object parameter) => true);
        }

        private RelayCommand<object> submitCommand;

        public RelayCommand<object> SubmitCommand
        {
            get { return submitCommand; }
            set { submitCommand = value; }
        }

        public void ExecuteHandleSubmit(object parameter)
        {

            var isCanSubmit = (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(CompanyName)) == true ? false : true;
            var windown = parameter as Window;

            if(isCanSubmit == false) 
            {
                MessageBox.Show("You need to fill all field");
                return;
            }

            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to do this?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                if (isCreate)
                {
                    var result = new Member()
                    {
                        City = City,
                        Country = Country,
                        Password = Password,
                        CompanyName = CompanyName,
                        Email = Email,
                    };
                    MemberManagement.Instance.CreateMember(result);
                    MessageBox.Show("Operation completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    windown.Close();
                }
                else
                {
                    var result = new Member()
                    {
                        City = City,
                        Country = Country,
                        Password = Password,
                        CompanyName = CompanyName,
                        Email = Email,
                        MemberId = _member.MemberId,
                    };
                    MemberManagement.Instance.UpdateMember(result);
                    MessageBox.Show("Operation completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    windown.Close();
                }
            }
            

        }

    }
}
