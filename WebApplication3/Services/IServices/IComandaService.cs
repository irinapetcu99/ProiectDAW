using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Services.IServices
{
    public interface IComandaService
    {
        Comanda Create(Comanda comanda);
        Comanda Get(int id);
        Comanda Update(Comanda comanda);
        bool Delete(int id);
        List<Comanda> GetAll();
    }
}
