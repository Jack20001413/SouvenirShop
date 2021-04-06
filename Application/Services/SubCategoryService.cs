using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repo;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public SubCategoryDto GetSubCategory(int id)
        {
            var subCategory = _repo.GetById(id);
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