using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SchoolContext context) : base(context)
        {
        }

        public Role GetRoleAllDetails(int id)
        {
            return _table.Where(arg => arg.RoleId == id)
                .FirstOrDefault();
        }

        public List<Role> GetRolesAllDetails()
        {
            return _table
                .ToList();
        }
    }
}
