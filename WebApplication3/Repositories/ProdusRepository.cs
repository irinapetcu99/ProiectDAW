using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public class ProdusRepository : BaseRepository<Produs>, IProdusRepository
    {
        public ProdusRepository(SchoolContext context) : base(context)
        {

        }
        public Produs GetProdusAllDetails(int id)
        {
            return _table.Where(arg => arg.ProdusId == id)
                .FirstOrDefault();
        }

        public List<Produs> GetProduseAllDetails()
        {
            return _table
                .ToList();
        }
    }
}
