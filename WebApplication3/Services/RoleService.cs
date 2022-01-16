using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;
using WebApplication3.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Role Create(Role cat)
        {
            _roleRepository.Create(cat);
            _roleRepository.SaveChanges();

            return _roleRepository.GetRoleAllDetails(cat.RoleId);
        }
        public Role Get(int id)
        {
            return _roleRepository.GetRoleAllDetails(id);
        }

        public bool Delete(int id)
        {
            var entity = _roleRepository.FindById(id);
            if (entity != null)
            {
                _roleRepository.Delete(entity);
                _roleRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetRolesAllDetails();
        }

        public Role Update(Role role)
        {
            if (_roleRepository.FindById(role.RoleId) == null) return null;
            _roleRepository.Update(role);
            _roleRepository.SaveChanges();
            return _roleRepository.GetRoleAllDetails(role.RoleId);
        }
    }
}