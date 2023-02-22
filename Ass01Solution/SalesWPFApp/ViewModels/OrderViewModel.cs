using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using SalesWPFApp.Commands;
using SalesWPFApp.Navigation;
using SalesWPFApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        #region Declare variables
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

        private ObservableCollection<ProductDTO> listOrderProduct;

        public ObservableCollection<ProductDTO> ListOrderProduct
        {
            get { return listOrderProduct; }
            set { listOrderProduct = value; OnPropertyChanged(); }
        }

        private ProductDTO selectedProduct;
        public ProductDTO SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private string searchProduct;

        public string SearchProduct
        {
            get { return searchProduct; }
            set { searchProduct = value; OnPropertyChanged(); LoadListProduct(); }
        }

        private decimal totalPriceOrder;

        public decimal TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }

        private bool enableButtonCheckout;

        public bool EnableButtonCheckout
        {
            get { return enableButtonCheckout; }
            set { enableButtonCheckout = value; OnPropertyChanged(); }
        }
        #endregion

        public OrderViewModel()
        {
            ListOrderProduct = new ObservableCollection<ProductDTO>();
            SearchProduct = string.Empty;
            LoadListProduct();
            LoadListProductOrdered();
            addToCart = new RelayCommand<ProductDTO>(ExecuteAddProductToListOrder, (ProductDTO product) => true);
            removeProductInCart = new RelayCommand<ProductDTO>(ExecuteDeleteProductInCart, CanExecuteDeleteProductInCart);
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
            checkoutOrder = new RelayCommand(ExecuteCheckoutOrder);
            UpdateStatusCheckoutOrder();
            UpdateTotalPriceOrder();
        }

        #region load list product
        public void LoadListProduct()
        {
            Products = DataAccess.Management.ProductManagement.Instance.GetListProduct(SearchProduct);
        }
        #endregion

        #region load list product ordered
        public void LoadListProductOrdered()
        {
            try
            {
                var productsOrdered = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listOrder"];
                listOrderProduct = productsOrdered;
            }
            catch (Exception ex) //-- not found
            {
                listOrderProduct = new ObservableCollection<ProductDTO>();
            }
        }
        #endregion

        private RelayCommand<ProductDTO> addToCart;

        public RelayCommand<ProductDTO> AddToCart
        {
            get { return addToCart; }
            set { addToCart = value; OnPropertyChanged(); }
        }

        private void ExecuteAddProductToListOrder(ProductDTO productSelected)
        {
            bool productExsited = listOrderProduct.FirstOrDefault(x => x.ProductId == productSelected.ProductId) != null;
            if (productExsited)
            {
                for (int i = 0; i < listOrderProduct.Count(); i++)
                {
                    if (listOrderProduct[i].ProductId == productSelected.ProductId)
                    {
                        listOrderProduct[i].UnitsInStock = listOrderProduct[i].UnitsInStock + 1;
                    }
                }
            }
            else
            {
                ProductDTO product = DataAccess.Management.ProductManagement.Instance.GetProductById(productSelected.ProductId);   
                if (product == null)
                {

                }
                else if (product.UnitsInStock == 0)
                {

                }
                else
                {
                    product.UnitsInStock = 1;
                    listOrderProduct.Add(product);
                }
            }

            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
        }

        #region Remove a Product In Cart

        private RelayCommand<ProductDTO> removeProductInCart;

        public RelayCommand<ProductDTO> RemoveProductInCart
        {
            get { return removeProductInCart; }
            set { removeProductInCart = value; }
        }

        private void ExecuteDeleteProductInCart(ProductDTO selectedRemoveProduct)
        {
            listOrderProduct.Remove(selectedRemoveProduct);
        }

        private bool CanExecuteDeleteProductInCart(ProductDTO selectedRemoveProduct)
        {
            bool productExisted = listOrderProduct.FirstOrDefault(x => x.ProductId == selectedRemoveProduct.ProductId) != null;
            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
            return productExisted;
        }

        #endregion


        #region Update total price order
        public void UpdateTotalPriceOrder()
        {
            decimal total = 0;
            foreach (var product in ListOrderProduct)
            {
                total += (product.UnitsInStock * product.UnitPrice);
            }
            TotalPriceOrder = total;
        }
        #endregion

        #region Update status button checkout order
        public void UpdateStatusCheckoutOrder()
        {
            EnableButtonCheckout = TotalPriceOrder > 0;
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


        #region Checkout Order (Navigation to screen checkout order)

        private RelayCommand checkoutOrder;

        public RelayCommand CheckoutOrder
        {
            get { return checkoutOrder; }
            set { checkoutOrder = value; OnPropertyChanged(); }
        }

        private void ExecuteCheckoutOrder()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want make order?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (((bool)NavigationParameters.Parameters["isAdmin"]))
            {
                MessageBox.Show("You are admin! You cannot make new order!");
                return;
            }


            if (result == MessageBoxResult.Yes)
            {
                DataAccess.Models.Order orderInfo = new DataAccess.Models.Order()
                {
                    Freight = 30,
                    MemberId = ((DataAccess.Models.Member)NavigationParameters.Parameters["member"]).MemberId,
                    OrderDate = DateTime.Now,
                    RequiredDate= DateTime.Now,
                    ShippedDate= DateTime.Now.AddDays(3),
                };

                if (OrderManagement.Instance.CreateOrder(orderInfo, ListOrderProduct) == true)
                {
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    // remove cart
                    NavigationParameters.Parameters.Remove("listOrder");
                    NavigationParameters.Parameters.Remove("totalPriceOrder");
                    LoadListProduct();
                    ListOrderProduct = new ObservableCollection<ProductDTO>();
                }
                else
                {
                    MessageBox.Show("Something was wrong!\nPlease ask administrator!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion
    }
}
