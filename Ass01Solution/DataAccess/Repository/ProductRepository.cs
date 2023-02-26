using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product productCreate)
        {
            ProductManagement.Instance.CreateProduct(productCreate);
        }

        public bool DeleteProduct(int productId)
        {
            return ProductManagement.Instance.DeleteProduct(productId);
        }

        public ObservableCollection<ProductDTO> GetListProduct(string parmeter)
        {
            return  ProductManagement.Instance.GetListProduct(parmeter);
        }

        public ObservableCollection<ProductDTO> GetListProductByCondition(int id, string name, decimal price, int quantity)
        {
            return ProductManagement.Instance.GetListProductByCondition(id, name, price, quantity);     
        }

        public ProductDTO GetProductById(int id)
        {
            return ProductManagement.Instance.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return ProductManagement.Instance.GetProductByName(name);
        }

        public void UpdateProduct(Product productUpdate)
        {
            ProductManagement.Instance.UpdateProduct(productUpdate);
        }
    }
}
