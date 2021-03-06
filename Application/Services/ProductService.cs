using System.Collections.Generic;
using System.Linq;
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
        private readonly ISubCategoryRepository _subCategoryRepo;

        private readonly IProductDetailRepository _productDetailRepo;
        private readonly IColorRepository _colorRepo;
        private readonly ISizeRepository _sizeRepo;

        public ProductService(
            IProductRepository productRepo, 
            IMapper mapper, 
            ISubCategoryRepository subCategoryRepo, 
            IProductDetailRepository productDetailRepo,
            IColorRepository colorRepo,
            ISizeRepository sizeRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _subCategoryRepo = subCategoryRepo;
            _productDetailRepo = productDetailRepo;
            _colorRepo = colorRepo;
            _sizeRepo = sizeRepo;
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

        public BaseSearchDto<ProductDto> GetAll(BaseSearchDto<ProductDto> searchDto)
        {
            var productSearch = _productRepo.GetAll(searchDto);
            var subCategories = _subCategoryRepo.GetAll().ToList();

            foreach (Product c in productSearch.result) {
                c.SubCategory = subCategories.Where(s => s.Id == c.SubCategoryId).FirstOrDefault();
            }

            BaseSearchDto<ProductDto> productDtoSearch = new BaseSearchDto<ProductDto>{
                currentPage = productSearch.currentPage,
                recordOfPage = productSearch.recordOfPage,
                totalRecords = productSearch.totalRecords,
                sortAsc = productSearch.sortAsc,
                sortBy = productSearch.sortBy,
                createdDateSort = productSearch.createdDateSort,
                pagingRange = productSearch.pagingRange,
                result = _mapper.Map<List<ProductDto>>(productSearch.result)
            };
            return productDtoSearch;
        }

        public List<ProductDto> GetLikeName(string name)
        {
            var products = _productRepo.GetLikeName(name);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public List<ProductDto> GetList(int id)
        {
            var products = _productRepo.GetList(id);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public List<ProductDto> GetListByCategory(int id)
        {
            List<string> ids = new List<string>();
            var subCategories = _subCategoryRepo.GetSubCategoryByCategoryId(id);
            foreach (SubCategory subCategory in subCategories){
                ids.Add(subCategory.Id.ToString());
            }
            var productList = _productRepo.GetListByCategory(ids);
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public ProductDto GetProduct(int id)
        {
            var product = _productRepo.GetById(id);
            product.SubCategory = _subCategoryRepo.GetById(product.SubCategoryId);
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

        public ProductFullDto GetProductFull(int id){
            var product = _productRepo.GetById(id);
            product.SubCategory = _subCategoryRepo.GetById(product.SubCategoryId);
            
            var productFull = _mapper.Map<ProductFullDto>(product);
            
            var colors = _colorRepo.GetAll().ToList();
            var sizes = _sizeRepo.GetAll().ToList();

            var productDetails = _productDetailRepo.GetByProduct(id);
            foreach (ProductDetail d in productDetails) {
                d.Color = colors.Where(s => s.Id == d.ColorId).FirstOrDefault();
                d.Size = sizes.Where(s => s.Id == d.SizeId).FirstOrDefault();
            }
            var productDetailDtos = _mapper.Map<List<ProductDetailDto>>(productDetails);
            productFull.ProductDetails = productDetailDtos;
            return productFull;
        }
    }
}