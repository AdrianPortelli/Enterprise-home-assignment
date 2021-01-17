using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public List<Product> CartItems { get; set; }


    }
}
