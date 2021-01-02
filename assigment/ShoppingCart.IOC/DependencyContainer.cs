using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services,string connectionString)
        {

            //when are the instances created?

            /*
             * Singletion:IoC container will create and share a single incstane of a service throught our the applicaiton's lifetime.
             * (many requests > 1 instance)
             * 
             * Transient: the IoC container will create a new instance of the specified service type every time you ask for it.
             * (1 request > multiple isntances)
             * Scoped:IoC container will creat an instance of the specified service type once per request will be shared in a single request.
             * (1 request >1 instance)
             */

            //Shortcut key ctrl + .
            services.AddDbContext<ShoppingCartDbContext>(options =>
             options.UseSqlServer(
                 connectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();

            //move Intitialization of shoppingcartDBContext to here and refine the dependencies

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();


        }
    }
}
