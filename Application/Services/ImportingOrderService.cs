using System.Collections.Generic;
using System.Linq;
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
        private readonly ISupplierRepository _supplierRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public ImportingOrderService(IImportingOrderRepository orderRepo
                                    ,IMapper mapper 
                                    ,IImportingTransactionRepository transRepo
                                    ,ISupplierRepository supplierRepo
                                    ,IEmployeeRepository employeeRepo)
        {
            _orderRepo = orderRepo;
            _transRepo = transRepo;
            _mapper = mapper;
            _supplierRepo = supplierRepo;
            _employeeRepo = employeeRepo;
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

        public BaseSearchDto<ImportingOrderDto> GetAll(BaseSearchDto<ImportingOrderDto> searchDto)
        {
            var orderSearch = _orderRepo.GetAll(searchDto);
            var suppliers = _supplierRepo.GetAll().ToList();
            var employees = _employeeRepo.GetAll().ToList();

            foreach (ImportingOrder o in orderSearch.result) {
                o.Supplier = suppliers.Where(s => s.Id == o.SupplierId).FirstOrDefault();
                o.Employee = employees.Where(e => e.Id == o.EmployeeId).FirstOrDefault();
            }

            BaseSearchDto<ImportingOrderDto> orderDtoSearch = new BaseSearchDto<ImportingOrderDto>{
                currentPage = orderSearch.currentPage,
                recordOfPage = orderSearch.recordOfPage,
                totalRecords = orderSearch.totalRecords,
                sortAsc = orderSearch.sortAsc,
                sortBy = orderSearch.sortBy,
                createdDateSort = orderSearch.createdDateSort,
                pagingRange = orderSearch.pagingRange,
                result = _mapper.Map<List<ImportingOrderDto>>(orderSearch.result)
            };
            return orderDtoSearch;
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