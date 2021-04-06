using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _repo;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public SizeDto CreateSize(SizeDto sizeDto)
        {
            var size = _mapper.Map<Size>(sizeDto);
            int res = _repo.Create(size);

            if(res <= 0){
                return null;
            }
            return sizeDto;
        }

        public SizeDto DeleteSize(int id)
        {
            var existed = this.SizeExists(id);
            if(!existed){
                return null;
            }
            var size = _repo.GetById(id);
            int res = _repo.Delete(size);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<SizeDto>(size);
        }

        public IEnumerable<SizeDto> GetAll()
        {
            var sizes = _repo.GetAll();
            return _mapper.Map<IEnumerable<SizeDto>>(sizes);
        }

        public SizeDto GetSize(int id)
        {
            var size = _repo.GetById(id);
            return _mapper.Map<SizeDto>(size);
        }

        public bool SizeExists(int id)
        {
            var size = _repo.GetById(id);
            if(size == null){
                return false;
            }
            return true;
        }

        public SizeDto UpdateSize(SizeDto sizeDto)
        {
            var size = _mapper.Map<Size>(sizeDto);
            int res = _repo.Update(size);

            if(res <= 0){
                return null;
            }
            return sizeDto;
        }
    }
}