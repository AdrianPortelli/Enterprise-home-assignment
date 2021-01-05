using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{

    public class OrderDetailsService : IOrderDetailsService
    {
        private IOrderDetailsRepository _ordersDetailsRepo;
        private IMapper _mapper;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {

            _mapper = mapper;
            _ordersDetailsRepo = orderDetailsRepository;

        }
        public void AddOrderDetails(OrderDetailsViewModel od)
        {
            _ordersDetailsRepo.AddOrderDetails(_mapper.Map<OrderDetails>(od));
        }

        public IQueryable<OrderDetailsViewModel> GetOrderDetails()
        {
            var orderDetails = _ordersDetailsRepo.GetOrderDetails().ProjectTo<OrderDetailsViewModel>(_mapper.ConfigurationProvider);
            return orderDetails;
        }
    }
}
