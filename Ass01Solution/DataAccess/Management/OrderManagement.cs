using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Management
{
    public class OrderManagement
    {

        //Using Singleton Pattern
        private static OrderManagement instance = null;
        private static readonly object instanceLock = new object();

        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                }
                return instance;
            }
        }

        private OrderManagement() { }

        public bool CreateOrder(Order orderInfo, ObservableCollection<ProductDTO> listOrder)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            var transaction = context.Database.BeginTransaction();
            try
            {
                // add order
                context.Orders.Add(orderInfo);
                context.SaveChanges();

                var orderId = orderInfo.OrderId;

                // add order detail
                foreach (ProductDTO item in listOrder)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.UnitsInStock,
                        UnitPrice = item.UnitPrice,
                        Discount = 0
                    };
                    context.OrderDetails.Add(orderDetail);

                    // decrease product's quantity
                    var product = context.Products.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                    if (product != null)
                    {
                        if (product.UnitsInStock >= orderDetail.Quantity)
                        {
                            product.UnitsInStock = product.UnitsInStock - item.UnitsInStock;
                        }
                        else
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                context.SaveChanges();
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }


        public ObservableCollection<OrderDTO> GetListOrderByCondition(string email, DateTime? startDate, DateTime? endDate, Member? member)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            List<Order> list = new List<Order>();
            if(member == null)
            {
                if (startDate != null && endDate != null)
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.OrderDate <= endDate && x.OrderDate >= startDate && x.Member.Email.Contains(email)).ToList();
                }
                else if (startDate == null && endDate != null)
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.OrderDate <= endDate && x.Member.Email.Contains(email)).ToList();
                }
                else
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.Member.Email.Contains(email)).ToList();
                }
            }
            else
            {
                if (startDate != null && endDate != null)
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.OrderDate <= endDate && x.OrderDate >= startDate && x.Member.Email == member.Email).ToList();
                }
                else if (startDate == null && endDate != null)
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.OrderDate <= endDate && x.Member.Email == (email)).ToList();
                }
                else
                {
                    list = context.Orders.Include(x => x.Member).Where(x => x.Member.Email == member.Email).ToList();
                }
            }
            
            
            ObservableCollection<OrderDTO> orders = new ObservableCollection<OrderDTO>();
            foreach (var item in list)
            {
                orders.Add(OrderDTO.FromOrder(item));
            }
            return orders;
        }

        public ObservableCollection<ProductDTO> GetListProductByOrderId(int OrderId)
        {
            Assgiment1PrnContext context = new Assgiment1PrnContext();
            ObservableCollection<ProductDTO> result = new ObservableCollection<ProductDTO>();

            var listProductId = context.OrderDetails.Where(x => x.OrderId == OrderId).ToList();
            foreach (var item in listProductId) 
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == item.ProductId);  
                result.Add(ProductDTO.FromProduct(product));
            }
            return result;
        }
    }
}
