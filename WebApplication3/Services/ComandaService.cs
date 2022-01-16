using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;

namespace WebApplication3.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public Comanda Create(Comanda cat)
        {
            _comandaRepository.Create(cat);
            _comandaRepository.SaveChanges();

            return _comandaRepository.GetComandaAllDetails(cat.ComandaId);
        }
        public Comanda Get(int id)
        {
            return _comandaRepository.GetComandaAllDetails(id);
        }

        public bool Delete(int id)
        {
            var entity = _comandaRepository.FindById(id);
            if (entity != null)
            {
                _comandaRepository.Delete(entity);
                _comandaRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Comanda> GetAll()
        {
            return _comandaRepository.GetComenziAllDetails();
        }

        public Comanda Update(Comanda cat)
        {
            if (_comandaRepository.FindById(cat.ComandaId) == null) return null;
            _comandaRepository.Update(cat);
            _comandaRepository.SaveChanges();
            return _comandaRepository.GetComandaAllDetails(cat.ComandaId);
        }
    }
}
