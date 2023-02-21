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
    }
}
