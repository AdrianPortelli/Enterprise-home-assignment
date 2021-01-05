using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailsViewModel
    {
   
        [Required]
        public Guid Id { get; set; }

        [Required]
        public ProductViewModel Product { get; set; }

        [Required]
        public OrderViewModel Order { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public Double Price { get; set; }
    }
}
