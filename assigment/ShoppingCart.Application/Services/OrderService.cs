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
    public class OrderService : IOrderService
    {

        private IOrderRepository _ordersRepo;
        private IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {

            _mapper = mapper;
            _ordersRepo = orderRepository;

        }
        public void AddOrder(OrderViewModel o)
        {
            _ordersRepo.AddOrder(_mapper.Map<Order>(o));
        }

        public IQueryable<OrderViewModel> GetOrder()
        {
            var order = _ordersRepo.GetOrder().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
            return order;
        }
        
    }
}
