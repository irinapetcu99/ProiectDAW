using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(SchoolContext context) : base(context)
        {

        }
        public Comanda GetComandaAllDetails(int id)
        {
            return _table.Where(arg => arg.ComandaId == id)
                .FirstOrDefault();
        }

        public List<Comanda> GetComenziAllDetails()
        {
            return _table
                .ToList();
        }

        public List<Comanda> GetAllWithInclude()
        {
            return _table.Include(x => x.Produse).ToList();
        }

        public List<Comanda> GetAllWithJoin()
        {
            var result = _table.Join(_context.Produs, x => x.ComandaId, y => y.ComandaId,
                (x, y) => new { x, y }).Select(obj => obj.x);

            return result.ToList();
        }

    }
}
