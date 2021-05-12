using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repo;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public bool ColorExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public ColorDto CreateColor(ColorDto colorDto)
        {
            var color = _mapper.Map<Color>(colorDto);
            int res = _repo.Create(color);

            if(res == 0){
                return null;
            }
            return colorDto;
        }

        public ColorDto DeleteColor(int id)
        {
            var colorModel = _repo.GetById(id);
            if(colorModel == null){
                return null;
            }

            var res = _repo.Delete(colorModel);
            if(res <= 0){
                return null;
            }
            return _mapper.Map<ColorDto>(colorModel);
        }

        public IEnumerable<ColorDto> GetAll()
        {
            var colors = _repo.GetAll();
            return _mapper.Map<IEnumerable<ColorDto>>(colors);
        }

        public BaseSearchDto<ColorDto> GetAll(BaseSearchDto<ColorDto> searchDto) {
            var colorSearch = _repo.GetAll(searchDto);
            BaseSearchDto<ColorDto> colorDtoSearch = new BaseSearchDto<ColorDto>{
                currentPage = colorSearch.currentPage,
                recordOfPage = colorSearch.recordOfPage,
                totalRecords = colorSearch.totalRecords,
                sortAsc = colorSearch.sortAsc,
                sortBy = colorSearch.sortBy,
                createdDateSort = colorSearch.createdDateSort,
                pagingRange = colorSearch.pagingRange,
                result = _mapper.Map<List<ColorDto>>(colorSearch.result)
            };
            return colorDtoSearch;
        }

        public List<ColorDto> GetLikeName(string name) {
            var colors = _repo.GetLikeName(name);
            return _mapper.Map<List<ColorDto>>(colors);
        }

        public ColorDto GetColor(int id)
        {
            var color = _repo.GetById(id);
            return _mapper.Map<ColorDto>(color);
        }

        public ColorDto UpdateColor(ColorDto colorDto)
        {
            // var colorModel = _repo.GetById(colorDto.Id);
            // if(colorModel == null){
            //     return null;
            // }
            // ;
            var color = _mapper.Map<Color>(colorDto);
            

            int res = _repo.Update(color);
            if(res <= 0){
                return null;
            }
            return colorDto;
        }
    }
}