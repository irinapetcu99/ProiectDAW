using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;

namespace WebApplication3.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly SchoolContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(SchoolContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public List<T> FindAll()
        {
            return _table.ToList();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public T FindById(object id)
        {
            var result = _table.Find(id);
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public async Task<T> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }
    }
}
