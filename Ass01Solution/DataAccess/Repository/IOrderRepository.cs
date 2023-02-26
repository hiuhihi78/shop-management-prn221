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
    public interface IOrderRepository
    {
        bool CreateOrder(Order orderInfo, ObservableCollection<ProductDTO> listOrder);
        ObservableCollection<OrderDTO> GetListOrderByCondition(string email, DateTime? startDate, DateTime? endDate, Member? member);
        ObservableCollection<ProductDTO> GetListProductByOrderId(int OrderId);

    }
}
