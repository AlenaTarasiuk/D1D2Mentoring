using System;
using System.Collections.Generic;

namespace ProjectDAL
{
    public interface IBDWork
    {
        IList<Order> GetOrders();
        Details GetOrderDetails(Order order);
        void CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
        bool SetInProgress(Order order, DateTime? orderDate);
        void SetComplete(Order order, DateTime? shippedDate);
        IList<CustOrderHist> GetCustomerOrdersHistory(string customerId);
        IList<CustOrdersDetail> GetCustomerOrdersDetail(int orderId);
    }
}
