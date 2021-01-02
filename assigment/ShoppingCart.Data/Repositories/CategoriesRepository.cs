using System;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCart.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {

        ShoppingCartDbContext _context;
        public CategoriesRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
