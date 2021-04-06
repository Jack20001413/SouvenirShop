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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repo.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
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
    }
}