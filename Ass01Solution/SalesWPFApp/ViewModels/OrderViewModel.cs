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
            openOrderHistory = new RelayCommand(HandleOpenHistoryOrder);
            UpdateStatusCheckoutOrder();
            UpdateTotalPriceOrder();
            searchHistoryOrder = new RelayCommand(HandleSearhHistoryOrder);
            SearchEmail = string.Empty;
            viewOrderDetail = new RelayCommand<OrderDTO>(ExecuteViewOrderDetail, (OrderDTO order) => true);
            backToHsitoryOrderScreen = new RelayCommand(HandleBackToHsitoryOrderScreen);
            openStatistics = new RelayCommand(HandleOpenStatistics);
            backButonStatiscScreen = new RelayCommand(HandleBackStaticsScreen);
        }

        #region load list product
        public void LoadListProduct()
        {
            //Products = DataAccess.Management.ProductManagement.Instance.GetListProduct(SearchProduct);
            Products = DataContext.productRepository.GetListProduct(SearchProduct);
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

        #region Add to cart
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
                //ProductDTO product = DataAccess.Management.ProductManagement.Instance.GetProductById(productSelected.ProductId);
                ProductDTO product = DataContext.productRepository.GetProductById(productSelected.ProductId);
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
        #endregion

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
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now.AddDays(3),
                };

                //if (OrderManagement.Instance.CreateOrder(orderInfo, ListOrderProduct) == true)
                if (DataContext.orderRepository.CreateOrder(orderInfo, ListOrderProduct) == true)
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

        #region Decare varibles in History Order screen

        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged(); }
        }

        private DateTime? endDate = DateTime.Now;

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged(); }
        }

        private DateTime _currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        private string searchEmail;
        public string SearchEmail
        {
            get { return searchEmail; }
            set { searchEmail = value; OnPropertyChanged(); GetListHistoryOrder(); }
        }

        private ObservableCollection<OrderDTO> listOrderHistory;
        public ObservableCollection<OrderDTO> ListOrderHistory
        {
            get { return listOrderHistory; }
            set { listOrderHistory = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ProductDTO> listProductOrderHistory;
        public ObservableCollection<ProductDTO> ListProductOrderHistory
        {
            get { return listProductOrderHistory; }
            set { listProductOrderHistory = value; OnPropertyChanged(); }
        }


        private decimal totalPriceOrderHistory;

        public decimal TotalPriceOrderHistory
        {
            get { return totalPriceOrderHistory; }
            set { totalPriceOrderHistory = value; }
        }



        #endregion

        #region Open Order history
        private RelayCommand openOrderHistory;

        public RelayCommand OpenOrderHistory
        {
            get { return openOrderHistory; }
            set { openOrderHistory = value; }
        }

        
        public void HandleOpenHistoryOrder()
        {
            NavigationService.NavigateTo(new OrderHistory(), this);
            GetListHistoryOrder();
        }

        #endregion

        #region Get list history order

        public void GetListHistoryOrder()
        {
            if (((bool)NavigationParameters.Parameters["isAdmin"]))
            {
                //ListOrderHistory = OrderManagement.Instance.GetListOrderByCondition(SearchEmail, StartDate, EndDate, null);
                ListOrderHistory = DataContext.orderRepository.GetListOrderByCondition(SearchEmail, StartDate, EndDate, null);
            }
            else
            {
                Member member = ((Member)NavigationParameters.Parameters["member"]);
                //ListOrderHistory = OrderManagement.Instance.GetListOrderByCondition(member.Email, StartDate, EndDate, member);
                ListOrderHistory = DataContext.orderRepository.GetListOrderByCondition(member.Email, StartDate, EndDate, member);
            }
            
        }


        #endregion

        #region Search button - historyOrder
        private RelayCommand searchHistoryOrder;

        public RelayCommand SearchHistoryOrder
        {
            get { return searchHistoryOrder; }
            set { searchHistoryOrder = value; OnPropertyChanged(); }
        }

        public void HandleSearhHistoryOrder()
        {
            if(StartDate > EndDate)
            {
                MessageBox.Show("Please choose again start date!");
                return;
            }
            GetListHistoryOrder();
        }

        #endregion

        #region view history order detail  
        private RelayCommand<OrderDTO> viewOrderDetail;

        public RelayCommand<OrderDTO> ViewOrderDetail
        {
            get { return viewOrderDetail; }
            set { viewOrderDetail = value; OnPropertyChanged();  }
        }

        private OrderDTO selectedOrder;

        public OrderDTO SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; }
        }


        public void ExecuteViewOrderDetail(OrderDTO order)
        {
            Views.OrderDetail orderDetail = new Views.OrderDetail(this);
            _orderDetailScreen = orderDetail;
            SelectedOrder = order;
            GetListProductOrderHistory(order.OrderId);
            orderDetail.ShowDialog();
        }

        public void GetListProductOrderHistory(int OrderId)
        {
            //ListProductOrderHistory = OrderManagement.Instance.GetListProductByOrderId(OrderId);
            ListProductOrderHistory = DataContext.orderRepository.GetListProductByOrderId(OrderId);
            TotalPriceOrderHistory = listProductOrderHistory.Sum(x => x.UnitPrice * x.UnitsInStock);
        }

        #endregion

        #region Back to history order screen
        private RelayCommand backToHsitoryOrderScreen;

        public RelayCommand BackToHsitoryOrderScreen
        {
            get { return backToHsitoryOrderScreen; }
            set { backToHsitoryOrderScreen = value; }
        }

        private Window _orderDetailScreen;
        private void HandleBackToHsitoryOrderScreen()
        {
            _orderDetailScreen.Close();
        }

        #endregion

        #region Open Statistic
        private RelayCommand openStatistics;

        public RelayCommand OpenStatistics
        {
            get { return openStatistics; }
            set { openStatistics = value; OnPropertyChanged();}
        }

        private ObservableCollection<ProductDTO> listProductStatistics;

        public ObservableCollection<ProductDTO> ListProductStatistics
        {
            get { return listProductStatistics; }
            set { listProductStatistics = value; OnPropertyChanged(); }
        }

        private void HandleOpenStatistics() 
        {
            GetListProductOrderStatistics();
            OrderStatistics windown = new OrderStatistics(this);
            _orderStaticScreen = windown;
            windown.ShowDialog();   
        }

        #endregion

        #region Get list product order Statistics

        private decimal totalPriceStatic;

        public decimal TotalPriceStatic
        {
            get { return totalPriceStatic; }
            set { totalPriceStatic = value; }
        }

        public void GetListProductOrderStatistics()
        {
            ObservableCollection<OrderDTO> listOrder = new ObservableCollection<OrderDTO>();
            if (((bool)NavigationParameters.Parameters["isAdmin"]))
            {
                //listOrder = OrderManagement.Instance.GetListOrderByCondition(SearchEmail, StartDate, EndDate, null);
                listOrder = DataContext.orderRepository.GetListOrderByCondition(SearchEmail, StartDate, EndDate, null);
            }
            else
            {
                Member member = ((Member)NavigationParameters.Parameters["member"]);
                //listOrder = OrderManagement.Instance.GetListOrderByCondition(member.Email, StartDate, EndDate, member);
                listOrder = DataContext.orderRepository.GetListOrderByCondition(member.Email, StartDate, EndDate, member);
            }

            ObservableCollection<ProductDTO> listProduct = new ObservableCollection<ProductDTO>();

            foreach (var order in listOrder)
            {
                //var listProductOrdered = OrderManagement.Instance.GetListProductByOrderId(order.OrderId);
                var listProductOrdered = DataContext.orderRepository.GetListProductByOrderId(order.OrderId);
                foreach (var product in listProductOrdered)
                {
                    listProduct.Add(product);
                }
            }

            ObservableCollection<ProductDTO> result = new ObservableCollection<ProductDTO>();
            foreach (var product in listProduct)
            {
                var productExsited = result.FirstOrDefault(x => x.ProductId == product.ProductId) != null;
                if (!productExsited)
                {
                    result.Add(product);
                }
                else
                {
                    var p = result.FirstOrDefault(x => x.ProductId == product.ProductId);
                    p.UnitsInStock += product.UnitsInStock;
                }
            }

            ListProductStatistics = result;

            foreach (var item in result)
            {
                TotalPriceStatic += item.UnitPrice * item.UnitsInStock;
            }
        }
        #endregion

        #region Back button order statisc
        private RelayCommand backButonStatiscScreen;

        public RelayCommand BackButonStatiscScreen
        {
            get { return backButonStatiscScreen; }
            set { backButonStatiscScreen = value; }
        }

        private Window _orderStaticScreen;
        private void HandleBackStaticsScreen()
        {
            _orderStaticScreen.Close();
        }

        #endregion

    }
}
