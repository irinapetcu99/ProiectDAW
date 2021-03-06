using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public interface IProdusRepository : IBaseRepository<Produs>
    {
        Produs GetProdusAllDetails(int id);
        List<Produs> GetProduseAllDetails();
    }
}
