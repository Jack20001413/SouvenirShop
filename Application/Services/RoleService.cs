using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using SouvenirShop.Domain.Entities;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public RoleDto CreateRole(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            int res = _repo.Create(role);

            if(res <= 0){
                return null;
            }
            return roleDto;
        }

        public RoleDto DeleteRole(int id)
        {
            var existed = this.RoleExists(id);
            if(!existed){
                return null;
            }
            var role = _repo.GetById(id);
            int res = _repo.Delete(role);

            if(res <= 0){
                return null;
            }
            return _mapper.Map<RoleDto>(role);
        }

        public IEnumerable<RoleDto> GetAll()
        {
            var roles = _repo.GetAll();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public RoleDto GetRole(int id)
        {
            var role = _repo.GetById(id);
            return _mapper.Map<RoleDto>(role);
        }

        public bool RoleExists(int id)
        {
            var role = _repo.GetById(id);
            if(role == null){
                return false;
            }
            return true;
        }

        public RoleDto UpdateRole(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            int res = _repo.Update(role);

            if(res <= 0){
                return null;
            }
            return roleDto;
        }
    }
}