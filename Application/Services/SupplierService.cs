using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public SupplierDto CreateSupplier(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            int res = _repo.Create(supplier);

            if(res <= 0){
                return null;
            }
            return supplierDto;
        }

        public SupplierDto DeleteSupplier(int id)
        {
            var existed = this.SupplierExists(id);
            if(!existed){
                return null;
            }
            var supplier = _repo.GetById(id);
            int res = _repo.Delete(supplier);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<SupplierDto>(supplier);
        }

        public IEnumerable<SupplierDto> GetAll()
        {
             var suppliers = _repo.GetAll();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public SupplierDto GetSupplier(int id)
        {
            var supplier= _repo.GetById(id);
            return _mapper.Map<SupplierDto>(supplier);
        }

        public bool SupplierExists(int id)
        {
            var supplier= _repo.GetById(id);
            if(supplier== null){
                return false;
            }
            return true;
        }

        public SupplierDto UpdateSupplier(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            int res = _repo.Update(supplier);

            if(res <= 0){
                return null;
            }
            return supplierDto;
        }
    }
}