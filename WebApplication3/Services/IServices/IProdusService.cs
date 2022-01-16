using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Services.IServices
{
    public interface IProdusService
    {
        Produs Create(Produs produs);
        Produs Get(int id);
        Produs Update(Produs produs);
        bool Delete(int id);
        List<Produs> GetAll();
    }
}
