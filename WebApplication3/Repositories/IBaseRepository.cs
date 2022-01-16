using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(object id);
        Task<T> FindByIdAsync(object id);
        List<T> FindAll();
        bool SaveChanges();
    }
}
