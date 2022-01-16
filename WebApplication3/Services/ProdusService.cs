using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;

namespace WebApplication3.Services
{
    public class ProdusService : IProdusService
    {
        private readonly IProdusRepository _produsRepository;

        public ProdusService(IProdusRepository produsRepository)
        {
            _produsRepository = produsRepository;
        }

        public Produs Create(Produs cat)
        {
            _produsRepository.Create(cat);
            _produsRepository.SaveChanges();

            return _produsRepository.GetProdusAllDetails(cat.ProdusId);
        }
        public Produs Get(int id)
        {
            return _produsRepository.GetProdusAllDetails(id);
        }

        public bool Delete(int id)
        {
            var entity = _produsRepository.FindById(id);
            if (entity != null)
            {
                _produsRepository.Delete(entity);
                _produsRepository.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Produs> GetAll()
        {
            return _produsRepository.GetProduseAllDetails();
        }

        public Produs Update(Produs cat)
        {
            if (_produsRepository.FindById(cat.ProdusId) == null) return null;
            _produsRepository.Update(cat);
            _produsRepository.SaveChanges();
            return _produsRepository.GetProdusAllDetails(cat.ProdusId);
        }
    }
}
