using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class ImportingOrderService : IImportingOrderService
    {
        private readonly IImportingOrderRepository _orderRepo;
        private readonly IImportingTransactionRepository _transRepo;
        private readonly IMapper _mapper;

        public ImportingOrderService(IImportingOrderRepository orderRepo, IMapper mapper, 
                                IImportingTransactionRepository transRepo)
        {
            _orderRepo = orderRepo;
            _transRepo = transRepo;
            _mapper = mapper;
        }

        public ImportingOrderDto CreateImportingOrder(ImportingOrderDto orderDto)
        {
            var order = _mapper.Map<ImportingOrder>(orderDto);
            int res = _orderRepo.Create(order);

            if(res <= 0){
                return null;
            }
            return orderDto;
        }

        public ImportingOrderDto DeleteImportingOrder(int id)
        {
            var existed = this.ImportingOrderExists(id);
            if(!existed){
                return null;
            }
            var order = _orderRepo.GetById(id);
            int res = _orderRepo.Delete(order);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<ImportingOrderDto>(order);
        }

        public IEnumerable<ImportingOrderDto> GetAll()
        {
            var orders = _orderRepo.GetAll();
            return _mapper.Map<IEnumerable<ImportingOrderDto>>(orders);
        }

        public ImportingOrderDto GetImportingOrder(int id)
        {
            var order = _orderRepo.GetById(id);
            return _mapper.Map<ImportingOrderDto>(order);
        }

        public bool ImportingOrderExists(int id)
        {
            var order = _orderRepo.GetById(id);
            if(order == null){
                return false;
            }
            return true;
        }

        public ImportingOrderDto UpdateImportingOrder(ImportingOrderDto orderDto)
        {
            var order = _mapper.Map<ImportingOrder>(orderDto);
            int res = _orderRepo.Update(order);

            if(res <= 0){
                return null;
            }
            return orderDto;
        }
    }
}