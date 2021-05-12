using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities.Common;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly ISubCategoryRepository _subCategoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, ISubCategoryRepository subCategoryRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _subCategoryRepo = subCategoryRepo;
        }

        public bool CategoryExists(int id)
        {
            var existed = _repo.GetById(id);
            if(existed == null){
                return false;
            }
            return true;
        }

        public CategoryDto CreateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            int res = _repo.Create(category);

            if(res <= 0){
                return null;
            }
            return categoryDto;
        }

        public CategoryDto DeleteCategory(int id)
        {
            var existed = this.CategoryExists(id);
            if(!existed){
                return null;
            }

            var category = _repo.GetById(id);
            int res = _repo.Delete(category);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<CategoryDto>(category);
        }

        public IEnumerable<CategoryFullDto> GetAll()
        {
            var categories = _repo.GetAll();
            var categoryFullDtos = _mapper.Map<IEnumerable<CategoryFullDto>>(categories);
            var subCategories = _subCategoryRepo.GetAll();
            var subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
            foreach (CategoryFullDto c in categoryFullDtos) {
                c.SubCategories = new List<SubCategoryDto>();
                foreach (SubCategoryDto s in subCategoryDtos) {
                    if (c.Id == s.Category.Id) {
                        c.SubCategories.Add(s);
                    }
                }
            }
            return categoryFullDtos;
        }

        public BaseSearchDto<CategoryDto> GetAll(BaseSearchDto<CategoryDto> searchDto) {
            var categorySearch = _repo.GetAll(searchDto);
            BaseSearchDto<CategoryDto> categoryDtoSearch = new BaseSearchDto<CategoryDto>{
                currentPage = categorySearch.currentPage,
                recordOfPage = categorySearch.recordOfPage,
                totalRecords = categorySearch.totalRecords,
                sortAsc = categorySearch.sortAsc,
                sortBy = categorySearch.sortBy,
                createdDateSort = categorySearch.createdDateSort,
                pagingRange = categorySearch.pagingRange,
                result = _mapper.Map<List<CategoryDto>>(categorySearch.result)
            };
            return categoryDtoSearch;
        }

        public List<CategoryDto> GetLikeName(string name) {
            var categories = _repo.GetLikeName(name);
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _repo.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public CategoryDto UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            int res = _repo.Update(category);

            if(res <= 0){
                return null;
            }
            return categoryDto;
        }

        public IEnumerable<SubCategoryDto> GetSubCategories(int subCategoryId)
        {
            var category = _repo.GetCategoryBySubCategoryId(subCategoryId);
            var subCategories = _repo.GetSubCategories(category.Id);
            return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
        }

        public IEnumerable<SubCategoryDto> GetSubCategoriesByCategory(int categoryId){
            var subCategories = _repo.GetSubCategories(categoryId);
            return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
        }
    }
}