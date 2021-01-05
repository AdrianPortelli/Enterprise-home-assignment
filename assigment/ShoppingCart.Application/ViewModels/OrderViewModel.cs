using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderViewModel
    {

        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime Dateplaced { get; set; }
        [Required]
        public string UserEmail { get; set; }
    }
}
