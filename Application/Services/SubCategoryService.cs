using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;
using SouvenirShop.Domain.Entities.Common;

namespace Application.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository repo, ICategoryRepository categoryRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public SubCategoryDto CreateSubCategory(SubCategoryDto subCategoryDto)
        {
            var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
            int res = _repo.Create(subCategory);

            if(res <= 0){
                return null;
            }
            return subCategoryDto;
        }

        public SubCategoryDto DeleteSubCategory(int id)
        {
            var existed = this.SubCategoryExists(id);
            if(!existed){
                return null;
            }
            var subCategory = _repo.GetById(id);
            int res = _repo.Delete(subCategory);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<SubCategoryDto>(subCategory);
        }

        public IEnumerable<SubCategoryDto> GetAll()
        {
            var subCategories = _repo.GetAll();
            return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
        }

        public BaseSearchDto<SubCategoryDto> GetAll(BaseSearchDto<SubCategoryDto> searchDto) {
            var subCategorySearch = _repo.GetAll(searchDto);
            var categories = _categoryRepo.GetAll().ToList();
            foreach (SubCategory c in subCategorySearch.result) {
                c.Category = categories.Where(s => s.Id == c.CategoryId).FirstOrDefault();
            }
            BaseSearchDto<SubCategoryDto> subCategoryDtoSearch = new BaseSearchDto<SubCategoryDto>{
                currentPage = subCategorySearch.currentPage,
                recordOfPage = subCategorySearch.recordOfPage,
                totalRecords = subCategorySearch.totalRecords,
                sortAsc = subCategorySearch.sortAsc,
                sortBy = subCategorySearch.sortBy,
                createdDateSort = subCategorySearch.createdDateSort,
                pagingRange = subCategorySearch.pagingRange,
                result = _mapper.Map<List<SubCategoryDto>>(subCategorySearch.result)
            };
            return subCategoryDtoSearch;
        }

        public List<SubCategoryDto> GetLikeName(string name) {
            var subCategories = _repo.GetLikeName(name);
            return _mapper.Map<List<SubCategoryDto>>(subCategories);
        }

        public SubCategoryDto GetSubCategory(int id)
        {
            var subCategory = _repo.GetById(id);
            subCategory.Category = _categoryRepo.GetById(subCategory.CategoryId);
            return _mapper.Map<SubCategoryDto>(subCategory);
        }

        public bool SubCategoryExists(int id)
        {
            var subCategory = _repo.GetById(id);
            if(subCategory == null){
                return false;
            }
            return true;
        }

        public SubCategoryDto UpdateSubCategory(SubCategoryDto subCategoryDto)
        {
            var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
            int res = _repo.Update(subCategory);

            if(res <= 0){
                return null;
            }
            return subCategoryDto;
        }
    }
}