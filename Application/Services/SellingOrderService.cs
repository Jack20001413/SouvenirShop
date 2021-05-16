using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using Stripe;
namespace Application.Services
{
    public class SellingOrderService : ISellingOrderService
    {
        private readonly ISellingOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        private readonly ISellingTransactionRepository _transRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IConfiguration _config;

        public SellingOrderService(ISellingOrderRepository orderRepo
                                   ,IMapper mapper
                                   ,ISellingTransactionRepository transRepo
                                   ,ICustomerRepository customerRepo
                                   ,IConfiguration _config)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _transRepo = transRepo;
            _customerRepo = customerRepo;
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

        public BaseSearchDto<SellingOrderDto> GetAll(BaseSearchDto<SellingOrderDto> searchDto)
        {
            var orderSearch = _orderRepo.GetAll(searchDto);
            var customers = _customerRepo.GetAll().ToList();

            foreach (SellingOrder o in orderSearch.result) {
                o.Customer = customers.Where(c => c.Id == o.CustomerId).FirstOrDefault();
            }

            BaseSearchDto<SellingOrderDto> orderDtoSearch = new BaseSearchDto<SellingOrderDto>{
                currentPage = orderSearch.currentPage,
                recordOfPage = orderSearch.recordOfPage,
                totalRecords = orderSearch.totalRecords,
                sortAsc = orderSearch.sortAsc,
                sortBy = orderSearch.sortBy,
                createdDateSort = orderSearch.createdDateSort,
                pagingRange = orderSearch.pagingRange,
                result = _mapper.Map<List<SellingOrderDto>>(orderSearch.result)
            };
            return orderDtoSearch;
        }

        public SellingOrderDto GetSellingOrder(int id)
        {
            var order = _orderRepo.GetById(id);
            order.Customer = _customerRepo.GetById(order.CustomerId);
            var sellingTransactions = _transRepo.GetTransactionBySellingId(id);
            var orderDto = _mapper.Map<SellingOrderDto>(order);
            orderDto.SellingTransactions = _mapper.Map<List<SellingTransactionDto>>(sellingTransactions);
            return orderDto;
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

        // public async Task<OrderPaymentIntentDto> CreatePaymentIntentAsync(SellingOrderDto sellingOrder)
        // {
        //     StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

        //     var service = new PaymentIntentService();

        //     var options = new PaymentIntentCreateOptions
        //     {
        //         Amount = Convert.ToInt64(sellingOrder.Total) * 100,
        //         Currency = "usd",
        //         PaymentMethodTypes = new List<string> { "card" }
        //     };

        //     var intent = await service.CreateAsync(options);

        //     sellingOrder.PaymentIntent = new OrderPaymentIntentDto
        //     {
        //         PaymentIndentId = intent.Id,
        //         ClientSecret = intent.ClientSecret
        //     };
        //     sellingOrder.

        //     _unitOfWork.Orders.Update(sellingOrder);
        //     await _unitOfWork.CompleteAsync();

        //     return sellingOrder.PaymentIntent;
        // }
    }
}