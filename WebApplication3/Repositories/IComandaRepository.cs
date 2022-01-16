using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public interface IComandaRepository : IBaseRepository<Comanda>
    {
        Comanda GetComandaAllDetails(int id);
        List<Comanda> GetComenziAllDetails();
        List<Comanda> GetAllWithInclude();
        List<Comanda> GetAllWithJoin();
    }
}
