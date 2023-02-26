using DataAccess.DTOs;
using DataAccess.Management;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public bool CreateOrder(Order orderInfo, ObservableCollection<ProductDTO> listOrder)
        {
            return  OrderManagement.Instance.CreateOrder(orderInfo, listOrder);
        }

        public ObservableCollection<OrderDTO> GetListOrderByCondition(string email, DateTime? startDate, DateTime? endDate, Member? member)
        {
            return OrderManagement.Instance.GetListOrderByCondition(email, startDate, endDate, member);
        }

        public ObservableCollection<ProductDTO> GetListProductByOrderId(int OrderId)
        {
            return OrderManagement.Instance.GetListProductByOrderId(OrderId);
        }
    }
}
