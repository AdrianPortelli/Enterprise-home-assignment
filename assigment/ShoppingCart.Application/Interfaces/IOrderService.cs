﻿using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderService
    {
        IQueryable<OrderViewModel> GetOrder();
        void AddOrder(OrderViewModel o);
    }
}