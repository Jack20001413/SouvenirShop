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
        private readonly IGrantPermissionRepository _grantPermissionRepo;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repo, IGrantPermissionRepository grantPermissionRepo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _grantPermissionRepo = grantPermissionRepo;
        }

        public RoleFullDto CreateRole(RoleFullDto roleDto)
        {
            foreach (GrantPermissionDto g in roleDto.GrantPermissions) {
                g.PermissionId = g.Permission.Id;
                g.Permission = null;
            }
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

        public BaseSearchDto<RoleDto> GetAll(BaseSearchDto<RoleDto> searchDto) {
            var roleSearch = _repo.GetAll(searchDto);
            BaseSearchDto<RoleDto> roleDtoSearch = new BaseSearchDto<RoleDto>{
                currentPage = roleSearch.currentPage,
                recordOfPage = roleSearch.recordOfPage,
                totalRecords = roleSearch.totalRecords,
                sortAsc = roleSearch.sortAsc,
                sortBy = roleSearch.sortBy,
                createdDateSort = roleSearch.createdDateSort,
                pagingRange = roleSearch.pagingRange,
                result = _mapper.Map<List<RoleDto>>(roleSearch.result)
            };
            return roleDtoSearch;
        }

        public List<RoleDto> GetLikeName(string name) {
            var roles = _repo.GetLikeName(name);
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public RoleFullDto GetRole(int id)
        {
            var role = _repo.GetById(id);
            var grantPermissions = _grantPermissionRepo.GetByRoleId(id);
            role.GrantPermissions = grantPermissions;

            return _mapper.Map<RoleFullDto>(role);
        }

        public bool RoleExists(int id)
        {
            var role = _repo.GetById(id);
            if(role == null){
                return false;
            }
            return true;
        }

        public RoleFullDto UpdateRole(RoleFullDto roleDto)
        {
            foreach (GrantPermissionDto g in roleDto.GrantPermissions) {
                g.PermissionId = g.Permission.Id;
                g.Permission = null;
            }
            _grantPermissionRepo.DeleteByRoleId(roleDto.Id);
            var role = _mapper.Map<Role>(roleDto);
            int res = _repo.Update(role);

            if(res <= 0){
                return null;
            }
            return roleDto;
        }
    }
}