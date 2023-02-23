using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTOs
{
    public class ProductObject : INotifyPropertyChanged
    {
        private int _productId;
        private int _categoryId;
        private string _productName;
        private string _weight;
        private decimal _unitPrice;
        private int _unitsInStock;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }
            }
        }

        public int CategoryId
        {
            get { return _categoryId; }
            set
            {
                if (_categoryId != value)
                {
                    _categoryId = value;
                    OnPropertyChanged(nameof(CategoryId));
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }
            }
        }

        public string Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged(nameof(UnitPrice));
                }
            }
        }

        public int UnitsInStock
        {
            get { return _unitsInStock; }
            set
            {
                if (_unitsInStock != value)
                {
                    _unitsInStock = value;
                    OnPropertyChanged(nameof(UnitsInStock));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ProductDTO FromProduct(Product product)
        {
            return new ProductDTO
            {
                CategoryId= product.CategoryId,
                ProductId= product.ProductId,
                ProductName= product.ProductName,
                UnitPrice= product.UnitPrice,   
                UnitsInStock = product.UnitsInStock,
                Weight  = product.Weight,   
            };
        }
    }
}
