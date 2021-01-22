using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrderRepository
    {
        public void AddOrder(Order o);
        public void AddOrderDetails(OrderDetails od);
    }
}
