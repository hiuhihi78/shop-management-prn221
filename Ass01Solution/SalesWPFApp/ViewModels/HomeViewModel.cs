using SalesWPFApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SalesWPFApp.Views;

namespace SalesWPFApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Declare varibles
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public HomeViewModel()
        {
            memberManagementCommand = new RelayCommand(HandleMemberManagement);
            productManagementCommand = new RelayCommand(HandleProductManagement);
            orderManagementCommand= new RelayCommand(HandleOrderManagement);    
        }

        #region management member
        private RelayCommand memberManagementCommand;

        public RelayCommand MemberManagementCommand
        {
            get { return memberManagementCommand; }
            set { memberManagementCommand = value; }
        }

        private void HandleMemberManagement()
        {
            Navigation.NavigationService.NavigateTo(new MemeberManagement());
        }

        #endregion


        #region management product
        private RelayCommand productManagementCommand;

        public RelayCommand ProductManagementCommand
        {
            get { return productManagementCommand; }
            set { productManagementCommand = value; }
        }

        private void HandleProductManagement()
        {
            Navigation.NavigationService.NavigateTo(new ProductManagement());
        }

        #endregion

        #region management order
        private RelayCommand orderManagementCommand;

        public RelayCommand OrderManagementCommand
        {
            get { return orderManagementCommand; }
            set { orderManagementCommand = value; }
        }

        private void HandleOrderManagement()
        {
            Navigation.NavigationService.NavigateTo(new Order());
        }

        #endregion
    }
}
