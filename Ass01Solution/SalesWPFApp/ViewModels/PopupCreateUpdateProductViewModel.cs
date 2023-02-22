using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using SalesWPFApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWPFApp.ViewModels
{
    public class PopupCreateUpdateProductViewModel : INotifyPropertyChanged
    {
        #region Declare varibles
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private string weight;

        public string Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged(); }
        }

        private string unitPrice;

        public string UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; OnPropertyChanged(); }
        }

        private string unitsInStock;

        public string UnitsInStock
        {
            get { return unitsInStock; }
            set { unitsInStock = value; OnPropertyChanged(); }
        }


        private ProductDTO _product;
        private bool isCreate;

        #endregion

        public PopupCreateUpdateProductViewModel(ProductDTO product)
        {
            _product = product;
            if (product != null)
            {
                ProductName = product.ProductName;
                Weight = product.Weight;
                UnitPrice = product.UnitPrice.ToString();
                UnitsInStock = product.UnitsInStock.ToString();
                isCreate = false;

            }
            else
            {
                isCreate = true;
            }
            submitCommand = new RelayCommand<object>(ExecuteHandleSubmit, (object parameter) => true);
        }

        private RelayCommand<object> submitCommand;

        public RelayCommand<object> SubmitCommand
        {
            get { return submitCommand; }
            set { submitCommand = value; }
        }

        public void ExecuteHandleSubmit(object parameter)
        {

            var isCanSubmit = (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Weight) || string.IsNullOrEmpty(UnitPrice) || string.IsNullOrEmpty(UnitsInStock)) == true ? false : true;
            var windown = parameter as Window;

            if (isCanSubmit == false)
            {
                MessageBox.Show("You need to fill all field");
                return;
            }

            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to do this?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                if (isCreate)
                {
                    var result = new Product()
                    {
                        ProductName = ProductName,
                        Weight = Weight,
                        UnitPrice = decimal.Parse(UnitPrice),
                        UnitsInStock = int.Parse(UnitsInStock)
                    };
                    ProductManagement.Instance.CreateProduct(result);
                    MessageBox.Show("Operation completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    windown.Close();
                }
                else
                {
                    var result = new Product()
                    {
                        ProductName = ProductName,
                        Weight = Weight,
                        UnitPrice = decimal.Parse(UnitPrice),
                        UnitsInStock = int.Parse(UnitsInStock),
                        ProductId = _product.ProductId,
                    };
                    ProductManagement.Instance.UpdateProduct(result);
                    MessageBox.Show("Operation completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    windown.Close();
                }
            }

        }
    }
}
