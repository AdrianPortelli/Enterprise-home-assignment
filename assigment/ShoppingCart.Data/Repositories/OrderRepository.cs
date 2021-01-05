using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        ShoppingCartDbContext _context;
        public OrderRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order o)
        {
            _context.Orders.Add(o);
            _context.SaveChanges();
        }

        public IQueryable<Order> GetOrder()
        {
            return _context.Orders;
        }
    }
}
