using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdusController : ControllerBase
    {
        private readonly IProdusService _produsService;
        private readonly IProdusRepository _produsRepository;

        public ProdusController(IProdusService produsService, IProdusRepository produsRepository)
        {
            _produsService = produsService;
            _produsRepository = produsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_produsService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] Produs produs)
        {
            _produsRepository.Create(produs);
            _produsRepository.SaveChanges();
            var result = _produsRepository.GetProdusAllDetails(produs.ProdusId);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] Produs produs)
        {
            return Ok(_produsService.Update(produs));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_produsService.Delete(id));
        }
    }
}
