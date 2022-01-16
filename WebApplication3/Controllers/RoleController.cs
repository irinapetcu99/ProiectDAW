using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Services.IServices;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleService roleService, IRoleRepository roleRepository)
        {
            _roleService = roleService;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_roleService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] Role role)
        {
            _roleRepository.Create(role);
            _roleRepository.SaveChanges();
            var result = _roleRepository.GetRoleAllDetails(role.RoleId);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] Role role)
        {
            return Ok(_roleService.Update(role));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_roleService.Delete(id));
        }
    }
}
