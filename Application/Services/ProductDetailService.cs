using System.Collections.Generic;
using System.Linq;
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
        private readonly IProductRepository _productRepo;
        

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
        public BaseSearchDto<ProductDetailDto> GetAll(BaseSearchDto<ProductDetailDto> searchDto)
        {
            var productdetailSearch = _repo.GetAll(searchDto);
            var products = _productRepo.GetAll().ToList();

            foreach (ProductDetail c in productdetailSearch.result) {
                c.Product = products.Where(s => s.Id == c.ProductId).FirstOrDefault();
            }

            BaseSearchDto<ProductDetailDto> productdetailDtoSearch = new BaseSearchDto<ProductDetailDto>{
                currentPage = productdetailSearch.currentPage,
                recordOfPage = productdetailSearch.recordOfPage,
                totalRecords = productdetailSearch.totalRecords,
                sortAsc = productdetailSearch.sortAsc,
                sortBy = productdetailSearch.sortBy,
                createdDateSort = productdetailSearch.createdDateSort,
                pagingRange = productdetailSearch.pagingRange,
                result = _mapper.Map<List<ProductDetailDto>>(productdetailSearch.result)
            };
            return productdetailDtoSearch;
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