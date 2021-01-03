using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class ProductViewModel
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Must contain a name")]
        [StringLength(30, ErrorMessage = "Name length can't be more than 30.")]
        public string Name { get; set; }

       
        [Range(typeof(double), "1", "9999.99", ErrorMessage = "{0} Invaild price, price should be bettween {1} and {2}")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Must contain a Description")]
        [StringLength(1000, ErrorMessage = "Description length can't be more than 1000.")]
        public string Description { get; set; }

       
        public CategoryViewModel Category { get; set; }

        public string ImageUrl { get; set; }
    }
}
