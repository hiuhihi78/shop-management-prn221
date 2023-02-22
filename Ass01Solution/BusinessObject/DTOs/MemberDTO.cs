using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class MemberDTO : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int memberId;
        private string email;
        private string companyName;
        private string city;
        private string country;
        private string password;

        public int MemberId
        {
            get { return memberId; }
            set
            {
                if (value != memberId)
                {
                    memberId = value;
                    OnPropertyChanged(nameof(MemberId));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                if (value != companyName)
                {
                    companyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (value != city)
                {
                    city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (value != country)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public static MemberDTO FromMember(Member member)
        {
            return new MemberDTO
            {
                City = member.City,
                Country = member.Country,
                Password = member.Password,
                CompanyName = member.CompanyName,   
                Email = member.Email,
                MemberId= member.MemberId,
            };
        }

    }
}
