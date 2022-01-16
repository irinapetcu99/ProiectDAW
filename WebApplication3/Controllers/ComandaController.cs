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
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;
        private readonly IComandaRepository _comandaRepository;

        public ComandaController(IComandaService comandaService, IComandaRepository comandaRepository)
        {
            _comandaService = comandaService;
            _comandaRepository = comandaRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_comandaService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_comandaService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] Comanda comanda)
        {
            _comandaRepository.Create(comanda);
            _comandaRepository.SaveChanges();
            var result = _comandaRepository.GetComandaAllDetails(comanda.ComandaId);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] Comanda comanda)
        {
            return Ok(_comandaService.Update(comanda));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_comandaService.Delete(id));
        }
    }
}
