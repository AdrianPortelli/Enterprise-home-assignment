using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    class OrderDetailsRepository : IOrderDetailsRepository
    {
        ShoppingCartDbContext _context;
        public OrderDetailsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void AddOrderDetails(OrderDetails od)
        {
                _context.OrderDetails.Add(od);
                _context.SaveChanges();
           
        }

        public IQueryable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails;
        }
    }
}
