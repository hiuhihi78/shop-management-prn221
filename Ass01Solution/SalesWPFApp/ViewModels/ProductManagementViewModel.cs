using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using SalesWPFApp.Commands;
using SalesWPFApp.Common;
using SalesWPFApp.Navigation;
using SalesWPFApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp.ViewModels
{
    public class ProductManagementViewModel : INotifyPropertyChanged
    {
        #region Declare varibles
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ProductDTO> products;

        public ObservableCollection<ProductDTO> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }

        private string searchProduct;

        public string SearchProduct
        {
            get { return searchProduct; }
            set { searchProduct = value; OnPropertyChanged(); LoadDataGridMembers(); }
        }


        public bool IsAdmin { get; set; }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; OnPropertyChanged(); }
        }

        private decimal productPrice;

        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; OnPropertyChanged(); }
        }

        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; OnPropertyChanged(); }
        }



        public ProductManagementViewModel()
        {
            LoadDataGridMembers();
            SearchProduct = string.Empty;
            deleteProduct = new RelayCommand<ProductDTO>(ExecuteDeleteMember, CanExecuteDeleteMember);
            updateProduct = new RelayCommand<ProductDTO>(ExecuteUpdateProduct, CanExecuteUpdateProduct);
            createProduct = new RelayCommand(ExecuteCreateProduct);
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
            IsAdmin = (bool)NavigationParameters.Parameters["isAdmin"];
            searchCommand = new RelayCommand(HandleSearchCommand);
            ProductId = 0;
            ProductPrice = 0;
            ProductQuantity = 0;
        }


        #endregion

        #region Load list members
        public void LoadDataGridMembers()
        {
            //Products = DataAccess.Management.ProductManagement.Instance.GetListProduct(SearchProduct);
            Products = DataContext.productRepository.GetListProduct(SearchProduct);
        }
        #endregion

        #region Delete member info
        private RelayCommand<ProductDTO> deleteProduct;

        public RelayCommand<ProductDTO> DeleteProduct
        {
            get { return deleteProduct; }
            set { deleteProduct = value; }
        }

        private void ExecuteDeleteMember(ProductDTO product)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //var isSuccess = DataAccess.Management.ProductManagement.Instance.DeleteProduct(product.ProductId);
                var isSuccess = DataContext.productRepository.DeleteProduct(product.ProductId);
                if (isSuccess)
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
        private bool CanExecuteDeleteMember(ProductDTO member)
        {
            var isAdmin = (bool)NavigationParameters.Parameters["isAdmin"];
            return isAdmin;
        }

        #endregion  

        #region Update Product

        private RelayCommand<ProductDTO> updateProduct;

        public RelayCommand<ProductDTO> UpdateProduct
        {
            get { return updateProduct; }
            set { updateProduct = value; }
        }

        private void ExecuteUpdateProduct(ProductDTO product)
        {
            PopupCreateUpdateProduct popup = new PopupCreateUpdateProduct(product);
            popup.ShowDialog();
        }

        private bool CanExecuteUpdateProduct(ProductDTO product)
        {
            return true;
        }

        #endregion

        #region Create Product

        private RelayCommand createProduct;

        public RelayCommand CreateProduct
        {
            get { return createProduct; }
            set { createProduct = value; }
        }

        private void ExecuteCreateProduct()
        {
            PopupCreateUpdateProduct popup = new PopupCreateUpdateProduct(null);
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

        #region Search commad
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
            set { searchCommand = value; OnPropertyChanged(); }
        }

        public void HandleSearchCommand()
        {
            bool canSearch = true;
            try
            {
                Int32.Parse(ProductId.ToString());
                decimal.Parse(ProductPrice.ToString());
                Int32.Parse(ProductQuantity.ToString());
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Id, price, stock must be a number");
                return;
            }
            //Products = DataAccess.Management.ProductManagement.Instance.GetListProductByCondition(ProductId, SearchProduct, ProductPrice, ProductQuantity);
            Products = DataContext.productRepository.GetListProductByCondition(ProductId, SearchProduct, ProductPrice, ProductQuantity);
        }

        #endregion
    }
}

