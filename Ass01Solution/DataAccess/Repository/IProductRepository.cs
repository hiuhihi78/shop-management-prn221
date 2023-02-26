using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        ProductDTO GetProductById(int id);
        Product GetProductByName(string name);
        ObservableCollection<ProductDTO> GetListProduct(string parmeter);
        bool DeleteProduct(int productId);
        void CreateProduct(Product productCreate);
        void UpdateProduct(Product productUpdate);
        ObservableCollection<ProductDTO> GetListProductByCondition(int id, string name, decimal price, int quantity);

    }
}
