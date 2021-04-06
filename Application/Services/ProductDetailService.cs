using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _repo;
        private readonly IMapper _mapper;

        public ProductDetailService(IProductDetailRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ProductDetailDto CreateProductDetail(ProductDetailDto productDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(productDetailDto);
            int res = _repo.Create(productDetail);

            if(res <= 0){
                return null;
            }
            return productDetailDto;
        }

        public ProductDetailDto DeleteProductDetail(int id)
        {
            var existed = this.ProductDetailExists(id);
            if(!existed){
                return null;
            }
            var productDetail = _repo.GetById(id);
            int res = _repo.Delete(productDetail);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<ProductDetailDto>(productDetail);
        }

        public IEnumerable<ProductDetailDto> GetAll()
        {
            var details = _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductDetailDto>>(details);
        }

        public ProductDetailDto GetProductDetail(int id)
        {
            var detail = _repo.GetById(id);
            return _mapper.Map<ProductDetailDto>(detail);
        }

        public bool ProductDetailExists(int id)
        {
            var detail = _repo.GetById(id);
            if(detail == null){
                return false;
            }
            return true;
        }

        public ProductDetailDto UpdateProductDetail(ProductDetailDto productDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(productDetailDto);
            int res = _repo.Update(productDetail);

            if(res <= 0){
                return null;
            }
            return productDetailDto;
        }
    }
}