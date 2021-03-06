using System.Collections.Generic;
using System.Linq;
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
        private readonly IProductDetailRepository _productDetailRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IConfiguration _config;
        private readonly IProductRepository _productRepo;

        public SellingOrderService(ISellingOrderRepository orderRepo
                                   ,IMapper mapper
                                   ,ISellingTransactionRepository transRepo
                                   ,ICustomerRepository customerRepo
                                   ,IProductDetailRepository productDetailRepo
                                   ,IConfiguration config
                                   ,IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _transRepo = transRepo;
            _productDetailRepo = productDetailRepo;
            _customerRepo = customerRepo;
            _config = config;
            _productRepo = productRepo;
        }

        public SellingOrderDto CreateSellingOrder(SellingOrderDto orderDto)
        {
            var order = _mapper.Map<SellingOrder>(orderDto);

            foreach(SellingTransaction transaction in order.SellingTransactions){
                // Trừ số lượng của từng chi tiết sản phẩm
                var productDetail = _productDetailRepo.GetById(transaction.ProductDetailId);
                productDetail.Quantity = productDetail.Quantity - transaction.Quantity;
                _productDetailRepo.Update(productDetail);

                // Trừ số lượng của sản phẩm
                var product = _productRepo.GetById(productDetail.ProductId);
                product.Quantity = product.Quantity - transaction.Quantity;
                _productRepo.Update(product);
            }

            

            int res = _orderRepo.Create(order);

            if(res <= 0){
                return null;
            }
            int insertedId = _orderRepo.GetLatestSellingOrderId();
            var orderInserted = this.GetSellingOrder(insertedId);
            var orderDtoInserted = _mapper.Map<SellingOrderDto>(orderInserted);
            return orderDtoInserted;
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

        public IEnumerable<SellingOrderDto> GetSellingOrderByCustomerId(int id)
        {
            var orders = _orderRepo.GetSellingOrderByCustomerId(id);
            var orderDtos = _mapper.Map<IEnumerable<SellingOrderDto>>(orders);
            foreach(SellingOrderDto order in orderDtos){
                var transactions = _transRepo.GetTransactionBySellingId(order.Id);
                order.SellingTransactions = _mapper.Map<List<SellingTransactionDto>>(transactions);
            }
            return orderDtos;
        }

        public IEnumerable<SellingTransactionDto> GetSellingTransactionByOrderId(int id)
        {
            var transactions = _transRepo.GetTransactionBySellingId(id);
            return _mapper.Map<IEnumerable<SellingTransactionDto>>(transactions);
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

        public OrderPaymentIntentDto CreatePaymentIntent(int orderId)
        {
            var order = _orderRepo.GetById(orderId);
            var customer = _customerRepo.GetById(order.CustomerId);
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var service = new PaymentIntentService();

            var options = new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt64(order.Total),
                Currency = "vnd",
                PaymentMethodTypes = new List<string> { "card" },
            
            };

            var intent = service.Create(options);

            order.PaymentIndentId = intent.Id;
            order.ClientSecret = intent.ClientSecret;

            _orderRepo.Update(order);

            var orderPaymentIntentDto = new OrderPaymentIntentDto();
            orderPaymentIntentDto.PaymentIndentId = intent.Id;
            orderPaymentIntentDto.ClientSecret = intent.ClientSecret;

            return orderPaymentIntentDto;
        }

        public List<MonthCostDetailDto> getMonthCostDetails(RangeDateDto rangeDateDto) {
            var orders = _orderRepo.GetAll();
            var result = new List<MonthCostDetailDto>();
            for (var i=1;i<=12;i++) {
                MonthCostDetailDto m = new MonthCostDetailDto();
                m.YearDate = rangeDateDto.ToDate.Year;
                m.MonthDate = i;
                m.Total = 0;
                result.Add(m);
            }
            foreach(SellingOrder s in orders) {
                if (s.InvoiceDate.Year != rangeDateDto.ToDate.Year) {
                    continue;
                }
                for (var i=1;i<=12;i++) {
                    if (s.InvoiceDate.Month == i) {
                        result[i-1].Total += s.Total;
                        break;
                    }
                }
            }
            return result.ToList();
        }
    }
}