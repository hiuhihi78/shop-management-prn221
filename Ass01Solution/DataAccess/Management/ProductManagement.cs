using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Management
{
    public class ProductManagement
    {
        //Using Singleton Pattern
        private static ProductManagement instance = null;
        private static readonly object instanceLock = new object();

        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                }
                return instance;
            }
        }

        private ProductManagement() { }


        public  ProductDTO GetProductById(int id)
        {
            ProductDTO? product;
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();
                product = ProductDTO.FromProduct(context.Products.FirstOrDefault(x => x.ProductId == id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public Product GetProductByName(string name)
        {
            Product? product;
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();
                product = context.Products.FirstOrDefault(x => x.ProductName == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public ObservableCollection<ProductDTO> GetListProduct(string parmeter)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            ObservableCollection<ProductDTO> result = new ObservableCollection<ProductDTO>();
            var products = context.Products.Where(x => x.ProductName.Contains(parmeter)).ToList();
            foreach (var memeber in products)
            {
                result.Add(ProductDTO.FromProduct(memeber));
            }
            return result;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                Assgiment1PrnContext context = new Assgiment1PrnContext();
                var product = context.Products.FirstOrDefault(x => x.ProductId == productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void CreateProduct(Product productCreate)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            context.Products.Add(productCreate);
            context.SaveChanges();
        }

        public void UpdateProduct(Product productUpdate)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            var product = context.Products.FirstOrDefault(x => x.ProductId == productUpdate.ProductId);
            product.ProductName = productUpdate.ProductName;
            product.UnitsInStock = productUpdate.UnitsInStock;  
            product.UnitPrice = productUpdate.UnitPrice;
            product.Weight = productUpdate.Weight;  
            context.SaveChanges();
        }
    }
}
