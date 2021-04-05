using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public ProductDto CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            int res = _productRepo.Create(product);

            if(res == 0){
                return null;
            }
            return productDto;
        }

        public ProductDto DeleteProduct(int id)
        {
            if(!ProductExists(id)){
                return null;
            }

            var product = _productRepo.GetById(id);
            int res = _productRepo.Delete(product);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _productRepo.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProduct(int id)
        {
            var product = _productRepo.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public bool ProductExists(int id)
        {
            if(_productRepo.GetById(id) != null){
                return true;
            }
            return false;
        }

        public ProductDto UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            int res = _productRepo.Update(product);

            if(res <= 0){
                return null;
            }
            return productDto;
        }
    }
}