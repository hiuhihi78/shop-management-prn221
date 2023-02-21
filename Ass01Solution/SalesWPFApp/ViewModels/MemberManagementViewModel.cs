using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;
using DataAccess.Management;
using SalesWPFApp.Commands;
using System.Windows;
using SalesWPFApp.Views;
using SalesWPFApp.Navigation;

namespace SalesWPFApp.ViewModels
{
    public class MemberManagementViewModel : INotifyPropertyChanged
    {
        #region Declare varibles
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<MemberDTO> members;

        public ObservableCollection<MemberDTO> Members
        {
            get { return members; }
            set { members = value; OnPropertyChanged(); }
        }

        private string searchMember;

        public string SearchMember
        {
            get { return searchMember; }
            set { searchMember = value; OnPropertyChanged(); LoadDataGridMembers(); }
        }

        private MemberDTO selectedMember;

        public MemberDTO SelectedMember
        {
            get { return selectedMember; }
            set { selectedMember = value; OnPropertyChanged(); }
        }



        #endregion

        public MemberManagementViewModel() 
        {
            searchMember= string.Empty;
            LoadDataGridMembers();

            deleteMember = new RelayCommand<MemberDTO>(ExecuteDeleteMember, CanExecuteDeleteMember);
            updateMember = new RelayCommand<MemberDTO>(ExecuteUpdateMember, CanExecuteUpdateMember);
            createMember = new RelayCommand(ExecuteCreateMember);
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
        }

        #region Load list members
        public void LoadDataGridMembers()
        {
            var isAdmin = (bool)NavigationParameters.Parameters["isAdmin"];
            if (isAdmin)
            {
                Members = MemberManagement.Instance.GetListMember(SearchMember);
            }
            else
            {
                var member = (Member)NavigationParameters.Parameters["member"];
                Members = new ObservableCollection<MemberDTO>();
                Members.Add(MemberDTO.FromMember(MemberManagement.Instance.GetMemberByEmail(member.Email)));
            }
        }   
        #endregion

        #region Delete member info
        private RelayCommand<MemberDTO> deleteMember;

        public RelayCommand<MemberDTO> DeleteMember
        {
            get { return deleteMember; }
            set { deleteMember = value; }
        }

        private void ExecuteDeleteMember(MemberDTO member)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isSuccess = MemberManagement.Instance.DeleteMember(member.MemberId);
                if(isSuccess) 
                {
                    MessageBox.Show("Delete completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadDataGridMembers();
                }
                else
                {
                    MessageBox.Show("Something wrong!", "Success", MessageBoxButton.OK, MessageBoxImage.Error);
                    LoadDataGridMembers();
                }

            }
        }

        private bool CanExecuteDeleteMember(MemberDTO member)
        {
            var isAdmin = (bool)NavigationParameters.Parameters["isAdmin"];
            return isAdmin;
        }

        #endregion

        #region Update Member

        private RelayCommand<MemberDTO> updateMember;

        public RelayCommand<MemberDTO> UpdateMember
        {
            get { return updateMember; }
            set { updateMember = value; }
        }

        private void ExecuteUpdateMember(MemberDTO member)
        {
            PopupUpdateCreateMember popup = new PopupUpdateCreateMember(member);
            popup.ShowDialog();
        }

        private bool CanExecuteUpdateMember(MemberDTO member)
        {
            return true;
        }

        #endregion


        #region Create Member

        private RelayCommand createMember;

        public RelayCommand CreateMember
        {
            get { return createMember; }
            set { createMember = value; }
        }

        private void ExecuteCreateMember()
        {
            PopupUpdateCreateMember popup = new PopupUpdateCreateMember(null);
            popup.ShowDialog();
        }
        #endregion

        #region Back
        private RelayCommand backToPreviousScreen;

        public RelayCommand BackToPreviousScreen
        {
            get { return backToPreviousScreen; }
            set { backToPreviousScreen = value; }
        }

        public void HandleBackToPreviousScreen()
        {
            NavigationService.NavigateTo(new Home());
        }
        #endregion
    }
}
