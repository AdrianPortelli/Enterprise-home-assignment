using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Domain.Models;

namespace PresentationWebApp.Controllers
{
    public class CartController : Controller
    {
    
        public IActionResult Index()
        {
        
            return View();
        }
        public void addToCart(Guid id)
        {
            //needs to be implemented
        }

        public void removeProduct(Guid id)
        {
            //needs to be implemeted
        }
        
        public void checkOut()
        {
            //needs to be implemented
        }
    }
}
