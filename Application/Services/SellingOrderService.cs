using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class SellingOrderService : ISellingOrderService
    {
        private readonly ISellingOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public SellingOrderService(ISellingOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public SellingOrderDto CreateSellingOrder(SellingOrderDto orderDto)
        {
            var order = _mapper.Map<SellingOrder>(orderDto);
            int res = _orderRepo.Create(order);

            if(res <= 0){
                return null;
            }
            return orderDto;
        }

        public SellingOrderDto DeleteSellingOrder(int id)
        {
            var existed = this.SellingOrderExists(id);
            if(!existed){
                return null;
            }
            var order = _orderRepo.GetById(id);
            int res = _orderRepo.Delete(order);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<SellingOrderDto>(order);
        }

        public IEnumerable<SellingOrderDto> GetAll()
        {
            var orders = _orderRepo.GetAll();
            return _mapper.Map<IEnumerable<SellingOrderDto>>(orders);
        }

        public SellingOrderDto GetSellingOrder(int id)
        {
            var order = _orderRepo.GetById(id);
            return _mapper.Map<SellingOrderDto>(order);
        }

        public bool SellingOrderExists(int id)
        {
            var order = _orderRepo.GetById(id);
            if(order == null){
                return false;
            }
            return true;
        }

        public SellingOrderDto UpdateSellingOrder(SellingOrderDto orderDto)
        {
            var order = _mapper.Map<SellingOrder>(orderDto);
            int res = _orderRepo.Update(order);

            if(res <= 0){
                return null;
            }
            return orderDto;
        }
    }
}