using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class GrantPermissionService : IGrantPermissionService
    {
        private readonly IGrantPermissionRepository _repo;
        private readonly IMapper _mapper;

        public GrantPermissionService(IGrantPermissionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public GrantPermissionDto CreateGrantPermission(GrantPermissionDto grantPermissionDto)
        {
            var grant = _mapper.Map<GrantPermission>(grantPermissionDto);
            int res = _repo.Create(grant);

            if(res <= 0){
                return null;
            }
            return grantPermissionDto;
        }

        public GrantPermissionDto DeleteGrantPermission(int id)
        {
            var existed = this.GrantPermissionExists(id);
            if(!existed){
                return null;
            }
            var grant = _repo.GetById(id);
            int res = _repo.Delete(grant);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<GrantPermissionDto>(grant);
        }

        public IEnumerable<GrantPermissionDto> GetAll()
        {
            var grants = _repo.GetAll();
            return _mapper.Map<IEnumerable<GrantPermissionDto>>(grants);
        }

        public GrantPermissionDto GetGrantPermission(int id)
        {
            var grant = _repo.GetById(id);
            return _mapper.Map<GrantPermissionDto>(grant);
        }

        public bool GrantPermissionExists(int id)
        {
            var grant = _repo.GetById(id);
            if(grant == null){
                return false;
            }
            return true;
        }

        public GrantPermissionDto UpdateGrantPermission(GrantPermissionDto grantPermissionDto)
        {
            var grant = _mapper.Map<GrantPermission>(grantPermissionDto);
            int res = _repo.Update(grant);

            if(res <= 0){
                return null;
            }
            return grantPermissionDto;
        }
    }
}