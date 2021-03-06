﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApp.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;

        public ProductsController(IProductsService productsService,ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {

            var listOfCategories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategories; 


            var list = _productsService.GetProducts();

            return View(await PaginatedList<ProductViewModel>.CreateAsync(_productsService.GetProducts(),pageNumber,10));
        }

        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            return View(p);
        }

        //the engine will load a page with empty fields
        [HttpGet]
        [Authorize (Roles ="Admin")]//the create method is going to be accessed by authenticated users
        public IActionResult Create()
        {
            //feth a list of categories
            var listofCategories = _categoriesService.GetCategories();


            //we pass the categories to the page
            ViewBag.Categories = listofCategories;
            return View();
        }
        //here details input by the user will be received
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
         {
            try 
            {

                if(f != null)
                {
                    if (f.Length > 0)
                    {
                        string newfilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newfilenamewithAbsoluatePath = _env.WebRootPath + @"/images/" + newfilename;



                        using (var stream = System.IO.File.Create(newfilenamewithAbsoluatePath))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newfilename;
                    }
                }


                _productsService.AddProduct(data);

                ViewData["feedback"] = "Product was added successfully";
            }catch(Exception ex)
            {
                //log error
                ViewData["warning"] = "Product was not added";
            }
            var listOfCategories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategories;
            return View(data);
         }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ViewData["feedback"] = "Product was deleted";
                _productsService.DeleteProduct(id);
             
            }
            catch(Exception ex)
            {
                //log your error
                ViewData["warning"] = "Product was not deleted";//Change from viewData to tempData
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keyword,int pageNumber = 1)
        {
            var list = _productsService.GetProducts(keyword).ToList();
            return View("Index",await PaginatedList<ProductViewModel>.CreateAsync(_productsService.GetProducts(keyword), pageNumber, 10));
        }

        

    }
}
